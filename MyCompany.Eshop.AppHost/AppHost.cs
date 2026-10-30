using Aspire.Hosting.Yarp.Transforms;

var builder = DistributedApplication.CreateBuilder(args);
builder.AddDockerComposeEnvironment("docker");

var clientSecret = builder.AddParameter("client-secret", secret: true);

var idp = builder.AddKeycloak(name: "idp")
    .WithDockerfile("./keycloak")
    .WithEnvironment("KC_BOOTSTRAP_ADMIN_USERNAME", "admin")
    .WithEnvironment("KC_BOOTSTRAP_ADMIN_PASSWORD", "admin")
    .WithEnvironment("WEBAPP_CLIENT_SECRET", clientSecret)
    .WithEnvironment("KC_HTTP_ENABLED", "true")
    //.WithEnvironment("KC_PROXY_HEADERS", "xforwarded")
    .WithEnvironment("KC_HOSTNAME_STRICT", "false")
    .WithExternalHttpEndpoints()
    ;

var api = builder
    .AddProject<Projects.MyCompany_Eshop_ApiService>("api")
    .WithReference(idp).WaitFor(idp)
    ;

var web = builder
    .AddProject<Projects.MyCompany_Eshop_Web>("web")
    .WithEnvironment("Identity__ClientSecret", clientSecret)
    .WithReference(idp).WaitFor(idp)
    .WithReference(api).WaitFor(api)
    ;

var gate = builder.AddYarp("gate")
    .WithConfiguration(yarp =>
    {
        yarp.AddRoute("/{**catch-all}", web)
            .WithTransformUseOriginalHostHeader()
            ;
    })
    .WaitFor(api)
    .WaitFor(web)
    .WithExternalHttpEndpoints();

idp.WithEnvironment(ctx =>
{
    var http = gate.GetEndpoint("http", KnownNetworkIdentifiers.LocalhostNetwork);
    var https = gate.GetEndpoint("https", KnownNetworkIdentifiers.LocalhostNetwork);


    if (!https.Exists)
    {
        https = http;
    }

    ctx.EnvironmentVariables["WEBAPP_HTTP_CONTAINERHOST"] = http;
    ctx.EnvironmentVariables["WEBAPP_HTTP"] = ctx.ExecutionContext.IsPublishMode ? http : http.Url;

    ctx.EnvironmentVariables["WEBAPP_HTTPS_CONTAINERHOST"] = https;
    ctx.EnvironmentVariables["WEBAPP_HTTPS"] = ctx.ExecutionContext.IsPublishMode ? https : https.Url;
});


builder.Build().Run();

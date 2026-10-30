var builder = DistributedApplication.CreateBuilder(args);
builder.AddDockerComposeEnvironment("docker");

var clientSecret = builder.AddParameter("client-secret", secret: true);

// http://localhost:5000 for test in local deployment
var webPublicUrl = builder.AddParameter("web-public-url"); 

var idp = builder.AddKeycloak(name: "idp")
    .WithDockerfile("./keycloak")
    .WithEnvironment("KC_BOOTSTRAP_ADMIN_USERNAME", "admin")
    .WithEnvironment("KC_BOOTSTRAP_ADMIN_PASSWORD", "admin")
    .WithEnvironment("WEBAPP_CLIENT_SECRET", clientSecret)
    .WithEnvironment("KC_HTTP_ENABLED", "true")
    .WithEnvironment("KC_PROXY_HEADERS", "xforwarded")
    .WithEnvironment("KC_HOSTNAME_STRICT", "false")
    .WithEndpoint("http", e => e.IsExternal = true)
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
    .WithHttpEndpoint(port: 5000, targetPort: 8080, name: "http")
    .WithExternalHttpEndpoints()
    ;


idp.WithEnvironment(ctx =>
{
    var http = web.GetEndpoint("http");
    var https = web.GetEndpoint("https");


    if (!https.Exists)
    {
        https = http;
    }

    ctx.EnvironmentVariables["WEBAPP_HTTP_CONTAINERHOST"] = http;
    ctx.EnvironmentVariables["WEBAPP_HTTP"] = ctx.ExecutionContext.IsPublishMode ? webPublicUrl : http.Url;

    ctx.EnvironmentVariables["WEBAPP_HTTPS_CONTAINERHOST"] = https;
    ctx.EnvironmentVariables["WEBAPP_HTTPS"] = ctx.ExecutionContext.IsPublishMode ? webPublicUrl : https.Url;
});


builder.Build().Run();

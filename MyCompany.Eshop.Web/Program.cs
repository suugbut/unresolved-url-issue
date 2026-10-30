using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using MyCompany.Eshop.Web;
using MyCompany.Eshop.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<TokenHandler>();

builder.Services
    .AddHttpClient<CounterClient>(client => client.BaseAddress = new("https+http://api"))
    .AddHttpMessageHandler<TokenHandler>()
    ;

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = "__OnlineShop";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
    })
    .AddKeycloakOpenIdConnect(
        serviceName: "idp",
        realm: "OnlineShop",
        configureOptions: options =>
        {
            options.ClientId = "webapp";
            options.ClientSecret = builder.Configuration.GetValue<string>("Identity:ClientSecret");
            options.ResponseType = OpenIdConnectResponseType.Code;
            options.SaveTokens = true;
            options.RequireHttpsMetadata = false;// !builder.Environment.IsDevelopment();
            options.MapInboundClaims = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = "preferred_username"
            };
            options.Events.OnRedirectToIdentityProvider = context =>
            {
                var logger = context.HttpContext.RequestServices
                    .GetRequiredService<ILoggerFactory>()
                    .CreateLogger("OIDC");

                logger.LogInformation(
                    "OIDC RedirectUri: {RedirectUri}",
                    context.ProtocolMessage.RedirectUri);

                logger.LogInformation(
                    "Request Scheme: {Scheme}, Host: {Host}, PathBase: {PathBase}",
                    context.Request.Scheme,
                    context.Request.Host,
                    context.Request.PathBase);

                return Task.CompletedTask;
            };
        }
    );

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();




app.MapStaticAssets();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.MapGet("login", async (HttpContext ctx, string? returnUrl) =>
{
    var properties = new AuthenticationProperties
    {
        RedirectUri = returnUrl ?? "/"
    };

    return TypedResults.Challenge(properties, [
            OpenIdConnectDefaults.AuthenticationScheme
        ]);
});

app.MapPost("logout", (HttpContext ctx, string? returnUrl) =>
{
    var properties = new AuthenticationProperties
    {
        RedirectUri = returnUrl ?? "/"
    };

    return TypedResults.SignOut(properties, [
            CookieAuthenticationDefaults.AuthenticationScheme,
            OpenIdConnectDefaults.AuthenticationScheme
        ]);
});


app.Run();

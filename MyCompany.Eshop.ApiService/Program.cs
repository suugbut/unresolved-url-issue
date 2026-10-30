using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.AddAuthentication()
    .AddKeycloakJwtBearer(
        serviceName: "idp",
        realm: "OnlineShop",
        configureOptions: options =>
        {
            options.Audience = "account";
            options.RequireHttpsMetadata = false; // !builder.Environment.IsDevelopment();
            options.MapInboundClaims = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,//default
                ValidateAudience = true,//default
                ValidateLifetime = true,//default
            };
        }
    );
builder.Services.AddAuthorization(configure: options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
});

var app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();


int counter = 0;

app.MapGet("/v1/counter", () => TypedResults.Ok(++counter));

app.MapDefaultEndpoints();

app.Run();
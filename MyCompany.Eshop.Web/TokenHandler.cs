using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

internal sealed class TokenHandler(IHttpContextAccessor accessor) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cantok)
    {
        var context = accessor.HttpContext ??
            throw new InvalidOperationException("HttpContext does not exist");

        var token = await context.GetTokenAsync("access_token");
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new InvalidOperationException("Access token does not exist");
        }

        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cantok);
    }
}
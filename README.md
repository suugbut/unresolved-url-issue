- username: `test@example.com`

- password: `P@$$w0rd1` (case sensitive, 0 is zero and 1 is one)


###

- `aspire run` works
- `aspire deploy` does NOT work with the following error:
```
2026-10-31 05:21:43.158 | info: Microsoft.Hosting.Lifetime[0]
2026-10-31 05:21:43.158 |       Hosting environment: Production
2026-10-31 05:21:43.158 | info: Microsoft.Hosting.Lifetime[0]
2026-10-31 05:21:43.158 |       Content root path: /app
2026-10-31 05:22:10.492 | warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
2026-10-31 05:22:10.492 |       Failed to determine the https port for redirect.
2026-10-31 05:22:11.158 | fail: Microsoft.AspNetCore.Antiforgery.DefaultAntiforgery[7]
2026-10-31 05:22:11.158 |       An exception was thrown while deserializing the token.
2026-10-31 05:22:11.158 |       Microsoft.AspNetCore.Antiforgery.AntiforgeryValidationException: The antiforgery token could not be decrypted.
2026-10-31 05:22:11.158 |        ---> System.Security.Cryptography.CryptographicException: The key {81a79d0b-e39c-430f-a1d0-fc056487735d} was not found in the key ring. For more information go to https://aka.ms/aspnet/dataprotectionwarning
2026-10-31 05:22:11.161 |          at Microsoft.AspNetCore.DataProtection.KeyManagement.KeyRingBasedDataProtector.UnprotectCore(Byte[] protectedData, Boolean allowOperationsOnRevokedKeys, UnprotectStatus& status)
2026-10-31 05:22:11.161 |          at Microsoft.AspNetCore.DataProtection.KeyManagement.KeyRingBasedDataProtector.Unprotect(Byte[] protectedData)
2026-10-31 05:22:11.161 |          at Microsoft.AspNetCore.Antiforgery.DefaultAntiforgeryTokenSerializer.Deserialize(String serializedToken)
2026-10-31 05:22:11.161 |          --- End of inner exception stack trace ---
2026-10-31 05:22:11.161 |          at Microsoft.AspNetCore.Antiforgery.DefaultAntiforgeryTokenSerializer.Deserialize(String serializedToken)
2026-10-31 05:22:11.161 |          at Microsoft.AspNetCore.Antiforgery.DefaultAntiforgery.GetCookieTokenDoesNotThrow(HttpContext httpContext)
```

```
2026-10-31 05:23:16.048 | info: System.Net.Http.HttpClient.KeycloakBackchannel.LogicalHandler[100]
2026-10-31 05:23:16.048 |       Start processing HTTP request GET https+http://idp/realms/OnlineShop/.well-known/openid-configuration
2026-10-31 05:23:16.114 | info: System.Net.Http.HttpClient.KeycloakBackchannel.ClientHandler[100]
2026-10-31 05:23:16.115 |       Sending HTTP request GET http://idp:8080/realms/OnlineShop/.well-known/openid-configuration
2026-10-31 05:23:16.433 | info: System.Net.Http.HttpClient.KeycloakBackchannel.ClientHandler[101]
2026-10-31 05:23:16.433 |       Received HTTP response headers after 311.8835ms - 200
2026-10-31 05:23:16.449 | info: Polly[3]
2026-10-31 05:23:16.449 |       Execution attempt. Source: '-standard//Standard-Retry', Operation Key: '', Result: '200', Handled: 'False', Attempt: '0', Execution Time: 365.3316ms
2026-10-31 05:23:16.466 | info: System.Net.Http.HttpClient.KeycloakBackchannel.LogicalHandler[101]
2026-10-31 05:23:16.466 |       End processing HTTP request after 420.8264ms - 200
2026-10-31 05:23:16.507 | info: System.Net.Http.HttpClient.KeycloakBackchannel.LogicalHandler[100]
2026-10-31 05:23:16.507 |       Start processing HTTP request GET http://idp:8080/realms/OnlineShop/protocol/openid-connect/certs
2026-10-31 05:23:16.513 | info: System.Net.Http.HttpClient.KeycloakBackchannel.ClientHandler[100]
2026-10-31 05:23:16.513 |       Sending HTTP request GET http://idp:8080/realms/OnlineShop/protocol/openid-connect/certs
2026-10-31 05:23:16.582 | info: System.Net.Http.HttpClient.KeycloakBackchannel.ClientHandler[101]
2026-10-31 05:23:16.582 |       Received HTTP response headers after 68.4984ms - 200
2026-10-31 05:23:16.582 | info: Polly[3]
2026-10-31 05:23:16.582 |       Execution attempt. Source: '-standard//Standard-Retry', Operation Key: '', Result: '200', Handled: 'False', Attempt: '0', Execution Time: 75.0893ms
2026-10-31 05:23:16.585 | info: System.Net.Http.HttpClient.KeycloakBackchannel.LogicalHandler[101]
2026-10-31 05:23:16.585 |       End processing HTTP request after 75.7044ms - 200
2026-10-31 05:23:16.610 | info: OIDC[0]
2026-10-31 05:23:16.610 |       OIDC RedirectUri: http://localhost:5000/signin-oidc
2026-10-31 05:23:16.611 | info: OIDC[0]
2026-10-31 05:23:16.611 |       Request Scheme: http, Host: localhost:5000, PathBase: 
2026-10-31 05:23:16.621 | info: System.Net.Http.HttpClient.KeycloakBackchannel.LogicalHandler[100]
2026-10-31 05:23:16.621 |       Start processing HTTP request POST http://idp:8080/realms/OnlineShop/protocol/openid-connect/ext/par/request
2026-10-31 05:23:16.621 | info: System.Net.Http.HttpClient.KeycloakBackchannel.ClientHandler[100]
2026-10-31 05:23:16.621 |       Sending HTTP request POST http://idp:8080/realms/OnlineShop/protocol/openid-connect/ext/par/request
2026-10-31 05:23:16.720 | info: System.Net.Http.HttpClient.KeycloakBackchannel.ClientHandler[101]
2026-10-31 05:23:16.720 |       Received HTTP response headers after 99.423ms - 201
2026-10-31 05:23:16.720 | info: Polly[3]
2026-10-31 05:23:16.720 |       Execution attempt. Source: '-standard//Standard-Retry', Operation Key: '', Result: '201', Handled: 'False', Attempt: '0', Execution Time: 99.8133ms
2026-10-31 05:23:16.725 | info: System.Net.Http.HttpClient.KeycloakBackchannel.LogicalHandler[101]
2026-10-31 05:23:16.725 |       End processing HTTP request after 100.2241ms - 201
```
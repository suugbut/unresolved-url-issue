- username: `test@example.com`

- password: `P@$$w0rd1` (case sensitive, 0 is zero and 1 is one)


###

- `aspire run` works
- `aspire deploy` does NOT work with the following error:
```
2026-10-31 04:26:15.091 | info: System.Net.Http.HttpClient.KeycloakBackchannel.LogicalHandler[100]
2026-10-31 04:26:15.092 |       Start processing HTTP request GET https+http://idp/realms/OnlineShop/.well-known/openid-configuration
2026-10-31 04:26:15.092 | info: System.Net.Http.HttpClient.KeycloakBackchannel.ClientHandler[100]
2026-10-31 04:26:15.092 |       Sending HTTP request GET http://idp:8080/realms/OnlineShop/.well-known/openid-configuration
2026-10-31 04:26:18.434 | info: System.Net.Http.HttpClient.KeycloakBackchannel.ClientHandler[104]
2026-10-31 04:26:18.434 |       HTTP request failed after 3341.9892ms
2026-10-31 04:26:18.434 |       System.Net.Http.HttpRequestException: Name or service not known (idp:8080)
2026-10-31 04:26:18.434 |        ---> System.Net.Sockets.SocketException (0xFFFDFFFF): Name or service not known
2026-10-31 04:26:18.434 |          at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.ThrowException(SocketError error, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.System.Threading.Tasks.Sources.IValueTaskSource.GetResult(Int16 token)
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          --- End of inner exception stack trace ---
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionPool.ConnectAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionPool.CreateHttp11ConnectionAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionPool.InjectNewHttp11ConnectionAsync(QueueItem queueItem)
2026-10-31 04:26:18.434 |          at System.Threading.Tasks.TaskCompletionSourceWithCancellation`1.WaitWithCancellationAsync(CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionWaiter`1.WaitForConnectionWithTelemetryAsync(HttpRequestMessage request, HttpConnectionPool pool, Boolean async, CancellationToken requestCancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionPool.SendWithVersionDetectionAndRetryAsync(HttpRequestMessage request, Boolean async, Boolean doRequestAuth, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.Metrics.MetricsHandler.SendAsyncWithMetrics(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.DiagnosticsHandler.SendAsyncCore(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at Microsoft.Extensions.Http.Logging.LoggingHttpMessageHandler.<SendCoreAsync>g__Core|4_0(HttpRequestMessage request, Boolean useAsync, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 | warn: Polly[3]
2026-10-31 04:26:18.434 |       Execution attempt. Source: '-standard//Standard-Retry', Operation Key: '', Result: 'Name or service not known (idp:8080)', Handled: 'True', Attempt: '0', Execution Time: 3343.5393ms
2026-10-31 04:26:18.434 |       System.Net.Http.HttpRequestException: Name or service not known (idp:8080)
2026-10-31 04:26:18.434 |        ---> System.Net.Sockets.SocketException (0xFFFDFFFF): Name or service not known
2026-10-31 04:26:18.434 |          at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.ThrowException(SocketError error, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.System.Threading.Tasks.Sources.IValueTaskSource.GetResult(Int16 token)
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          --- End of inner exception stack trace ---
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionPool.ConnectAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionPool.CreateHttp11ConnectionAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionPool.InjectNewHttp11ConnectionAsync(QueueItem queueItem)
2026-10-31 04:26:18.434 |          at System.Threading.Tasks.TaskCompletionSourceWithCancellation`1.WaitWithCancellationAsync(CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionWaiter`1.WaitForConnectionWithTelemetryAsync(HttpRequestMessage request, HttpConnectionPool pool, Boolean async, CancellationToken requestCancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.HttpConnectionPool.SendWithVersionDetectionAndRetryAsync(HttpRequestMessage request, Boolean async, Boolean doRequestAuth, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.Metrics.MetricsHandler.SendAsyncWithMetrics(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.DiagnosticsHandler.SendAsyncCore(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at Microsoft.Extensions.Http.Logging.LoggingHttpMessageHandler.<SendCoreAsync>g__Core|4_0(HttpRequestMessage request, Boolean useAsync, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at Microsoft.Extensions.ServiceDiscovery.Http.ResolvingHttpDelegatingHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
2026-10-31 04:26:18.434 |          at Microsoft.Extensions.Http.Resilience.ResilienceHandler.<>c.<<SendAsync>b__3_0>d.MoveNext()
2026-10-31 04:26:18.435 | warn: Polly[0]
2026-10-31 04:26:18.435 |       Resilience event occurred. EventName: 'OnRetry', Source: '-standard//Standard-Retry', Operation Key: '', Result: 'Name or service not known (idp:8080)'
2026-10-31 04:26:18.435 |       System.Net.Http.HttpRequestException: Name or service not known (idp:8080)
2026-10-31 04:26:18.435 |        ---> System.Net.Sockets.SocketException (0xFFFDFFFF): Name or service not known
2026-10-31 04:26:18.435 |          at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.ThrowException(SocketError error, CancellationToken cancellationToken)
2026-10-31 04:26:18.435 |          at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.System.Threading.Tasks.Sources.IValueTaskSource.GetResult(Int16 token)
2026-10-31 04:26:18.435 |          at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.435 |          --- End of inner exception stack trace ---
2026-10-31 04:26:18.435 |          at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.435 |          at System.Net.Http.HttpConnectionPool.ConnectAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.435 |          at System.Net.Http.HttpConnectionPool.CreateHttp11ConnectionAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.435 |          at System.Net.Http.HttpConnectionPool.InjectNewHttp11ConnectionAsync(QueueItem queueItem)
2026-10-31 04:26:18.435 |          at System.Threading.Tasks.TaskCompletionSourceWithCancellation`1.WaitWithCancellationAsync(CancellationToken cancellationToken)
2026-10-31 04:26:18.435 |          at System.Net.Http.HttpConnectionWaiter`1.WaitForConnectionWithTelemetryAsync(HttpRequestMessage request, HttpConnectionPool pool, Boolean async, CancellationToken requestCancellationToken)
2026-10-31 04:26:18.435 |          at System.Net.Http.HttpConnectionPool.SendWithVersionDetectionAndRetryAsync(HttpRequestMessage request, Boolean async, Boolean doRequestAuth, CancellationToken cancellationToken)
2026-10-31 04:26:18.435 |          at System.Net.Http.Metrics.MetricsHandler.SendAsyncWithMetrics(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.435 |          at System.Net.Http.DiagnosticsHandler.SendAsyncCore(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.435 |          at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:18.435 |          at Microsoft.Extensions.Http.Logging.LoggingHttpMessageHandler.<SendCoreAsync>g__Core|4_0(HttpRequestMessage request, Boolean useAsync, CancellationToken cancellationToken)
2026-10-31 04:26:18.435 |          at Microsoft.Extensions.ServiceDiscovery.Http.ResolvingHttpDelegatingHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
2026-10-31 04:26:18.435 |          at Microsoft.Extensions.Http.Resilience.ResilienceHandler.<>c.<<SendAsync>b__3_0>d.MoveNext()
2026-10-31 04:26:20.591 | info: System.Net.Http.HttpClient.KeycloakBackchannel.ClientHandler[100]
2026-10-31 04:26:20.591 |       Sending HTTP request GET http://idp:8080/realms/OnlineShop/.well-known/openid-configuration
2026-10-31 04:26:23.917 | info: System.Net.Http.HttpClient.KeycloakBackchannel.ClientHandler[104]
2026-10-31 04:26:23.917 |       HTTP request failed after 3325.484ms
2026-10-31 04:26:23.917 |       System.Net.Http.HttpRequestException: Name or service not known (idp:8080)
2026-10-31 04:26:23.917 |        ---> System.Net.Sockets.SocketException (0xFFFDFFFF): Name or service not known
2026-10-31 04:26:23.917 |          at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.ThrowException(SocketError error, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.System.Threading.Tasks.Sources.IValueTaskSource.GetResult(Int16 token)
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          --- End of inner exception stack trace ---
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionPool.ConnectAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionPool.CreateHttp11ConnectionAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionPool.InjectNewHttp11ConnectionAsync(QueueItem queueItem)
2026-10-31 04:26:23.917 |          at System.Threading.Tasks.TaskCompletionSourceWithCancellation`1.WaitWithCancellationAsync(CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionWaiter`1.WaitForConnectionWithTelemetryAsync(HttpRequestMessage request, HttpConnectionPool pool, Boolean async, CancellationToken requestCancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionPool.SendWithVersionDetectionAndRetryAsync(HttpRequestMessage request, Boolean async, Boolean doRequestAuth, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.Metrics.MetricsHandler.SendAsyncWithMetrics(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.DiagnosticsHandler.SendAsyncCore(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at Microsoft.Extensions.Http.Logging.LoggingHttpMessageHandler.<SendCoreAsync>g__Core|4_0(HttpRequestMessage request, Boolean useAsync, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 | warn: Polly[3]
2026-10-31 04:26:23.917 |       Execution attempt. Source: '-standard//Standard-Retry', Operation Key: '', Result: 'Name or service not known (idp:8080)', Handled: 'True', Attempt: '1', Execution Time: 3326.1127ms
2026-10-31 04:26:23.917 |       System.Net.Http.HttpRequestException: Name or service not known (idp:8080)
2026-10-31 04:26:23.917 |        ---> System.Net.Sockets.SocketException (0xFFFDFFFF): Name or service not known
2026-10-31 04:26:23.917 |          at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.ThrowException(SocketError error, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.System.Threading.Tasks.Sources.IValueTaskSource.GetResult(Int16 token)
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          --- End of inner exception stack trace ---
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionPool.ConnectAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionPool.CreateHttp11ConnectionAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionPool.InjectNewHttp11ConnectionAsync(QueueItem queueItem)
2026-10-31 04:26:23.917 |          at System.Threading.Tasks.TaskCompletionSourceWithCancellation`1.WaitWithCancellationAsync(CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionWaiter`1.WaitForConnectionWithTelemetryAsync(HttpRequestMessage request, HttpConnectionPool pool, Boolean async, CancellationToken requestCancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.HttpConnectionPool.SendWithVersionDetectionAndRetryAsync(HttpRequestMessage request, Boolean async, Boolean doRequestAuth, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.Metrics.MetricsHandler.SendAsyncWithMetrics(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.DiagnosticsHandler.SendAsyncCore(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at Microsoft.Extensions.Http.Logging.LoggingHttpMessageHandler.<SendCoreAsync>g__Core|4_0(HttpRequestMessage request, Boolean useAsync, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at Microsoft.Extensions.ServiceDiscovery.Http.ResolvingHttpDelegatingHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
2026-10-31 04:26:23.917 |          at Microsoft.Extensions.Http.Resilience.ResilienceHandler.<>c.<<SendAsync>b__3_0>d.MoveNext()
2026-10-31 04:26:23.918 | warn: Polly[0]
2026-10-31 04:26:23.918 |       Resilience event occurred. EventName: 'OnRetry', Source: '-standard//Standard-Retry', Operation Key: '', Result: 'Name or service not known (idp:8080)'
2026-10-31 04:26:23.918 |       System.Net.Http.HttpRequestException: Name or service not known (idp:8080)
2026-10-31 04:26:23.918 |        ---> System.Net.Sockets.SocketException (0xFFFDFFFF): Name or service not known
2026-10-31 04:26:23.918 |          at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.ThrowException(SocketError error, CancellationToken cancellationToken)
2026-10-31 04:26:23.918 |          at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.System.Threading.Tasks.Sources.IValueTaskSource.GetResult(Int16 token)
2026-10-31 04:26:23.918 |          at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.918 |          --- End of inner exception stack trace ---
2026-10-31 04:26:23.918 |          at System.Net.Http.HttpConnectionPool.ConnectToTcpHostAsync(String host, Int32 port, HttpRequestMessage initialRequest, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.918 |          at System.Net.Http.HttpConnectionPool.ConnectAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.918 |          at System.Net.Http.HttpConnectionPool.CreateHttp11ConnectionAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.918 |          at System.Net.Http.HttpConnectionPool.InjectNewHttp11ConnectionAsync(QueueItem queueItem)
2026-10-31 04:26:23.918 |          at System.Threading.Tasks.TaskCompletionSourceWithCancellation`1.WaitWithCancellationAsync(CancellationToken cancellationToken)
2026-10-31 04:26:23.918 |          at System.Net.Http.HttpConnectionWaiter`1.WaitForConnectionWithTelemetryAsync(HttpRequestMessage request, HttpConnectionPool pool, Boolean async, CancellationToken requestCancellationToken)
2026-10-31 04:26:23.918 |          at System.Net.Http.HttpConnectionPool.SendWithVersionDetectionAndRetryAsync(HttpRequestMessage request, Boolean async, Boolean doRequestAuth, CancellationToken cancellationToken)
2026-10-31 04:26:23.918 |          at System.Net.Http.Metrics.MetricsHandler.SendAsyncWithMetrics(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.918 |          at System.Net.Http.DiagnosticsHandler.SendAsyncCore(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.918 |          at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, Boolean async, CancellationToken cancellationToken)
2026-10-31 04:26:23.918 |          at Microsoft.Extensions.Http.Logging.LoggingHttpMessageHandler.<SendCoreAsync>g__Core|4_0(HttpRequestMessage request, Boolean useAsync, CancellationToken cancellationToken)
2026-10-31 04:26:23.918 |          at Microsoft.Extensions.ServiceDiscovery.Http.ResolvingHttpDelegatingHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
2026-10-31 04:26:23.918 |          at Microsoft.Extensions.Http.Resilience.ResilienceHandler.<>c.<<SendAsync>b__3_0>d.MoveNext()
2026-10-31 04:26:25.374 | info: System.Net.Http.HttpClient.KeycloakBackchannel.ClientHandler[100]
2026-10-31 04:26:25.374 |       Sending HTTP request GET http://idp:8080/realms/OnlineShop/.well-known/openid-configuration
```
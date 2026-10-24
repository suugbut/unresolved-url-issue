namespace MyCompany.Eshop.Web;

internal sealed class CounterClient(HttpClient httpClient)
{
    public async Task<int> GetValueAsync(CancellationToken cantok = default)
    {
        return await httpClient.GetFromJsonAsync<int>("/api/v1/counter", cantok);
    }
}
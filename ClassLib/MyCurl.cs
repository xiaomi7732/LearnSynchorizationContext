namespace ClassLib;
public sealed class MyCurl : IDisposable
{
    private readonly HttpClient _httpClient;
    public MyCurl()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> CurlAsync(Uri uri)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(uri);
        return await response.Content.ReadAsStringAsync();

        // Simplified equivalent code:
        // Step 1: Catpure synchronization context
        // SynchronizationContext? currentContext = SynchronizationContext.Current;
        // Task<HttpResponseMessage> httpResponseTask = _httpClient.GetAsync(uri);
        // httpResponseTask.ContinueWith(async httpResponse =>
        // {
        //     if (currentContext == null)
        //     {
        //         return await httpResponse.Result.ReadAsStringAsync();
        //     }    
        //     else
        //     {
        //         currentContext.Post(async httpResponse => { 
        //             await httpResponse.Result.ReadAsStringAsync(); 
        //         }, null);
        //     }
        // }, TaskScheduler.Current);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}

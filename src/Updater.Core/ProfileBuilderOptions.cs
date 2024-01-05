using System;

namespace Updater.Core
{
    internal class ProfileBuilderConfiguration : IProfileBuilderOptions,
        IProfileServices
    {
        private HttpClient? _http;

        private List<Task<string>> _httpTasks = new List<Task<string>>();

        public IProfileBuilderOptions UseHttp(HttpClient? client = null)
        {
            _http = client ?? new HttpClient();
            _httpTasks = new List<Task<string>>();
            return this;
        }

        public Task<string> HttpGet(string url) {
            _httpTasks.Add(
                Http.GetStringAsync(url));
            return _httpTasks.Last();
        }

        public Task<string> HttpSend(HttpRequestMessage httpRequest)
        {
            _httpTasks.Add(
                ReadStringAsync(httpRequest));
            return _httpTasks.Last();

        }

        private async Task<string> ReadStringAsync(HttpRequestMessage message)
        {
            var response = await Http.SendAsync(message);
            return await response.Content.ReadAsStringAsync(); 
        }
          

        private HttpClient Http => _http ??
            throw new InvalidOperationException();

        public async Task AwaitSetupTasks()
        {
            await Task.WhenAll(_httpTasks.ToArray());
        }
    }
}


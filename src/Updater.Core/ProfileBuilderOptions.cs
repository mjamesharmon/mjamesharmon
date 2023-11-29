using System;

namespace Updater.Core
{
    public class ProfileBuilderOptions : IProfileBuilderOptions
    {
        private HttpClient? _http;

        private List<Task<string>> _httpTasks = new List<Task<string>>();

        public IProfileBuilderOptions UseHttp(HttpClient? client = null)
        {
            _http = client ?? new HttpClient();
            _httpTasks = new List<Task<string>>();
            return this;
        }

        internal Task<string> HttpGet(string url) {
            _httpTasks.Add(
                Http.GetStringAsync(url));
            return _httpTasks.Last();
        }

        private HttpClient Http => _http ??
            throw new InvalidOperationException();

        internal async Task AwaitAllServiceTasks() {
           await Task.WhenAll(_httpTasks.ToArray());
        }
    }
}


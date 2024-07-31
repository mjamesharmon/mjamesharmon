using System;
using System.Net.Http.Headers;

namespace Updater.Core.SectionProviders
{
	internal class BlogListingProvider : ISectionProvider
	{
		private const string _endpoint = "https://dev.to/api/articles/me";
		private const string _acceptHeader = "application/vnd.forem.api-v1+json";

        private IProfileServices _services;
		private BlogListingOptions? _options;

		private Task<string> _loadContent;

		public BlogListingProvider(IProfileServices services,
			BlogListingOptions options)
		{
			_services = services;
			_options = options;

			_loadContent = _AddContentRequest();
		}

        private Task<string> _AddContentRequest()
        {
			HttpRequestMessage httpRequest = new();
			httpRequest.RequestUri = new Uri($"{_endpoint}?page=1&per_page={_options?.MaxPosts ?? 6}");
			httpRequest.Headers.
				Accept.Add(new MediaTypeWithQualityHeaderValue(_acceptHeader));
			httpRequest.Headers.Add("api-key", Options.ApiKey);
			httpRequest.Headers.Add("User-Agent", ".Net App/7.0.0");

            return Services.HttpSend(httpRequest);
        }

        private IProfileServices Services => _services ??
			throw new NullReferenceException("No services configured");

		private BlogListingOptions Options => _options ??
			throw new NullReferenceException("Required options missing");

		public string Content => _loadContent.Result.
			AsMarkdownContent().
			AppendProfileLink(_options?.ProfileUrl).
			ToString();

        public string Title => "Latest Topics";
    }
}


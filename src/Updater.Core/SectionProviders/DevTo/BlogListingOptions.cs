using System;
namespace Updater.Core.SectionProviders
{
	public class BlogListingOptions
	{
		public int MaxPosts { get; set; } = 2;

		public string ApiKey { get; set; } = string.Empty;
	}
}


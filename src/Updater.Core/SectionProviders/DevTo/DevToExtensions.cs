using System;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Updater.Core.Extensions;
using Updater.Core.SectionProviders.DevTo;

namespace Updater.Core.SectionProviders
{
	public static class DevToExtensions
	{
		public static ProfileBuilder AddLatestFromDevTo(this ProfileBuilder builder,
			int maxPosts, string? profileUrl = null)
		{
			BlogListingOptions options = new();
			builder.Services.Configuration().
				GetSection(nameof(BlogListingOptions)).
				Bind(options);
			options.MaxPosts = maxPosts;
			options.ProfileUrl = profileUrl ?? string.Empty;
			return builder.AddSectionProvider(
				new BlogListingProvider(builder.Services, options));
		}

		public static StringBuilder AsMarkdownContent(this string json)
		{
			return json.AsArticles().
				Where(a=>a.IsPublished == true).
				Aggregate(new StringBuilder(), (content, article) =>
					content.AppendArticle(article));
				
		}

		public static StringBuilder AppendProfileLink(this StringBuilder builder, string? profile) {

			return string.IsNullOrWhiteSpace(profile) ? 
			 builder :
			 builder.AppendLine($"### [More...]({profile})");
		}

		
		private static StringBuilder AppendArticle(this StringBuilder builder,
			Article article)
		{
			builder.AppendLine($"### [{article.Title}]({article.Url})");
			builder.AppendLine($"\nPublished {article.PublishedAt.AsDaysAgo()}");
			builder.Append($"\n  💬 {article.CommentCount} &nbsp;&nbsp;");
			builder.Append($" 👍🏻 {article.Likes} &nbsp; &nbsp;");
			builder.AppendLine($" ⏱️ {article.ReadingTime}");
			builder.AppendLine("\n---");
            return builder;
		}

		private static string AsDaysAgo(this DateTime date)
		{
			TimeSpan interval = DateTime.UtcNow - date;
			int days = (int)interval.TotalDays;
			int weeks = days / 7;

			if (days == 0) return "Today";
			else if (days == 1) return "Yesterday";
			else if (days < 14) return $"{days} Days Ago";
			else return $"{weeks} Weeks Ago";
		}
		
		private static IEnumerable<Article> AsArticles(this string json)
			=> JsonSerializer.Deserialize<Article[]>(json) ??
			Enumerable.Empty<Article>();

	}
}


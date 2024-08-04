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
		private delegate bool TimeAgoCondition(TimeSpan interval);
        private delegate string TimeAgoFormatter(TimeSpan interval);
		private readonly record struct TimeAgoStrategy(TimeAgoCondition Condition, 
		  TimeAgoFormatter Formatter);


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

	
		public static string ToTimeAgoString(this DateTime date) {

			TimeSpan interval = DateTime.UtcNow - date;
			string result = date.ToShortDateString();
			
			foreach( var strategy in Strategies) {
				result = strategy.Condition(interval) ? 
				  strategy.Formatter(interval) :
				  result;
			}
			return result;
		}

		private static StringBuilder AppendArticle(this StringBuilder builder,
			Article article)
		{
			builder.AppendLine($"### [{article.Title}]({article.Url})");
			builder.AppendLine($"\nPublished {article.PublishedAt.ToTimeAgoString()}");
			builder.Append($"\n  💬 {article.CommentCount} &nbsp;&nbsp;");
			builder.Append($" 👍🏻 {article.Likes} &nbsp; &nbsp;");
			builder.AppendLine($" ⏱️ {article.ReadingTime}");
			builder.AppendLine("\n---");
            return builder;
		}

       private static IReadOnlyList<TimeAgoStrategy> Strategies =>
        new List<TimeAgoStrategy>
        {
            new TimeAgoStrategy(interval => interval.TotalDays < 1, interval => "Today"),
            new TimeAgoStrategy(interval => interval.TotalDays >= 1 && interval.TotalDays < 2, interval => "Yesterday"),
            new TimeAgoStrategy(interval => interval.TotalDays >= 2 && interval.TotalDays < 14, interval => $"{(int)interval.TotalDays} Days Ago"),
            new TimeAgoStrategy(interval => interval.TotalDays >= 14 && interval.TotalDays < 62, interval => $"{(int)(interval.TotalDays / 7)} Weeks Ago"),
            new TimeAgoStrategy(interval => interval.TotalDays >= 62, interval => $"{(int)(interval.TotalDays / 30)} Months Ago")
        };
		
		private static IEnumerable<Article> AsArticles(this string json)
			=> JsonSerializer.Deserialize<Article[]>(json) ??
			Enumerable.Empty<Article>();

	}
}


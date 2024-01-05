using System;
using System.Text.Json.Serialization;

namespace Updater.Core.SectionProviders.DevTo
{
	public class Article
	{
		[JsonPropertyName("title")]
		public string Title { get; set; } = string.Empty;

        [JsonPropertyName("published_at")]
        public DateTime PublishedAt { get; set; } = DateTime.MinValue;

		[JsonPropertyName("comments_count")]
		public int CommentCount { get; set; } = 0;

		[JsonPropertyName("url")]
		public string Url { get; set; } = string.Empty;

		[JsonPropertyName("published")]
		public bool IsPublished { get; set; } = false;

		[JsonPropertyName("tag_list")]
		public string[] Tags { get; set; } = new string[0];

		[JsonPropertyName("reading_time_minutes")]
		public int ReadingTime { get; set; } = 0;

		[JsonPropertyName("positive_reactions_count")]
		public int Likes { get; set; } = 0;

	}
}


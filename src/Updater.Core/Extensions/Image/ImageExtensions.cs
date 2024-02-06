using System;
using System.Text;

namespace Updater.Core.Extensions
{
	public static class ImageExtensions
	{
		public static ProfileBuilder AddImage(this ProfileBuilder builder,
			Action<ImageOptions> configuration)
		{
			ImageOptions options = new();
			configuration(options);


			return builder.AddRawSection(
				options.ToHtml());
		}

		internal static StringBuilder AppendLineOrOmit(
			this StringBuilder builder, string? value,
			Func<string, string>? formattedValue = null)
		{

			formattedValue ??= s => s;

			if (string.IsNullOrWhiteSpace(value))
				return builder;
			return builder.AppendLine(formattedValue(value));
		}
	}
}


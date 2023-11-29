using System;
namespace Updater.Core.Extensions
{
	public static class FileExtensions
	{
		public async static Task PublishToFileAsync(this ProfileBuilder builder,
			string path, CancellationToken cancellationToken = default)
		
		{
			await File.WriteAllTextAsync(path, builder.BuildString(),
				cancellationToken);
		}

		private static string BuildString(this ProfileBuilder builder) =>
			builder.Build().
				ToString();
	}
}


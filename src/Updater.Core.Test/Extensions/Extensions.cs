using System;
namespace Updater.Core.Test.Extensions
{
	public static class Extensions
	{
		public static bool Contains(this Profile profile, string substring) {

			var markdown = profile.ToString();
			return string.IsNullOrWhiteSpace(markdown) == false &&
				markdown.Contains(substring);
		}
	}
}


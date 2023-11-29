using System;
using System.Net.Http;

namespace Updater.Core.Extensions
{
	public static class HttpExtensions
	{
		public static ProfileBuilder
			AddSectionFromUrl(this ProfileBuilder builder,
			string url)
		{
			var task = builder.Services.
				HttpGet(url);
			  
			return builder.AddFromHttpTask(task);
		}

		private static ProfileBuilder AddFromHttpTask(
			this ProfileBuilder builder, Task<string> task)
		{
			return builder.AddRawSection(task.Result);
		}

	}		
}
using System;

namespace Updater.Core.Extensions
{
	public static class SectionProviderExtensions
	{

        public static ProfileBuilder
            AddSectionProvider(this ProfileBuilder builder,
            ISectionProvider provider) =>
                builder.AddSection(provider.Title, provider.Content);
    }
}


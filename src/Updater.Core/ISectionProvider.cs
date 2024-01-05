using System;
namespace Updater.Core
{
	public interface ISectionProvider
	{
		string Content { get; }

		string Title { get; }

	}
}


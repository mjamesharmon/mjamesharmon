using System;
namespace Updater.Core.Test.Extensions
{
	public class RemoveAfterTestData :
		TheoryData<DateTime,DateTime,bool>
	{
		public RemoveAfterTestData()
		{
			DateTime now = DateTime.UtcNow;

			Add(now, now.AddDays(1), true);
			Add(now, now, false);
			Add(now, now.AddDays(-1), false);

		}
	}
}


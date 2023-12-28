using System;
namespace Updater.Core.Test.Extensions
{
	public class RepeatYearlyTestData :
		TheoryData<DateTime,DateTime,DateTime,bool>
	{
		public RepeatYearlyTestData()
		{
			DateTime now = DateTime.UtcNow;

			Add(now, now.AddDays(-1), now.AddDays(1), true);
			Add(now, now.AddDays(-2), now.AddDays(-1), false);
			Add(now.AddYears(1), now.AddDays(-1), now.AddDays(1), true);
			Add(now.AddDays(1), now.AddDays(-1), now.AddDays(1), false);
		}
	}
}


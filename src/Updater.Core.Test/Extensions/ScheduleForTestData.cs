
using System;
namespace Updater.Core.Test.Extensions
{
	public class ScheduleForTestData
		: TheoryData<DateTime,DateTime,DateTime,bool>
		{
		public ScheduleForTestData()
		{
			DateTime now = DateTime.UtcNow;

			Add(now, now.AddDays(-1), now.AddDays(1), true);
			Add(now, now, now.AddDays(1), true);
			Add(now, now, now, false);
			Add(now, now.AddDays(1), now, false);
			Add(now, now.AddDays(1), now.AddDays(2), false);
			Add(now, now.AddDays(-1), now.AddDays(-2), false);
				
		}
	}
}


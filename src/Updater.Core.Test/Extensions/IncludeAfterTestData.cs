using System;
namespace Updater.Core.Test.Extensions
{
	public class IncludeAfterTestData : TheoryData<DateTime,DateTime,bool>
	{
		public IncludeAfterTestData() {

			var now = DateTime.UtcNow;

			Add(now, now.AddDays(-1), true);
			Add(now, now.AddDays(1), false);
			Add(now, now, true);
		}
	}
}


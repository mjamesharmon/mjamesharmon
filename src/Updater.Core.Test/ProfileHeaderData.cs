using System;
namespace Updater.Core.Test
{
	public class ProfileHeaderData : TheoryData<string,string,string>
	{
		public ProfileHeaderData()
		{
			Add("title", string.Empty,
				$"# title{Environment.NewLine}{Environment.NewLine}");
			Add("title", "description here!",
				$"# title{Environment.NewLine}" +
				$"description here!{Environment.NewLine}");
        }
	}
}


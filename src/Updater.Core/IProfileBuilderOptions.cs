using System;
namespace Updater.Core
{
	public interface IProfileBuilderOptions
	{
		IProfileBuilderOptions UseHttp(HttpClient? client = default);
	}
}


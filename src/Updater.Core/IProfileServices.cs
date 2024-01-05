using System;
namespace Updater.Core
{
    internal interface IProfileServices
    {
        Task<string> HttpGet(string url);

        Task<string> HttpSend(HttpRequestMessage request);

        Task AwaitSetupTasks();
    }      
}


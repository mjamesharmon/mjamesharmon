using Updater.Application;
using Updater.Core;
using Updater.Core.Extensions;
using Microsoft.Extensions.Configuration;

await Profile.Configure(options => options.
   UseHttp().
   EnableScheduling().
   EnableConfiguration(config => config.
    AddEnvironmentVariables())).

   // primary content
   AddImage(ProfileSettings.HeaderImage, ProfileSettings.HeaderImageAlt).
   PublishToFileAsync(args[0]);


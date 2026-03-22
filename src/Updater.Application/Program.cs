using Updater.Application;
using Updater.Core;
using Updater.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Updater.Core.SectionProviders;


await Profile.Configure(options => options.
   UseHttp().
   EnableScheduling().
   EnableConfiguration(config => config.
    AddEnvironmentVariables())).

   // primary content
   AddImage(ProfileSettings.HeaderImage, ProfileSettings.HeaderImageAlt).
   AddLatestFromDevTo(3,ProfileSettings.DevToProfile).
   PublishToFileAsync(args[0]);


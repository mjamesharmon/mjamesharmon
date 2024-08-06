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

   // christmas content section
   RepeatYearly(ProfileSettings.ChristmasContentStart,
       ProfileSettings.ChristmasContentEnd, profile => profile.
        AddSection("Countdown Calendar").
        AddSectionFromUrl(ProfileSettings.JulekalenderPath).
        AddSection("Wham Watchdog report").
        AddSectionFromUrl(ProfileSettings.WhamWatchdogPath)).

    // new years content section
    RepeatYearly(ProfileSettings.NewYearsStart, ProfileSettings.NewYearsEnd,
        profile => profile.AddSection(
            $"🎊 HAPPY NEW YEAR 🎊 {DateTime.UtcNow.Year} 🥳")).

   PublishToFileAsync(args[0]);


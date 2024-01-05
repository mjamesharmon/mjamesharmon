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
   AddImage(ProfileSettings.HeaderImage, ProfileSettings.HeaderImageAlt).
   AddLatestFromDevTo(2).
     RepeatYearly(ProfileSettings.ChristmasContentStart,
       ProfileSettings.ChristmasContentEnd, profile => profile.
        AddSection("Countdown Calendar").
        AddSectionFromUrl(ProfileSettings.JulekalenderPath).
        AddSection("Wham Watchdog report").
        AddSectionFromUrl(ProfileSettings.WhamWatchdogPath)).

    RepeatYearly(ProfileSettings.NewYearsStart, ProfileSettings.NewYearsEnd,
        profile => profile.AddSection(
            $"🎊 HAPPY NEW YEAR 🎊 {DateTime.UtcNow.Year} 🥳")).
   PublishToFileAsync(args[0]);


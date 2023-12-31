using Updater.Application;
using Updater.Core;
using Updater.Core.Extensions;


await Profile.Configure(options => options.
   UseHttp().
   EnableScheduling()).
   AddImage(ProfileSettings.HeaderImage, ProfileSettings.HeaderImageAlt).
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


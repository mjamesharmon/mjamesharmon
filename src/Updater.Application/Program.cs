using Updater.Application;
using Updater.Core;
using Updater.Core.Extensions;


await Profile.Configure(options => options.
   UseHttp().
   EnableScheduling()).
   AddImage(ProfileSettings.HeaderImage, ProfileSettings.HeaderImageAlt).
   AddHeader("Welcome", "I started coding when I was around 10 years old " +
     "and I'm still not bored with it. For December, check back to follow" +
     " the countdown calendar for seasonal vids and of course be sure to " +
     "keep" +
     " up with the Wham Watchdog report to see when " +
     "'Last Christmas' tops the charts :)").
    RemoveAfter(ProfileSettings.ChristmasContentStart,profile => profile.
        AddSection("Countdown Calendar").
        AddSectionFromUrl(ProfileSettings.JulekalenderPath).
        AddSection("Wham Watchdog report").
        AddSectionFromUrl(ProfileSettings.WhamWatchdogPath)).
   PublishToFileAsync(args[0]);


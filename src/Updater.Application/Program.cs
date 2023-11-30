using Updater.Core;
using Updater.Core.Extensions;


await Profile.Configure(options =>
   options.UseHttp()).
   AddImage(
    "https://github.com/mjamesharmon/mjamesharmon/blob/main/assets/img/hello.jpg?raw=true",
    "Hello").
   AddHeader("Welcome", "I started coding when I was around 10 years old " +
     "and I'm still not bored with it.For December, check back to follow" +
     " the countdown calendar for seasonal vids and of course be sure to " +
     "keep up with the Wham Watchdog report to see when " +
     "'Last Christmas' tops the charts :)").
   AddSection("Countdown Calendar").
   AddSectionFromUrl(
   "https://mjamesharmon.github.io/julekalender/julekalender.md").
   AddSection("Wham Watchdog report").
   AddSectionFromUrl(
     "https://mjamesharmon.github.io/wham-watchdog/rankings.md").
    PublishToFileAsync(args[0]);


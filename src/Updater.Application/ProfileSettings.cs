﻿using System;
using static System.Net.WebRequestMethods;

namespace Updater.Application
{
	public class ProfileSettings
    {
        public const string ImageDirectory =
            "https://github.com/mjamesharmon/mjamesharmon/blob/main/assets/img/";

        public const string HeaderImage =
            $"{ImageDirectory}hello.jpg?raw=true";

        public const string HeaderImageAlt = "Hello!";

        public const string GitHubServicesPath =
            "https://mjamesharmon.github.io/";

        public const string JulekalenderPath =
            $"{GitHubServicesPath}julekalender/julekalender.md";

        public const string WhamWatchdogPath =
             $"{GitHubServicesPath}wham-watchdog/rankings.md";

        public static DateTime ChristmasContentStart =>
            new DateTime(2023, 11, 25, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ChristmasContentEnd =>
            new DateTime(2023, 12, 31, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime NewYearsStart =>
            new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime NewYearsEnd =>
            NewYearsStart.AddDays(6);

    }
}

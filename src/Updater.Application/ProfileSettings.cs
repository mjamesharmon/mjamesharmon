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

    }
}

using System;
using Updater.Core.Extensions;

namespace Updater.Core.Test.Extensions
{
    public class ScheduledSectionTests
    {

        [Fact]
        public void TestRepeatYearly_NotConfigured_ThrowsException()
        {
            var profile = Profile.Configure();

            Assert.Throws<InvalidOperationException>(() =>
                profile.RepeatYearly(DateTime.MinValue,
                DateTime.MinValue.AddDays(4),
                p => p.
                    AddSection("hello world")));
        }


        [Fact]
        public void TestIncludeAfter_NotConfigured_ThrowsException()
        {
            var profile = Profile.Configure();

            Assert.Throws<InvalidOperationException>(() =>
                profile.IncludeAfter(DateTime.MinValue, p => p.
                    AddSection("hello world")));
        }

        [Fact]
        public void TestRemoveAfter_NotConfigured_ThrowsException()
        {

            var profile = Profile.Configure();

            Assert.Throws<InvalidOperationException>(() =>
                profile.RemoveAfter(DateTime.MinValue, p => p.
                    AddSection("hello world")));
        }

        [Fact]
        public void TestScheduleFor_NotConfigured_ThrowsException()
        {

            var profile = Profile.Configure();

            Assert.Throws<InvalidOperationException>(() =>
                profile.ScheduleFor(DateTime.MinValue, DateTime.MaxValue,
                p => p.AddSection("hello world")));
        }
    }
}


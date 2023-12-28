using System;
using Updater.Core.Extensions;

namespace Updater.Core.Test.Extensions
{
    public class ScheduledSectionTests
    {
        private const string SectionData = "hello world";

        [Fact]
        public void TestRepeatYearly_NotConfigured_ThrowsException()
        {
            var profile = Profile.Configure();

            Assert.Throws<InvalidOperationException>(() =>
                profile.RepeatYearly(DateTime.MinValue,
                DateTime.MinValue.AddDays(4),
                p => p.
                    AddSection(SectionData)));
        }


        [Fact]
        public void TestIncludeAfter_NotConfigured_ThrowsException()
        {
            var profile = Profile.Configure();

            Assert.Throws<InvalidOperationException>(() =>
                profile.IncludeAfter(DateTime.MinValue, p => p.
                    AddSection(SectionData)));
        }

        [Fact]
        public void TestRemoveAfter_NotConfigured_ThrowsException()
        {

            var profile = Profile.Configure();

            Assert.Throws<InvalidOperationException>(() =>
                profile.RemoveAfter(DateTime.MinValue, p => p.
                    AddSection(SectionData)));
        }

        [Fact]
        public void TestScheduleFor_NotConfigured_ThrowsException()
        {

            var profile = Profile.Configure();

            Assert.Throws<InvalidOperationException>(() =>
                profile.ScheduleFor(DateTime.MinValue, DateTime.MaxValue,
                p => p.AddSection(SectionData)));
        }

        [Theory]
        [ClassData(typeof(RepeatYearlyTestData))]
        public void TestRepeatYearly_Valid_Ok(DateTime now, DateTime start,
            DateTime end, bool isValid)
        {

            var profile = Profile.Configure(options => options.
                EnableScheduling(now)).
                RepeatYearly(start, end, p => p.AddSection(SectionData)).
                Build();

            Assert.NotNull(profile);
            Assert.Equal(isValid, profile.Contains(SectionData));
        }

        [Theory]
        [ClassData(typeof(IncludeAfterTestData))]
        public void TestIncludeAfter_Valid_Ok(DateTime now, DateTime start,
            bool isValid) {

            var profile = Profile.Configure(options => options.
                EnableScheduling(now)).
                IncludeAfter(start, p => p.AddSection(SectionData)).
                Build();

            Assert.NotNull(profile);
            Assert.Equal(isValid, profile.Contains(SectionData));     
        }

        [Theory]
        [ClassData(typeof(RemoveAfterTestData))]
        public void TestRemoveAfter_Valid_Ok(DateTime now, DateTime start,
            bool isValid)
        {

            var profile = Profile.Configure(options => options.
                EnableScheduling(now)).
                RemoveAfter(start, p => p.AddSection(SectionData)).
                Build();

            Assert.NotNull(profile);
            Assert.Equal(isValid, profile.Contains(SectionData));
        }

        [Theory]
        [ClassData(typeof(ScheduleForTestData))]
        public void TestScheduleFor_Valid_Ok(DateTime now, DateTime start,
            DateTime end, bool isValid)
        {

            var profile = Profile.Configure(options => options.
                EnableScheduling(now)).
                ScheduleFor(start, end, p => p.AddSection(SectionData)).
                Build();

            Assert.NotNull(profile);
            Assert.Equal(isValid, profile.Contains(SectionData));
        }
    }
}


using System;
namespace Updater.Core.Extensions
{
	public static class ScheduledSectionExtensions
	{
		private static DateTime? _currentTimeUTC { get; set; } = null;

		private static DateTime CurrentTimeUtc =>
			_currentTimeUTC ??
			throw new InvalidOperationException(NotConfiguredException);

		private static readonly string NotConfiguredException =
			"Scheduling services have not been enabled";

		public static ProfileBuilder IncludeAfter(
			this ProfileBuilder builder, DateTime startDate,
			Func<ProfileBuilder,ProfileBuilder> configuration)
		{
			return builder.Services.
				Schedule(() => configuration(builder), startDate) ?? builder;
		}

		public static ProfileBuilder RemoveAfter(
			this ProfileBuilder builder, DateTime endDate,
			Func<ProfileBuilder,ProfileBuilder> configuration)
		{
			return builder.Services.
				Schedule(() => configuration(builder),
				DateTime.MinValue, endDate) ?? builder;
		}

        public static IProfileBuilderOptions EnableScheduling(
        this IProfileBuilderOptions options, DateTime? now = null)
        {
            _currentTimeUTC = now ?? DateTime.UtcNow;
            return options;
        }


        private static ProfileBuilder? Schedule(this IProfileServices services,
			Func<ProfileBuilder> configuration, DateTime start,
			DateTime? end = null)
		{
			DateTime currentTime = _currentTimeUTC ??
				throw new InvalidOperationException(NotConfiguredException);
			end ??= DateTime.MaxValue;

			return (IsActive(start) &&
				HasNotExpired(end.Value) &&
				IsValid(start, end.Value)) ?
				configuration() : null;		
		}

		private static bool IsActive(DateTime start) =>
			start <= CurrentTimeUtc;

		private static bool HasNotExpired(DateTime end) =>
			end > CurrentTimeUtc;

		private static bool IsValid(DateTime start, DateTime end) =>
			start <= end
			;
		


	}
}


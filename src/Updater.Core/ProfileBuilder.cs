using System;
using System.Text;

namespace Updater.Core
{
	public class ProfileBuilder
	{
		private List<Action<StringBuilder>> _buildPlan =
			new List<Action<StringBuilder>>();

		private List<Action> _serviceActions =
			new List<Action>();

		private ProfileBuilderOptions _options = new ProfileBuilderOptions();

		internal ProfileBuilder(
			Action<IProfileBuilderOptions>? optionsConfigurator = default) {

			optionsConfigurator ??= (o) => { };
			optionsConfigurator(_options);
		}

		private ProfileBuilder(ProfileBuilderOptions options,
			IEnumerable<Action<StringBuilder>> plan) {
			_buildPlan = new List<Action<StringBuilder>>(plan);
			_options = options;
		}

		public ProfileBuilder AddHeader(string title,
			string description="") {

			_buildPlan.Add((builder) =>
			{
				builder.AppendLine($"# {title}");
				builder.AppendLine(PlainTextOrSkip(description));
			});

			return new ProfileBuilder(_options,_buildPlan);
		}

		public ProfileBuilder AddRawSection(string raw) {

			_buildPlan.Add((builder) =>
			{
				builder.AppendLine(raw);
			});
            return new ProfileBuilder(_options, _buildPlan);
        }

        public ProfileBuilder AddSection(string title,
            string description = "")
        {

            _buildPlan.Add((builder) =>
            {
                builder.AppendLine($"## {title}");
                builder.AppendLine(PlainTextOrSkip(description));
            });

            return new ProfileBuilder(_options,_buildPlan);
        }

		public Profile Build() {
			_options.AwaitAllServiceTasks().
				Wait();

			return new Profile(ExecuteBuildPlan()); 
		 }

		internal ProfileBuilderOptions Services => _options;


		private StringBuilder ExecuteBuildPlan() =>
			_buildPlan.Aggregate(new StringBuilder(),
				(builder, action) =>
				{
					action(builder);
					return builder;
				});

		private string PlainTextOrSkip(string description) =>
			(string.IsNullOrWhiteSpace(description)) ?
				string.Empty : $"{description}";

	}
}


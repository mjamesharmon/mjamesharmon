using System;
using System.Text;

namespace Updater.Core
{
	public class ProfileBuilder
	{
		private List<Action<StringBuilder>> _buildPlan = new();
		private IProfileServices _services;

		internal ProfileBuilder(
			Action<IProfileBuilderOptions>? optionsConfigurator = default) {

			ProfileBuilderConfiguration options = new();
			optionsConfigurator ??= (o) => { };
			optionsConfigurator(options);
			_services = options;
		}

		private ProfileBuilder(IProfileServices services,
			IEnumerable<Action<StringBuilder>> plan) {
			_buildPlan = new List<Action<StringBuilder>>(plan);
			_services = services;
		}

		public ProfileBuilder AddImage(string url, string text) {

			_buildPlan.Add((builder) =>
			{
				builder.AppendLine($"![{text}]({url})");
			});
			return new ProfileBuilder(_services, _buildPlan);
		}

		public ProfileBuilder AddHeader(string title,
			string description="") {

			_buildPlan.Add((builder) =>
			{
				builder.AppendLine($"# {title}");
				builder.AppendLine(PlainTextOrSkip(description));
			});

			return new ProfileBuilder(_services,_buildPlan);
		}

		public ProfileBuilder AddRawSection(string raw) {

			_buildPlan.Add((builder) =>
			{
				builder.AppendLine(raw);
			});
            return new ProfileBuilder(_services, _buildPlan);
        }

        public ProfileBuilder AddSection(string title,
            string description = "")
        {

            _buildPlan.Add((builder) =>
            {
                builder.AppendLine($"## {title}");
                builder.AppendLine(PlainTextOrSkip(description));
            });

            return new ProfileBuilder(_services,_buildPlan);
        }

		public Profile Build() {
			_services.AwaitSetupTasks().
				Wait();
			
			return new Profile(ExecuteBuildPlan()); 
		 }

		internal IProfileServices Services => _services;


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


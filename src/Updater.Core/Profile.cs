using System.Text;

namespace Updater.Core;
public class Profile
{
    private StringBuilder? _builder;

    public static ProfileBuilder Configure(
        Action<IProfileBuilderOptions>? options = default) =>
        new ProfileBuilder(options);

    internal Profile(StringBuilder markdownBuilder) {
        _builder = markdownBuilder;
    }

    public override string ToString() =>
        (_builder == null) ? string.Empty : _builder.ToString();
    
}

namespace Updater.Core.Test;

public class ProfileTests
{
    [Theory]
    [ClassData(typeof(ProfileHeaderData))]
    public void TestAddHeader_ValidData_Ok(string title,
        string description, string expected)
    {
        var profile =  Profile.Configure().
           AddHeader(title,description).
           Build();

        Assert.NotNull(profile);
        Assert.Equal(expected, profile.ToString());
    }

    [Theory]
    [ClassData(typeof(ProfileSectionData))]
    public void TestAddSection_ValidData_Ok(string title,
        string body, string expected)
    {
        var profile = Profile.Configure().
          AddSection(title, body).
          Build();

        Assert.NotNull(profile);
        Assert.Equal(expected, profile.ToString());

    }
}
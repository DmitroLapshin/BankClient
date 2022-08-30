using BankClient;
using FluentAssertions;
using Xunit;

public class GetAllUsersInformation
{
    [Theory]
    [MemberData(nameof(TestParamsForFunctionOptionality))]
    public void GetAllUserInformation_Optionality(UserInformation inputUser, int expectedFilterCount)
    {
        var methodResult = new Bank().GetAllUsersInformation(inputUser);
        Assert.Equal(expectedFilterCount,methodResult.Count);
        
    }

    [Fact]
    public void GetAllUserInformation_EmptyString()
    {
        var methodResult =  new Bank().GetAllUsersInformation(new UserInformation("","",""));
        methodResult.Should().BeNull();
    }
    
    public static IEnumerable<object[]> TestParamsForFunctionOptionality = new List<object[]>
    {
        new object[] { new UserInformation("Dima", "", ""), 1 },
        new object[] { new UserInformation("", "Lapshin", ""), 2 },
        new object[] { new UserInformation("", "", "1234"), 2 },
        new object[] { new UserInformation("Test", "Test", "Test"), 0 },
    };
    
    
}



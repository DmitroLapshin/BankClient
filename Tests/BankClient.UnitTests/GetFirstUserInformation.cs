using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace BankClient.UnitTests;

public class GetFirstUserInformation
{
    [Theory]
    [MemberData(nameof(TestParamsForFunctionOptionality))]
    public void GetFirstUsersInformation_Optionality_True(UserInformation inputUser)
    {
        var methodResult = new Bank().GetFirstUserInformation(inputUser);
        var expected = new UserInformation("Dima", "Lapshin", "1234");
        methodResult.Id = expected.Id;
        methodResult.Should().BeEquivalentTo(expected);

    }

    [Fact]
    public void GetFirstUsersInformation_CheckEmptyString()
    {
        var methodResult = new Bank().GetFirstUserInformation(new UserInformation("","",""));
        Assert.Null(methodResult);

    }

    public static IEnumerable<object[]> TestParamsForFunctionOptionality = new List<object[]>
    {
        new object[] { new UserInformation("Dima", "", "") },
        new object[] { new UserInformation("", "Lapshin", "") },
        new object[] { new UserInformation("", "", "1234") }
    };
}
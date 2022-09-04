using FluentAssertions;
using Xunit;

namespace BankClient.UnitTests;

public class GetAllUsersInformation
{
    [Theory]
    [InlineData("Dima", "", "", 1)]
    [InlineData("", "Lapshin", "", 2)]
    [InlineData("", "", "1234", 2)]
    [InlineData("Test", "Test", "Test", 0)]
    public void GetAllUserInformation_Optionality(string firstName, string lastName, string phoneNumber, int expectedFilterCount)
    {
        var userInformation = new UserInformation(firstName, lastName, phoneNumber);
        
        var result = new Bank().GetAllUserInformations(userInformation);
        result.Count.Should().Be(expectedFilterCount);
    }

    [Fact]
    public void GetAllUserInformation_EmptyString()
    {
        var methodResult = new Bank().GetAllUserInformations(new UserInformation("","",""));
        methodResult.Count.Should().Be(2);
    }
}
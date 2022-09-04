using FluentAssertions;
using Xunit;

namespace BankClient.UnitTests;

public class AddUserInformation
{
    [Fact]
    public void AddUserInformation_ShouldAddUserInformation()
    {
        // Arrange
        var bank = new Bank();
        var testValue = new UserInformation("TestName", "TestLastname", "TestPhonenumber");
        
        // Act
        var methodResult = bank.AddUserInformation(testValue);
        
        // Assert
        methodResult.Should().BeEquivalentTo(bank.GetFirstUserInformation(testValue));
    }
}
using FluentAssertions;
using Xunit;

namespace BankClient.UnitTests;

public class ChangeUserInformation
{
    [Fact]
    public void ChangeUserInformation_ShouldChangeUserInformation_WhenUserFound()
    {
        // Arrange
        var bankVariable = new Bank();
        var userInformation = new UserInformation("Test", "Test", "Test");
        bankVariable.AddUserInformation(userInformation);

        var changedUserInformation = new UserInformation("TestName", "TestLastname", "TestPhonenumber")
        {
            Id = userInformation.Id
        };
        
        // Act
        bankVariable.ChangeUserInformation(changedUserInformation);
        
        // Assert
        bankVariable.GetUserById(changedUserInformation.Id).Should().Be(userInformation);

    }

    [Fact]
    public void ChangeUserInformation_ShouldIgnoreNullInput()
    {
        // Arrange
        var bankVariable = new Bank();
        var userInformation = new UserInformation("Test", "Test", "Test");
        bankVariable.AddUserInformation(userInformation);
        
        // Act
        bankVariable.ChangeUserInformation(null);
        
        // Assert
        bankVariable.GetUserById(userInformation.Id).Should().Be(userInformation);
    }
}
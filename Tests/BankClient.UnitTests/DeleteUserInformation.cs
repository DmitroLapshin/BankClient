using FluentAssertions;
using Xunit;

namespace BankClient.UnitTests;

public class DeleteUserInformation
{
    [Fact]
    public void DeleteUserInformation_ShouldDeleteUser_WhenUserIdCorrect()
    {
        // Arrange
        var bank = new Bank();
        var userInformation = new UserInformation("TestName", "TestLastname", "TestPhonenumber");
        bank.AddUserInformation(userInformation);
        
        // Act
        bank.DeleteUserInformation(userInformation.Id);
        
        // Assert
        bank.GetUserById(userInformation.Id).Should().BeNull();
    }
 
}
using BankClient;
using FluentAssertions;
using Xunit;
public class DeleteUserInformation
{
    [Fact]
    public void DeleteUserInformation_ShouldDeleteUser_WhenUserIdCorrect()
    {
        var bankVariable = new Bank();
        var testValue = new UserInformation("TestName", "TestLastname", "TestPhonenumber");
        bankVariable.AddUserInformation(testValue);
        bankVariable.DeleteUserInformation(testValue.Id);
        bankVariable.GetFirstUserInformation(testValue).Should().BeNull();
    }
 
}



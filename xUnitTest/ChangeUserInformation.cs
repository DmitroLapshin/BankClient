using BankClient;
using FluentAssertions;
using Xunit;

public class ChangeUserInformation
{
    [Theory]
    [MemberData(nameof(TestValues))]
    public void ChangeUserInformation_CheckFunctionIsCorrect(UserInformation inputUser)
    {
        var bankVariable = new Bank();
        var userInformation = new UserInformation("Test", "Test", "Test", Guid.Empty);
        bankVariable.AddUserInformation(userInformation);
        bankVariable.ChangeUserInformation(inputUser);
        bankVariable.GetFirstUserInformation(inputUser).Should().NotBeNull();

    }

    [Fact]
    public void ChangeUserInformation_CheckOnNull_EmptyObject()
    {
        var bankVariable = new Bank();
        var userInformation = new UserInformation("Test", "Test", "Test", Guid.Empty);
        bankVariable.AddUserInformation(userInformation);
        bankVariable.ChangeUserInformation(null);
        bankVariable.GetFirstUserInformation(userInformation).Should().NotBeNull();
    }
    
    public static IEnumerable<object[]> TestValues = new List<object[]>
    {
        new object[] { new UserInformation("TestName", "TestLastname", "TestPhonenumber", Guid.Empty) }
    };
    
}
using BankClient;
using FluentAssertions;
using Xunit;



public class AddUserInformation
{
    [Fact]
    void AddUserInformationTest_CheckFunctonIsCorrect()
    {
        var bankVariable = new Bank();
        var testValue = new UserInformation("TestName", "TestLastname", "TestPhonenumber");
        var methodResult = bankVariable.AddUserInformation(testValue);
        methodResult.Should().BeEquivalentTo(bankVariable.GetFirstUserInformation(testValue));
    }

  
    
}
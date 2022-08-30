using BankClient;
using FluentAssertions;
using Xunit;

public class GetUserById
{
    [Fact]
    public void GetUserById_EmptyGuid()
    {
        var methodResult = new Bank().GetUserById(Guid.Empty);
        methodResult.Should().BeNull();
    }
}
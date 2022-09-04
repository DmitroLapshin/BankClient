using System;
using FluentAssertions;
using Xunit;

namespace BankClient.UnitTests;

public class GetUserById
{
    [Fact]
    public void GetUserById_EmptyGuid()
    {
        var methodResult = new Bank().GetUserById(Guid.Empty);
        methodResult.Should().BeNull();
    }
}
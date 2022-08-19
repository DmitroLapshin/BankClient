using System;

namespace BankClient;

public class UserInformation
{
    public UserInformation()
    {
        Id = Guid.NewGuid();
    }
    public UserInformation(string firstName, string lastName, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Id = Guid.NewGuid();
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public Guid Id { get; set; }
 
  
}
using System;

namespace BankClient;

public class UserInformation
{

    public UserInformation()
    {
        
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
    public void Print()
    {
        Console.WriteLine(
            $" Firstname: {FirstName}, LastName: {LastName}, PhoneNumber: {PhoneNumber}, userID: {Id}");
    }
    public UserInformation GetInformationFromUser()
    {
        Console.WriteLine("Firstname: ");
        var firstName = Console.ReadLine();
        firstName = firstName.Trim();
        Console.WriteLine("Lastname: ");
        var lastName = Console.ReadLine();
        lastName = lastName.Trim();
        Console.WriteLine("PhoneNumber: ");
        var phoneNumber = Console.ReadLine();
        phoneNumber = phoneNumber.Trim();
        var saveDataToClass = new UserInformation(firstName, lastName, phoneNumber);
        return saveDataToClass;
    }
}
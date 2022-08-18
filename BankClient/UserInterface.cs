namespace BankClient;

public static class UserInterface
{
    public static UserInformation GetInformationFromUser()
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
        var userInformation = new UserInformation(firstName, lastName, phoneNumber);
        return userInformation;
    }

    public static Guid UserEnterId()
    {
        Console.WriteLine("Enter Id: ");
        var id = Console.ReadLine();
        Guid.TryParse(id, out var guidId);
        return guidId;
    }
    
    
}
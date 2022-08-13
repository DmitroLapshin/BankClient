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
        var saveDataToClass = new UserInformation(firstName, lastName, phoneNumber);
        return saveDataToClass;
    }

    public static Guid UserEnterId()
    {
        Console.WriteLine("Enter Id: ");
        var id = Console.ReadLine();
        return Guid.Parse(id);
    }
    
    
}
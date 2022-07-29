namespace BankClient;

public class UserInformation
{
    public UserInformation()
    {
        Console.WriteLine("Firstname: ");
        FirstName = Console.ReadLine();
        Console.WriteLine("Lastname: ");
        LastName = Console.ReadLine();
        Console.WriteLine("Phonenumber: ");
        Phonenumber = Console.ReadLine();
        ID = Guid.NewGuid();
        Console.WriteLine("The client was added");
    }

    public UserInformation(string firstName, string lastName, string phonenumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Phonenumber = phonenumber;
        ID = Guid.NewGuid();
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phonenumber { get; set; }
    public Guid ID { get; set; }
}
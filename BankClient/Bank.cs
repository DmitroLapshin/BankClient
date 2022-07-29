namespace BankClient;

public class Bank
{
    private void menu()
    {
        Console.WriteLine("-------Menu-------");
        Console.WriteLine("Enter 1 to add client\nEnter 2 to delete client\nEnter 3 to show list of users\nEnter 4 to search one user\nEnter 5 to search group of user\nEnter 6 to change user information");
        Console.WriteLine("----------gigMenu ends----------");
        Console.Write("Choose action: ");
    }

    private List<UserInformation> SearchUsersInformation()
    {
        Console.WriteLine("Example:Dmitry,Lapshin,0950095521");
        Console.Write("Fiter: ");
        var userfilter = Console.ReadLine().Split(',');
        foreach (var param in userfilter)
        {
            param.Trim();
        }

        if (userfilter[0] == "" && userfilter.Length == 1)
        {
            ShowAllUsers();
        }
        var filterlist = Users.Where(x => x.FirstName == userfilter[0] || x.LastName == userfilter[0] || x.Phonenumber== userfilter[0] || x.ID.ToString() == userfilter[0]).ToList();
        for (int i = 0; i < userfilter.Length; i++)
        {
            filterlist = filterlist.Where(x => x.FirstName == userfilter[i] || x.LastName == userfilter[i] || x.Phonenumber == userfilter[i] ||  x.ID.ToString() == userfilter[0]).ToList();
        }

        return filterlist;
    }

    public void GetAllUsersInformation(List<UserInformation> filterlist)
    {
        if (filterlist.Count == 0)
        {
            Console.WriteLine("Nobody was found");
            return;
        }
        Console.WriteLine($"There was(were) found {filterlist.Count} users:");
        foreach (var user in filterlist)
        {
            Console.WriteLine(
                $"Firstname: {user.FirstName}, LastName: {user.LastName}, Phonenumber: {user.Phonenumber}, userID: {user.ID}");
        }
    }

    public void GetOneUserInformation(List<UserInformation> filterlist)
    {
        if (filterlist.Count == 0)
        {
            Console.WriteLine("Nobody was found");
            return;
        }
        Console.WriteLine($"Firstname: {filterlist[0].FirstName}, LastName: {filterlist[0].LastName}, Phonenumber: {filterlist[0].Phonenumber}, userID: {filterlist[0].ID}");
    }

    public void ShowAllUsers()
    {
        if (Users != null)
        {
            int i = 1;
            foreach (var user in Users)
            {
                Console.WriteLine(
                    $"User {i}: Firstname: {user.FirstName}, LastName: {user.LastName}, Phonenumber: {user.Phonenumber}, userID: {user.ID}");
                    i++;
            }
        }
        else
        {
            Console.WriteLine("There are not users in the list");
        }
    }
    public void ChangeUserInfomation()
    {
        Console.Write("Enter userID: ");
        var id = Console.ReadLine().Trim();
        bool flag = false;
        foreach (var user in Users)
        {
            if (user.ID.ToString() == id)
            {
                flag = true;
                Console.Write("Firstname: ");
                user.FirstName = Console.ReadLine();
                Console.Write("Lastname: ");
                user.LastName = Console.ReadLine();
                Console.Write("Phonenumber: ");
                user.Phonenumber = Console.ReadLine();
                Console.WriteLine("The client was changed");
                break;
            }
        }

        if (flag == false)
            Console.WriteLine("User wasn't found");
    }

    public void AddUserInformation()
    {
        Users.Add(new UserInformation());
    }

    public void DeleteUserInformation(List<UserInformation> filterlist)
    {
        if (filterlist.Count == 0)
        {
            Console.WriteLine("Nobody was found");
            return;
        }
        foreach (var user in filterlist)
        {
            Users.RemoveAll(x => x.ID == user.ID);
        }
        Console.WriteLine("The client was deleted");
    }

    public void Chooseaction()
    {
        // var person = new Bank();
        Users.Add(new UserInformation("Dmitry", "Lapshin", "0950095521"));
        Users.Add(new UserInformation("Dmitry", "Lapshin", "0955735689"));
        Users.Add(new UserInformation("Testname", "Testsurname", "Testnumber"));
        menu();
        var choseeaction = Console.ReadLine().ToUpper();
        while (true)
        {
            
            switch (choseeaction)
            {
                case "1":
                    AddUserInformation();
                    break;
                case "2":
                    DeleteUserInformation(SearchUsersInformation());
                    break;
                case "3":
                    ShowAllUsers();
                    break;
                case "4":
                    GetOneUserInformation(SearchUsersInformation());
                    break;
                case "5":
                    GetAllUsersInformation(SearchUsersInformation());
                    break;
                case "6":
                    ChangeUserInfomation();
                    break;
                case "EXIT":
                    Console.WriteLine("Program is finished");
                    return;
                default:
                    Console.WriteLine("The input is incorrect, Try again");
                    break;
            }
            menu();
            choseeaction = Console.ReadLine().ToUpper();
        }
    }
    private List<UserInformation> Users = new ();
}
 
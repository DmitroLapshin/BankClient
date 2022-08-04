namespace BankClient;

public class Bank
{
    private List<UserInformation> Users = new List<UserInformation>()
    {
        new UserInformation("Dmitry", "Lapshin", "1234")
            {ID = Guid.NewGuid()},
        new UserInformation("Dima", "Lapshin", "1234")
            {ID = Guid.NewGuid()}
    };
    /// <summary>
    /// Get information from user
    /// </summary>
    /// <returns>Nothing</returns>
    public UserInformation GetInformationFromUser()
    {
        Console.WriteLine("Firstname: ");
        var firstName = Console.ReadLine();
        firstName.Trim();
        Console.WriteLine("Lastname: ");
        var lastName = Console.ReadLine();
        lastName.Trim();
        Console.WriteLine("PhoneNumber: ");
        var phoneNumber = Console.ReadLine();
        phoneNumber.Trim();
        var saveDataToClass = new UserInformation(firstName, lastName, phoneNumber);
        return saveDataToClass;
    }
    /// <summary>
    /// Function filters list of users which appropriate to inputUser
    /// </summary>
    /// <param name="inputUser">Takes information about client which user input</param>
    /// <returns>List of users which appropriate to input user</returns>
    public List<UserInformation> SearchUsersInformation(UserInformation inputUser)
    {
        var filterList = Users.Where(listUsers =>
            (listUsers.FirstName == inputUser.FirstName || inputUser.FirstName == "") &&
            (listUsers.LastName == inputUser.LastName || inputUser.LastName == "") &&
            (listUsers.PhoneNumber == inputUser.PhoneNumber || inputUser.PhoneNumber == "")).ToList();
        return filterList;
    }

    /// <summary>
    /// Function saves filterList and call function for print
    /// </summary>
    /// <param name="filterList"></param>
    /// <returns>groupOfUsers</returns>
    public List<UserInformation> GetAllUsersInformation(List<UserInformation> filterList)
    {
        var groupOfUsers = filterList;
        
        if (groupOfUsers != null)
        {
            
            ShowListOfUsers(groupOfUsers);
        }

        return groupOfUsers;
        
    }

    /// <summary>
    /// Gets one user
    /// </summary>
    /// <param name="filterList">Takes <see cref="UserInformation"/> list which contains all user information</param>
    /// <returns>Nothing</returns>

    public UserInformation GetOneUserInformation(List<UserInformation> filterList)
    {
        if (filterList != null)
        {
            var oneUserInformation = filterList[0];
            ShowOneUser(oneUserInformation);
            return oneUserInformation;
        }
        else
        {
            return null;
        }

    }
    /// <summary>
    /// Search user by ID
    /// </summary>
    /// <returns>Return user or null</returns>
    public UserInformation GetUserByID()
    {
        string id = Console.ReadLine();
        
        foreach (var user in Users)
        {
            if (user.ID.ToString() == id)
            {
                ShowOneUser(user);
                return user;
            }
        }

        return null;
    }

    /// <summary>
    /// Change user information
    /// </summary>
    /// <param name="inputUsers">Takes <see cref="UserInformation"/> object which has all user information</param>
    /// <returns>Nothing</returns>

    public void ChangeUserInfomation(List<UserInformation> inputUsers)
    {
        if (Users != null)
        {
            return;
        }

        for (int i = 0; i < Users.Count; i++)
        {
            for (int j = 0; j < inputUsers.Count; j++)
            {
                if (Users[i].ID.ToString() == inputUsers[j].ID.ToString())
                {
                    var changedUser = GetInformationFromUser();
                    changedUser.ID = new Guid();
                    Users[i] = changedUser;
                }

            }
        }
    }

    /// <summary>
    /// Add new user in the list
    /// </summary>
    /// <returns>Nothing</returns>

    public void AddUserInformation()
    {
        var newUser = GetInformationFromUser();
        newUser.ID = Guid.NewGuid();
        Users.Add(newUser);
    }

    /// <summary>
    /// Delete user in the list
    /// </summary>
    /// <returns>Nothing</returns>

    public void DeleteUserInformation(List<UserInformation> filterList)
    {
        if (filterList == null)
        {
            return;
        }

        foreach (var user in filterList)
        {
            Users.RemoveAll(x => x.ID == user.ID);
        }
    }

    /// <summary>
    /// Function prints list of users
    /// </summary>
    /// <returns>Nothing</returns>

    public void PrintAllUsers()
    {
        if (Users != null)
        {
            int i = 1;
            foreach (var user in Users)
            {
                Console.WriteLine(
                    $"User {i}: Firstname: {user.FirstName}, LastName: {user.LastName}, PhoneNumber: {user.PhoneNumber}, userID: {user.ID}");
                i++;
            }
        }
        else
        {
            Console.WriteLine("There are not users in the list");
        }
    }

    private void ShowOneUser(UserInformation oneUser)
    {
        Console.WriteLine(
            $" Firstname: {oneUser.FirstName}, LastName: {oneUser.LastName}, PhoneNumber: {oneUser.PhoneNumber}, userID: {oneUser.ID}");
    }
    /// <summary>
    /// Show "filterList" for method GetAllUserInformation <see cref="GetAllUsersInformation"/>
    /// </summary>
    private void ShowListOfUsers(List<UserInformation> listOfUsers)
    {
        foreach (var user in listOfUsers)
        {
            Console.WriteLine(
                $" Firstname: {user.FirstName}, LastName: {user.LastName}, PhoneNumber: {user.PhoneNumber}, userID: {user.ID}");
         
        }
    }

}

//     
 
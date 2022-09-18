
namespace BankClient;

public class Bank
{
    public Bank()
    {
        Users.Add(new UserInformation("Dima", "Lapshin", "1234"));
        Users.Add(new UserInformation("Dmitry", "Lapshin", "1234"));
    }

    private List<UserInformation> Users = new List<UserInformation>();

    /// <summary>
    /// Function saves filterList and call function for print
    /// </summary>
    /// <param name="inputUser">Takes <see cref="UserInformation"/> object for filter</param>
    /// <returns>Group of users which appropriate to all requirements</returns>
    public List<UserInformation> GetAllUserInformations(UserInformation inputUser)
    {
        var filterList = Users.Where(listUsers =>
            (listUsers.FirstName == inputUser.FirstName || string.IsNullOrEmpty(inputUser.FirstName)) &&
            (listUsers.LastName == inputUser.LastName || string.IsNullOrEmpty(inputUser.LastName)) &&
            (listUsers.PhoneNumber == inputUser.PhoneNumber || string.IsNullOrEmpty(inputUser.PhoneNumber))).ToList();
        
        return filterList;

    }

    /// <summary>
    /// Gets one user
    /// </summary>
    /// <param name="inputUser">Takes <see cref="UserInformation"/> object for filter</param>
    /// <returns>FirstUser which appropriate to all requirements</returns>
    public UserInformation GetFirstUserInformation(UserInformation inputUser)
    {
        if (string.IsNullOrEmpty(inputUser.FirstName) &&
            string.IsNullOrEmpty(inputUser.LastName) &&
            string.IsNullOrEmpty(inputUser.PhoneNumber))
        {
            return null;
        }
        
        var firstMatchedUserInformation = Users.FirstOrDefault(listUsers =>
            (listUsers.FirstName == inputUser.FirstName || string.IsNullOrEmpty(inputUser.FirstName)) &&
            (listUsers.LastName == inputUser.LastName || string.IsNullOrEmpty(inputUser.LastName)) &&
            (listUsers.PhoneNumber == inputUser.PhoneNumber || string.IsNullOrEmpty(inputUser.PhoneNumber)));

        return firstMatchedUserInformation;
    }

    /// <summary>
    /// Search user by ID
    /// </summary>
    /// <returns>Return user or null</returns>
    /// 
    public UserInformation GetUserById(Guid id)
    {
        var result = Users.FirstOrDefault(x => x.Id.ToString() == id.ToString());
        return result;
    }

    /// <summary>
    /// Change user information
    /// </summary>
    /// <param name="inputUser">Takes <see cref="UserInformation"/> object which has all user information</param>
    /// <returns>Nothing</returns>
    public void ChangeUserInformation(UserInformation inputUser)
    {
        if (inputUser != null)
        {
            var userInformation = Users.Find(x => x.Id == inputUser.Id);
            if (userInformation != null)
            {
                userInformation.FirstName = inputUser.FirstName;
                userInformation.LastName = inputUser.LastName;
                userInformation.PhoneNumber = inputUser.PhoneNumber;
            }    
        }
    }

    /// <summary>
    /// Add new user in the list
    /// </summary>
    /// <returns>New user</returns>
    public UserInformation AddUserInformation(UserInformation newUser)
    {
        if (newUser != null)
        {
            Users.Add(newUser);
        }
        return newUser;
    }

    /// <summary>
    /// Delete user in the list
    /// </summary>
    /// <returns>Nothing</returns>
    public void DeleteUserInformation(Guid id)
    {
        if (string.IsNullOrEmpty(id.ToString()) == false)
        {
            Users.Remove(Users.Find(x => x.Id == id));
        }

    }
}
 
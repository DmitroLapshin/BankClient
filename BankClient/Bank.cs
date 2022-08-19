using System;
using System.Collections.Generic;
using System.Linq;

namespace BankClient;

public class Bank
{
    public Bank()
    {
        Users.Add(new UserInformation("Dmitry", "Lapshin", "1234"));
        Users.Add(new UserInformation("Dima", "Lapshin", "1234"));
    }

    private List<UserInformation> Users = new List<UserInformation>();

    /// <summary>
    /// Function saves filterList and call function for print
    /// </summary>
    /// <param name="inputUser">Takes <see cref="UserInformation"/> object for filter</param>
    /// <returns>groupOfUsers</returns>
    public List<UserInformation> GetAllUsersInformation(UserInformation inputUser)
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
    /// <returns>Nothing</returns>
    public UserInformation GetFirstUserInformation(UserInformation inputUser)
    {
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
        var userInformation = GetUserById(inputUser.Id);
        if (userInformation != null)
        {
          userInformation.FirstName = inputUser.FirstName;
          userInformation.LastName= inputUser.LastName;
          userInformation.PhoneNumber= inputUser.PhoneNumber;
        }

    }

    /// <summary>
    /// Add new user in the list
    /// </summary>
    /// <returns>Nothing</returns>
    public UserInformation AddUserInformation(UserInformation newUser)
    {
        Users.Add(newUser);
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
 
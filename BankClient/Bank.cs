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
    /// Get information from user
    /// </summary>
    /// <returns>Nothing</returns>
   
    /// <summary>
    /// Function filters list of users which appropriate to inputUser
    /// </summary>
    /// <param name="inputUser">Takes information about client which user input</param>
    /// <returns>List of users which appropriate to input user</returns>
    private List<UserInformation> SearchUsersInformation(UserInformation inputUser)
    {  
        var filterList = Users.Where(listUsers =>
            (listUsers.FirstName == inputUser.FirstName || string.IsNullOrEmpty(inputUser.FirstName)) &&
            (listUsers.LastName == inputUser.LastName || string.IsNullOrEmpty(inputUser.LastName)) &&
            (listUsers.PhoneNumber == inputUser.PhoneNumber || string.IsNullOrEmpty(inputUser.PhoneNumber))).ToList();
        return filterList;
    }

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
        if (filterList.Count == 0)
        {
            return null;
        }
        ShowListOfUsers(filterList);
        return filterList;
    }

    /// <summary>
    /// Gets one user
    /// </summary>
    /// <param name="inputUser">Takes <see cref="UserInformation"/> object for filter</param>
    /// <returns>Nothing</returns>
    public UserInformation GetOneUserInformation(UserInformation inputUser)
    {
        var filterList = Users.Where(listUsers =>
            (listUsers.FirstName == inputUser.FirstName || string.IsNullOrEmpty(inputUser.FirstName)) &&
            (listUsers.LastName == inputUser.LastName || string.IsNullOrEmpty(inputUser.LastName)) &&
            (listUsers.PhoneNumber == inputUser.PhoneNumber || string.IsNullOrEmpty(inputUser.PhoneNumber))).ToList();
        
        if (filterList.Count != 0)
        {
            var oneUserInformation = filterList[0];
            oneUserInformation.Print();
            return oneUserInformation;
        }
        return null;

    }
    /// <summary>
    /// Search user by ID
    /// </summary>
    /// <returns>Return user or null</returns>
    /// 
    public UserInformation GetUserById()
    {
        string id = Console.ReadLine();
        var result = Users.FirstOrDefault(x => x.Id.ToString() == id);
        if (result != null)
        {
            result.Print();
        }
    
        return result;
    }

    /// <summary>
    /// Change user information
    /// </summary>
    /// <param name="inputUser">Takes <see cref="UserInformation"/> object which has all user information</param>
    /// <returns>Nothing</returns>
    public void ChangeUserInformation()
    {
        var id = Console.ReadLine().Trim();
        var changedUser = new UserInformation();
        for (var i = 0; i < Users.Count; i++)
        { 
            if (Users[i].Id.ToString() == id) 
            {  
                changedUser = changedUser.GetInformationFromUser();
                Users[i] = changedUser;
            }
        }
    }

    /// <summary>
    /// Add new user in the list
    /// </summary>
    /// <returns>Nothing</returns>
    public void AddUserInformation()
    {
        var newUser = new UserInformation();
        newUser = newUser.GetInformationFromUser();
        newUser.Id = Guid.NewGuid();
        Users.Add(newUser);
    }

    /// <summary>
    /// Delete user in the list
    /// </summary>
    /// <returns>Nothing</returns>
    public void DeleteUserInformation()
    {
        var id = Console.ReadLine().Trim();
        if (string.IsNullOrEmpty(id) == false)
        {
            Users.Remove(Users.Find(x => x.Id.ToString() == id));
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
                    $"User {i}: Firstname: {user.FirstName}, LastName: {user.LastName}, PhoneNumber: {user.PhoneNumber}, userID: {user.Id}");
                i++;
            }
        }
        else
        {
            Console.WriteLine("There are not users in the list");
        }
    }
    
    /// <summary>
    /// Show "filterList" for method GetAllUserInformation <see cref="GetAllUsersInformation"/>
    /// </summary>
    private void ShowListOfUsers(List<UserInformation> listOfUsers)
    {
        foreach (var user in listOfUsers)
        {
            Console.WriteLine(
                $" Firstname: {user.FirstName}, LastName: {user.LastName}, PhoneNumber: {user.PhoneNumber}, userID: {user.Id}");
         
        }
    }

}
 
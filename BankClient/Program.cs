
using System;
using BankClient;

var bank = new Bank();

Console.WriteLine("Add User");
bank.AddUserInformation(new UserInformation());

Console.WriteLine("Get information about one User");
bank.GetFirstUserInformation(UserInterface.GetInformationFromUser());

Console.WriteLine("Get information about Users");
bank.GetAllUsersInformation(UserInterface.GetInformationFromUser());

Console.WriteLine("Search user by ID");
bank.GetUserById(UserInterface.UserEnterId());

Console.WriteLine("Delete User, Enter Id");
bank.DeleteUserInformation(UserInterface.UserEnterId());

Console.WriteLine("Change user, Enter just Id");
bank.ChangeUserInformation(UserInterface.UserEnterId());



// See https://aka.ms/new-console-template for more information

using System;
using BankClient;

var bank = new Bank();
var userInformation = new UserInformation();
Console.WriteLine("Add User");
bank.AddUserInformation();
//bank.PrintAllUsers();

Console.WriteLine("Get information about one User");
bank.GetOneUserInformation(userInformation.GetInformationFromUser());

Console.WriteLine("Get information about Users");
bank.GetAllUsersInformation(userInformation.GetInformationFromUser());

Console.WriteLine("Search user by ID");
bank.GetUserById();

Console.WriteLine("Delete User, Enter Id");
bank.DeleteUserInformation();
//bank.PrintAllUsers();

Console.WriteLine("Change user, Enter just Id");
bank.ChangeUserInformation();
//// bank.PrintAllUsers();


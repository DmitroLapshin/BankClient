// See https://aka.ms/new-console-template for more information

using System;
using BankClient;

var _bank = new Bank();
var _userInformation = new UserInformation();
Console.WriteLine("Add User");
_bank.AddUserInformation();
_bank.PrintAllUsers();

Console.WriteLine("Get information about one User");
_bank.GetOneUserInformation(_userInformation.GetInformationFromUser());

Console.WriteLine("Get information about Users");
_bank.GetAllUsersInformation(_userInformation.GetInformationFromUser());

Console.WriteLine("Search user by ID");
_bank.GetUserById();

Console.WriteLine("Delete User, Enter Id");
_bank.DeleteUserInformation();
_bank.PrintAllUsers();

Console.WriteLine("Change user, Enter just Id");
_bank.ChangeUserInformation();
_bank.PrintAllUsers();

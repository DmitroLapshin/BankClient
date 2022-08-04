// See https://aka.ms/new-console-template for more information

using BankClient;

var test = new Bank();
Console.WriteLine("Add User");
test.AddUserInformation();
test.PrintAllUsers();

Console.WriteLine("Get information about one User");
test.GetOneUserInformation(test.SearchUsersInformation(test.GetInformationFromUser()));

Console.WriteLine("Get information about Users");
test.GetAllUsersInformation(test.SearchUsersInformation(test.GetInformationFromUser()));

Console.WriteLine("Search user by ID");
test.GetUserByID();

Console.WriteLine("Delete User");
test.DeleteUserInformation(test.SearchUsersInformation(test.GetInformationFromUser()));
test.PrintAllUsers();

Console.WriteLine("Change user");
test.ChangeUserInfomation(test.SearchUsersInformation(test.GetInformationFromUser()));
test.PrintAllUsers();

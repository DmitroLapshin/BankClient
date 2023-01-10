using BankClient;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();
Bank bank = new Bank();
string htmlPath = "HTML/mainPage.html";
string cssPath = "wwwroot/css/style.css";

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;
    
    if (path == "/api/users" && request.Method == "POST")
    {
        var user = await request.ReadFromJsonAsync<UserInformation>();
        bank.AddUserInformation(user);
        await response.WriteAsJsonAsync(bank.users);
    }
    else if (path == "/api/deleteusers" && request.Method == "POST")
    {
        var user = await request.ReadFromJsonAsync<UserInformation>();
        bank.DeleteUserInformation(user.Id, response);
        await response.WriteAsJsonAsync(bank.users);
    }
    
    else if (path == "/api/users" && request.Method == "PUT")
    {
        var user = await request.ReadFromJsonAsync<UserInformation>();
        bank.ChangeUserInformation(user, user.Id, response);
    }
    else if (path == "/api/users" && request.Method == "GET")
    {
        string? firstName = request.Query["firstName"];
        string? lastName = request.Query["lastName"];
        string? phoneNumber = request.Query["phoneNumber"];
        var user = new UserInformation(firstName,lastName,phoneNumber);
        var result = bank.GetAllUserInformation(user);
        await response.WriteAsJsonAsync(result);
    }
    else
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync(cssPath);
        await context.Response.SendFileAsync(htmlPath);
    }
});
app.Run();
 

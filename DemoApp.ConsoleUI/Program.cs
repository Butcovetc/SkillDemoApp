// See https://aka.ms/new-console-template for more information

using DemoApp.ConsoleUI;
using DemoApp.ConsoleUI.Facades;
using DemoApp.ConsoleUI.Models;
using Microsoft.Extensions.DependencyInjection;

InjectionFacade.ConfigureServiceProvider();

var accountService = InjectionFacade.ServiceProvider.GetRequiredService<AccountClient>();

var request = new ReqLogin
{
    Login = "Tester",
    Password = "TestPass"
};

var result = accountService.Login(request);


Console.WriteLine($"Authorization code:{result.Value.Error}");
Console.WriteLine($"Authorization code description:{result.Value.ErrorDescription}");




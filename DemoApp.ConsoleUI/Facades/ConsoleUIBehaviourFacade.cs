using DemoApp.ConsoleUI.Models;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.ConsoleUI.Facades
{
    internal class ConsoleUIBehaviourFacade
    {
        private AccountClient _accountService;

        private String? _token;

        public void Init()
        {
            InjectionFacade.ConfigureServiceProvider();
            _accountService = InjectionFacade.ServiceProvider.GetRequiredService<AccountClient>();
        }


        /// <summary>
        /// Allow user select action
        /// </summary>
        /// <returns>Selected action</returns>
        public String SelectAction() => AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What we are doing?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to change selection)[/]")
                    .AddChoices(new[] {
            SelectionConstants.Registration,
            SelectionConstants.Login,
            SelectionConstants.Check,
            SelectionConstants.Exit }));

        /// <summary>
        /// Perform login method
        /// </summary>
        /// <returns>Token</returns>
        public String? Login()
        {
            var login = AnsiConsole.Prompt(new TextPrompt<string>("Login:"));
            var password = AnsiConsole.Prompt(new TextPrompt<string>("Password:").Secret());

            try
            {
                var result = _accountService.Login(new ReqLogin { Login = login, Password = password });

                if (result.Value.Error == ErrorCodeEnum.One)
                {
                    AnsiConsole.MarkupLine($"[green]Authorization complete Successfully![/]");
                    AnsiConsole.MarkupLine($"[silver]Authorization token:{result.Value.Token}![/]");
                    _token = result.Value.Token;
                    return result.Value.Token;
                }
                else
                {
                    AnsiConsole.MarkupLine($"[red]Unfortantly authorisation failed :( Try again![/]");
                    AnsiConsole.MarkupLine($"[silver]{result.Value.ErrorDescription}[/]");

                    return null;
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Unfortantly authorisation failed :( Try again![/]");
                AnsiConsole.MarkupLine($"[silver]{ex.Message}[/]");
                return null;
            }
        }

        public void CheckDataBase()
        {
            if (String.IsNullOrEmpty(_token))
            {
                AnsiConsole.MarkupLine($"[red]You are not authorized to perform this action:( Try again![/]");
                return;
            }
            try
            {
                var result = _accountService.GetAllAccounts(new RequestTokenBased { Token = _token });

                if (result.Value.Error == ErrorCodeEnum.One)
                {
                    AnsiConsole.MarkupLine($"[green]Operation completed Successfully![/]");

                    var grid = new Grid();

                    // Add columns 
                    grid.AddColumn();
                    grid.AddColumn();
                    grid.AddColumn();
                    grid.AddRow(new string[] { "Login" , "Email" });

                    foreach (var item in result.Value.Items)
                        grid.AddRow(new string[] { item.Login, item.Email });
                    AnsiConsole.Write(grid);
                }
                else
                {
                    AnsiConsole.MarkupLine($"[red]Unfortantly registration failed :( Try again![/]");
                    AnsiConsole.MarkupLine($"[silver]{result.Value.ErrorDescription}[/]");
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Unfortantly registration failed :( Try again![/]");
                AnsiConsole.MarkupLine($"[silver]{ex.Message}[/]");
            }
            
        }

        /// <summary>
        /// Registration 
        /// </summary>
        public void Registration()
        {
            var email = AnsiConsole.Prompt(new TextPrompt<string>("Email:"));
            var login = AnsiConsole.Prompt(new TextPrompt<string>("Login:"));
            var password = AnsiConsole.Prompt(new TextPrompt<string>("Password:").Secret());

            try
            {
                var result = _accountService.Register(new ReqRegister { Login = login, Password = password,Email = email });

                if (result.Value.Error == ErrorCodeEnum.One)
                {
                    AnsiConsole.MarkupLine($"[green]Registration complete Successfully![/]");
                    AnsiConsole.MarkupLine($"[silver]Registered user id:{result.Value.Id}![/]");
                }
                else
                {
                    AnsiConsole.MarkupLine($"[red]Unfortantly registration failed :( Try again![/]");
                    AnsiConsole.MarkupLine($"[silver]{result.Value.ErrorDescription}[/]");
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Unfortantly registration failed :( Try again![/]");
                AnsiConsole.MarkupLine($"[silver]{ex.Message}[/]");
            }
        }
    }
}

// See https://aka.ms/new-console-template for more information

using DemoApp.ConsoleUI.Facades;

var behavior = new ConsoleUIBehaviourFacade();
behavior.Init();

var continueFlag = true;
do
{

    Console.WriteLine();
    Console.WriteLine();

    switch (behavior.SelectAction())
    {
        case SelectionConstants.Registration:
            behavior.Registration();
            break;
        case SelectionConstants.Login:
            behavior.Login();
            break;
        case SelectionConstants.Check:
            behavior.CheckDataBase();
            break;
        case SelectionConstants.Exit:
            continueFlag = false;
            break;
    }
} while (continueFlag);


Console.WriteLine();
Console.WriteLine("Push any key to continue...");
Console.ReadKey();

using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration data
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest", "jumpsuits" };

    //Game State
    int level; 
    enum screen {mainMenu, password, win };
    screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMenu("Hello User");
    }

    void ShowMenu(string greeting)
    {
        currentScreen = screen.mainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for public library");
        Terminal.WriteLine("Press 2 for local police station");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMenu("Welcome back");
        }
        else if(currentScreen == screen.mainMenu)
        {
            RunMaiMenu(input);
        }
        else if(currentScreen == screen.password)
        {
            CheckPasswordInput(input);
        }
    }

    void RunMaiMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2");
        if(isValidLevel)
        {
            level = int.Parse(input);
            AskPassword();
;        }
        else if (input == "007")
        {
            Terminal.WriteLine("Welcome Mr Bond, what would you like to hack into today?");
        }
        else
        {
            Terminal.WriteLine("Plese enter a valid input");
        }
    }

    void AskPassword()
    {
        currentScreen = screen.password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Type menu for the main menu");
        Terminal.WriteLine("Please enter your password"); 
        SetRandomPassword();
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("hint: " + password.Anagram());
    }

    void CheckPasswordInput(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = screen.win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        Terminal.WriteLine("Access Granted");
        Terminal.WriteLine("Type menu for the main menu");
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
     __________
    /         //
   /         //
  /         //
 /________ //
( ________(/
                ");
                break;
            case 2:
                Terminal.WriteLine("Have a key...");
                Terminal.WriteLine(@"
   __
  /0 \__________
  \__/      '|'|

                ");
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }
}

using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "Grades", "Student", "Teacher", "Test", "Salary" };
    string[] level2Passwords = { "Evidence", "Criminal", "Database", "Weaponry", "Records" };
    string[] level3Passwords = { "Cryptology", "Ionosphere", "Data-haven", "Pseudonyms", "Illuminati" };

    // Game State
    int level;
    enum Screen {  MainMenu, Password, Win };
    Screen currentScreen;
    string password;

	// Use this for initialization
	void Start ()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Choose a location to hack.");
        Terminal.WriteLine("Available hacking locations: ");
        Terminal.WriteLine("Press 1 for School");
        Terminal.WriteLine("Press 2 for Police Station");
        Terminal.WriteLine("Press 3 for NSA");
        Terminal.WriteLine("Enter your selection:");
    }

    // this should only decide who to handle input, not actually do it
    void OnUserInput(string input)
    {
        if (input.ToUpper() == "MENU") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Choose a valid option.");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());

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
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
            Terminal.WriteLine(menuHint);
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine(@"
    _            
   / \       _   
  / _ \    _| |_ 
 / ___ \  |_   _|
/_/   \_\   |_|  
                 
");
                Terminal.WriteLine("Welcome to the School Database!");
                break;
            case 2:
                Terminal.WriteLine(@"
      _           _   _          
     | |_   _ ___| |_(_) ___ ___ 
  _  | | | | / __| __| |/ __/ _ \
 | |_| | |_| \__ | |_| | (_|  __/
  \___/ \__,_|___/\__|_|\___\___|
                                                                                             
");
                Terminal.WriteLine("Welcome to the Police Database!");
                break;
            case 3:
                Terminal.WriteLine("Good job Snowden!");
                Terminal.WriteLine(@"     
  _   _ ____    _    
 | \ | / ___|  / \   
 |  \| \___ \ / _ \  
 | |\  |___) / ___ \ 
 |_| \_|____/_/   \_\
");
                Terminal.WriteLine("Welcome to the NSA Database!");
                break;
        }
        
    }

    // Update is called once per frame
    void Update ()
    {
        int index = Random.Range(0, level1Passwords.Length);
        print(index);
    }
}

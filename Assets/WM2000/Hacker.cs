using UnityEngine;

public class Hacker : MonoBehaviour {
	// Game config
	string[] level1Passwords = { "books", "aisle", "shelf", "borrow" };
	string[] level2Passwords = { "jail", "gun", "pen", "handcuff" };
	string[] level3Passwords = { "rocket", "science", "fuel", "alien" };

	// Game state
	int level;
	enum Screen { MainMenu, Password, Win};
	Screen currentScreen;
	string password;

	// Use this for initialization
	void Start ()
	{
		ShowMainMenu();
	}

	// show options/levels to user
	void ShowMainMenu()
	{
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine("What would you lik to hack into? \n");
		Terminal.WriteLine("Press 1 for the local library");
		Terminal.WriteLine("Press 2 for the police station");
		Terminal.WriteLine("Press 3 for the NASA");
		Terminal.WriteLine("\nEnter your selection: ");
	}

	// when user type anything
	void OnUserInput(string input)
  {
		if (currentScreen == Screen.MainMenu || input.ToUpper() == "MENU")
		{
    	CheckLevelInput(input);
		}
		else if (currentScreen == Screen.Password)
    {
      CheckPassword(input);
    }
		else
		{
			ShowMainMenu();
		}
  }

  void CheckPassword(string input)
  {
    if (input == password)
    {
      DisplayWinScreen();
    }
    else
		{
			Terminal.WriteLine("WRONG PASSWORD!");
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
		switch (level)
		{
				case 1:
					Terminal.WriteLine(@"Have a book...
	     __..._   _...__
	_..-'      `Y`      '-._
	\ Once upon |           /
	\\  a time..|          //
	\\\         |         ///
	 \\\ _..---.|.---.._ ///
	  \\`_..---.Y.---.._`//
	jgs'`               `'
					");
					break;

				case 2:
					Terminal.WriteLine(@"Take your police badge...
		 ,   /\   ,
	  / '-'  '-' \
	 |   POLICE   |
	 \    .--.    /
	  |  ( 19 )  |
	  \   '--'   /
	   '--.  .--'
	jgs    \/
					");
					break;

				case 3:
					Terminal.WriteLine(@"Take your rocket...
	      |
	     / \
	    / _ \
	   |.o '.|
	   |'._.'|
	 ,'|  |  |`.
	|,-'--|--'-.| l42
					");
					break;
				default:
					Debug.LogError("Invalid level number");
					break;
		}
		Terminal.WriteLine("Press any key to continue...");
  }

  // check the user input
  void CheckLevelInput(string input)
  {
		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
		if (isValidLevelNumber)
		{
      StartGame(int.Parse(input));
		}
    else if (input == "42") // easter egg
    {
      Terminal.WriteLine("a resposta para a vida o universo e tudo mais");
    }
    else if (input.ToUpper() == "MENU")
    {
      ShowMainMenu();
    }
    else
    {
      Terminal.WriteLine("Please, enter a valid option or type menu:");
    }
  }

	// set level, change current screen
  void StartGame(int newLevel)
  {
    currentScreen = Screen.Password;
    level = newLevel;

    SetRandomPassword();

    Terminal.ClearScreen();
    Terminal.WriteLine("Enter the password, hint: " + password.Anagram());
  }

  void SetRandomPassword()
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
}

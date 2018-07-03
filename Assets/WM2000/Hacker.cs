using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
	int level;

	// Use this for initialization
	void Start () {
		var greeting = "Hello Taynan";
		ShowMainMenu(greeting);
	}

	void ShowMainMenu(string greeting = "Hello") {
		Terminal.ClearScreen();
		Terminal.WriteLine(greeting);
		Terminal.WriteLine("What would you lik to hack into? \n");
		Terminal.WriteLine("Press 1 for the local library");
		Terminal.WriteLine("Press 2 for the police station");
		Terminal.WriteLine("Press 3 for the NASA \n");
		Terminal.WriteLine("Enter your selection: ");
	}

	void OnUserInput(string input) {
		print(input);
		print(input == "1");

		if(input == "1") {
			level = 1;
			StartGame();
		} else if (input == "2") {
			level = 2;
			StartGame();
		} else if(input == "42") {
			Terminal.WriteLine("a resposta para a vida o universo e tudo mais");
		} else if(input == "menu") {
			ShowMainMenu();
		} else {
			Terminal.WriteLine("Please, enter a valid option or type menu:");
		}
	}

	void StartGame() {
		Terminal.WriteLine("You chose level " + level);
	}
}

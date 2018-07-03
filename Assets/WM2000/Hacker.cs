using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}

	// Update is called once per frame
	void Update () {

	}

	void ShowMainMenu() {
		Terminal.ClearScreen();
		Terminal.WriteLine("What would you lik to hack into? \n");
		Terminal.WriteLine("Press 1 for the local library");
		Terminal.WriteLine("Press 2 for the police station");
		Terminal.WriteLine("Press 3 for the NASA \n");
		Terminal.WriteLine("Enter your selection: ");
	}
}

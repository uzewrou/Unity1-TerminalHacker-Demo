using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {


	//Game configuration data
	string[] level1Passwords = {"books", "aisle", "self", "front"};
	string[] level2Passwords = { "prison", "handcuff", "uniform", "jail" };
		
	//Game state
	int level;
	enum Screen {MainMenu, Password, Win};
	Screen currentScreen = Screen.MainMenu;
	string password; 


	// Use this for initialization
	void Start () {
		ShowMainMenu ("Hello Huss");
	}

	void ShowMainMenu(string greeting){
		Terminal.ClearScreen ();
		currentScreen = Screen.MainMenu;
		Terminal.WriteLine (greeting);
		Terminal.WriteLine ("What would you like to hack into?");
		Terminal.WriteLine ("Press 1 for the Book Room");
		Terminal.WriteLine ("Press 2 for the local Military Office ");
		Terminal.WriteLine ("Enter your selection:");
	}


	void OnUserInput(string input){
		if (input == "menu") {
			ShowMainMenu ("Welcome back, Agent Huss");
		} else if (currentScreen == Screen.MainMenu) {
			RunMainMenu (input);
		} else if (currentScreen == Screen.Password) {
			CheckPassword(input);
		}
	}

	void RunMainMenu(string input){
		if (input == "1") {
			level = 1;
			StartGame ();
		} else if (input == "2") {
			level = 2;
			StartGame();
		}
	}


	void StartGame() {
		AskForPassword();
	}

	void CheckPassword(string input){
		if (input == password) {
			DisplayWinScreen();

		} else {
			Terminal.WriteLine("You shall not pass!");
		}
	}

	void AskForPassword(){
		currentScreen = Screen.Password;
		Terminal.WriteLine ("You have chosen level " + level);
		SetRandomPassword ();
		Terminal.WriteLine ("Enter password: " + password.Anagram());
	}

	void SetRandomPassword(){
		switch(level) {
		case 1: 
			password = level1Passwords [Random.Range(0, level1Passwords.Length)]; //make random later on
			break;
		case 2:
			password = level2Passwords [Random.Range(0, level2Passwords.Length)];
			break;
		default:
			Debug.LogError("Invalid level number");
			break;
		}
	}

	void DisplayWinScreen(){
		currentScreen = Screen.Win;
		Terminal.ClearScreen();
		Terminal.WriteLine("YOU WON!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

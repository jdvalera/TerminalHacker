﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

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
        if (input == "1")
        {
            level = 1;
            password = "hi";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "police";
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            password = "Osama";
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Choose a valid option.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password.");

    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Well done!");
        }
        else
        {
            Terminal.WriteLine("Wrong password");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

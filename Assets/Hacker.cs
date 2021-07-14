using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level,score=0,t=0;
    enum Screen {Main,Password,Playing,Win };
    Screen current;
    string password = "divyansh";
    string[] level1 = {"books","aisle","self","borrow","font" };
    string[] level2 = {"prisoner","handcuff","holster","uniform","arrest" };

	void Start ()
    {
        ShowMainMenu();
    }
	
    void ShowMainMenu()
    {
        current = Screen.Main;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Local Library");
        Terminal.WriteLine("Press 2 for Police Station");
        Terminal.WriteLine("Enter your selection:");
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else
            Terminal.WriteLine("Please choose a valid level");
    }
    
    void check(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Well done!");
            current = Screen.Playing;
        }
        else
            Terminal.WriteLine("Your password is wrong"); 
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
            ShowMainMenu();
        else if (current == Screen.Main)
            RunMainMenu(input);
        else if (current == Screen.Password)
            check(input);
        else if (current == Screen.Playing && t < 5)
        {
            t++;
  
            count(input);
        }
        else if (current == Screen.Playing && t >= 5)
        {
      
            Terminal.WriteLine("Your score is "+score);
        }
    }

    void count(string input)
    {
        for(int i=0;i<5;i++)
        {
            if (input == level1[i])
                score++;
        }
    }

    void StartGame()
    {
        current = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password:");
    }

    void Update ()
    {
		
	}
}

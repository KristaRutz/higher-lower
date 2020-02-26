using System;
using System.Collections.Generic;



public class Program
{   
    public static int Minimum = 0;
    public static int Maximum = 101;
    public static int StartGuess = 50;  
    public static int gameNumber; 

    public static void Main()
    {

        Minimum = 0;
        Maximum = 101;
        Random rnd = new Random();
        gameNumber = rnd.Next(0, 101);

        // keep playing?
        Console.WriteLine("Would you like to play the higher/lower game? Y/N");
        string answer = Console.ReadLine().ToLower();

        // don't keep playing
        if (answer == "n") 
        {
            Console.WriteLine("Goodbye");
        } 
        // play the game
        else if (answer == "y")
        {
            Console.WriteLine("Great! Shall I guess your number, or think of my own? ['C' for computer guesses player's number, 'P' for player guesses computer's number.]");
            string gametype = Console.ReadLine().ToLower();

            if (gametype == "c")
            {
                Console.WriteLine("Okay! Think of a number between 1 and 100.");
                NewComputerGuess(StartGuess);   
            }
            else if (gametype == "p")
            {
                Console.WriteLine("Okay! I am thinking of a number between 1 and 100.");
                NewPlayerGuess();        
            }         
        } 
        else
        {
            Console.WriteLine("This is not a valid input.");
            Main();
        }
        
    }

    public static void IsEqual()
    {
        Console.WriteLine("I guessed your number.");
        Main();
    }

    public static void IsHigher(int min)
    {
        Minimum = min;
        int newMiddle = ((Maximum + Minimum) / 2);
        
        NewComputerGuess(newMiddle);
    }

    public static void IsLower(int max)
    {
        Maximum = max;
        int newMiddle = ((Maximum + Minimum) / 2);
        
        NewComputerGuess(newMiddle);
    }

    public static void NewComputerGuess(int middle)
    {
        Console.WriteLine("Is your number higher or lower than " + middle + "? [Type 'H' for higher, 'L' for lower, or '=' for correct]");
        string answerMiddle = Console.ReadLine().ToLower();

        if (answerMiddle == "=")
        {
            IsEqual();
        }
        else if (answerMiddle == "h")
        {
            IsHigher(middle);
        }
        else if (answerMiddle == "l")
        {
            IsLower(middle);
        }
        else
        {
            Console.WriteLine("This is not a valid input.");
            NewComputerGuess(middle);
        }
    }

    public static void NewPlayerGuess()
    {
        Console.WriteLine("Enter a number that you guess");
        string strUserNumber = Console.ReadLine();
        int userNumber = int.Parse(strUserNumber);

        if (userNumber == gameNumber)
        {
            Console.WriteLine("you guessed my number.");
            Main();
        }
        else if (userNumber < gameNumber)
        {
            Console.WriteLine("my number is higher");
            NewPlayerGuess();
        }
        else if (userNumber > gameNumber)
        {
            Console.WriteLine("my number is lower");
            NewPlayerGuess();
        }
        else
        {
            Console.WriteLine("This is not a valid input.");
            NewPlayerGuess();
        }
    }
}
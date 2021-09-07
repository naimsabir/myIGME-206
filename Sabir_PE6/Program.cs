﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_PE6
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Homework Assignment 6
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Generate a random number between 0 and 100 and have the user guess it
        //Restrictions: None
        static void Main(string[] args)
        {
            //label to signify the start of the code that the user comes back to if they fail to guess 
            //and want to try again
            startHere:
            //code to generate the random int that the user will need to guess
            Random rand = new Random();
            int randomNumber = rand.Next(0, 101);
            int guessNumber;
            string playAgain;
            
            Console.WriteLine("The random number is: " + randomNumber);

            Console.WriteLine("Guess what the random number is!");

            guessNumber = Convert.ToInt32(Console.ReadLine());

            //while loop to make sure the user input is within 0 to 100 and will force the
            //user to keep entering values until they are acceptable
            while(guessNumber > 100 || guessNumber < 0)
            {
                Console.WriteLine("Invalid Output: Please enter a number between 1 and 100.");
                guessNumber = Convert.ToInt32(Console.ReadLine());
            }

            //for loop that ensures that the user will only have 8 tries
            for(int counter = 1; counter <= 8; counter++)
            {
                if(guessNumber == randomNumber)
                {
                    Console.WriteLine("You guessed correctly and it only took you " + counter + " tries!");
                    return;
                }
                if(guessNumber > randomNumber)
                {
                    Console.WriteLine("You guessed to high! You now have " + (8 - counter) + " tries left");
                }
                if(guessNumber < randomNumber)
                {
                    Console.WriteLine("You guessed to low! You now have " + (8 - counter) + " tries left");
                }
                Console.WriteLine("Enter your new guess here!");
                guessNumber = Convert.ToInt32(Console.ReadLine());

                //while loop to make sure the user input is within 0 to 100 and will force the
                //user to keep entering values until they are acceptable
                while (guessNumber > 100 || guessNumber < 0)
                {
                    Console.WriteLine("Invalid Output: Please enter a number between 1 and 100.");
                    guessNumber = Convert.ToInt32(Console.ReadLine());
                }

            }

            Console.WriteLine("You ran out of tries! The correct number was " + randomNumber + " would you like to try again? Enter y for Yes or n for No");
            
            //an if else statement that allows the user to play again if they so choose
            //if they choose not to the program will end
            playAgain = Console.ReadLine();
            if (playAgain == "y")
            {
                goto startHere;
            }
            else if (playAgain != "y")
            {
                Console.WriteLine("Ok better luck next time! ");
            }
            
            

        }
    }
}

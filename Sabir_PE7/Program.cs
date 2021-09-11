using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sabir_PE7
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Homework Assignment 7
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Work with strings, lists, and input/output to create a Mad Libs game.
        //Using predetermined narratives stored in a text file, gather information from the user to generate a complete story.
        //Restrictions
        static void Main(string[] args)
        {
            //Pseudo-Code
            //1. Declare a stream reader variable
            //2. Read the MadLibsTemplate file
            //3. Figure out how many MadLibs there are in the file
            //4. Parse out the input sections to each MadLib Story
            //5. Allow the user to choose a specific MadLib Story and Fill the Input Sections
            //6. Output the user's madlib to the resultString
            //7. Add functionality to let the user to choose to play or not at the beginning of the program

            
            //String to hold the result at the end
            string resultString = null;

            //String to hold the value that decides whether the game will be played
            string willPlay = null;

            //int to count how many MadLibs are in the template folder
            int numLibs = 0;

            //counter variable used to indicate position in array
            int counter = 0;

            //int to hold the users story selection
            int nChoice = 0;

            //a boolean to use to verify whether the user input was valid
            bool isValid = false;

            //a label to mark the start of the statement to ask the user if they want to play the game
            playStart:
            Console.WriteLine("Would you like to play MadLibs please enter yes or no");

            //using ToLower to make sure that it is not counted as an error if the user uses capital letters
            willPlay = Console.ReadLine().ToLower();

            //a switch statement is used here to make sure the answers are very case specific
            switch(willPlay)
            {
                case "yes":
                    goto start;
                    
                case "no":
                    goto end;
                   
                default:
                    Console.WriteLine("Incorrect Input!");
                    goto playStart;
            }
            
            //label signifying the start of the main code that the switch statement leads to if users
            //choose to play the game
            start:
            StreamReader input;

            input = new StreamReader("C:/templates/MadLibsTemplate.txt");

            //a string variable used to count how many MadLibs there are
            string lineReader = null;

            //a while loop that reads each line in the MadLibsTemplate file by using the
            //StreamReader method ReadLine to read each line in the the file until it encounters
            //a blank file. Each time it reads a line it increments the numLibs counter
            while((lineReader = input.ReadLine()) != null)
            {
                ++numLibs;
            }

            //closing the file after using it
            input.Close();

            //a test statement to make sure that the file is being read correctly
            //Console.WriteLine("There are " + numLibs + " MadLibs in that file");

            //Create a string array to hold the madLibs and allocate space only for those MadLibs
            //using the numLibs variable
            string[] madLibs = new string[numLibs];

            //Open the MadLibsTemplate file again to read the MadLibs into an array
            input = new StreamReader("C:/templates/MadLibsTemplate.txt");

            lineReader = null;

            //while loop to input each line into the array and to make sure that all newlines 
            //are read correctly
            while((lineReader = input.ReadLine()) != null)
            {
                //stores each line in MadLibsTemplate into a spot in the madLibs array
                madLibs[counter] = lineReader;

                //replace /n with the actual newline escape character
                madLibs[counter] = madLibs[counter].Replace("\\n", "\n");

                ++counter;
            }

            input.Close();

            //Promt the user for what MadLib they want to use
            Console.WriteLine("Which MadLib would you like to play there are " + numLibs + "options so please enter a number betweeen 1 and " + (numLibs));

            //a do while loop to take the users choice for MadLib that they want to play and make sure
            //that it is a valid input
            do
            {
                try
                {
                    nChoice = Convert.ToInt32(Console.ReadLine());
                    if(nChoice <= numLibs && nChoice > 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("That was an invalid number please enter a number between 1 and " + (numLibs));
                        isValid = false;
                    }
                    
                }
                catch
                {
                    Console.WriteLine("That was an invalid input please enter a number between 1 and " + (numLibs));
                    isValid = false;
                }
                
            }
            while (!isValid);

            //split the into separate words 
            string[] words = madLibs[nChoice - 1].Split(' ');

            foreach(string word in words)
            {
                // if word is a placeholder
                // {
                //      prompt the user for the replacement
                //      and append the user response to the result string
                // }
                // else
                // {
                //      append word to the result string
                // }
                if (word.StartsWith("{"))
                {
                    isValid = false;

                    //nest of Replace methods to make sure that the placeholders are displayed properly
                    string newWord = word.Replace("{", "'");
                    newWord = newWord.Replace("}", "'");
                    newWord = newWord.Replace("_", " ");

                    string userInput = null;

                    Console.WriteLine("Please Enter a/an " + newWord);
                    do
                    {
                        try
                        {
                            userInput = Console.ReadLine();
                            isValid = true;
                        }
                        catch
                        {
                            Console.WriteLine("Please enter a valid string");
                            isValid = false;
                        }
                       
                    }
                    while (!isValid);

                    resultString += userInput + " ";
                }
                else
                {
                    resultString += word + " ";
                }
            }

            //output the result string
            Console.WriteLine("Your completed Mad Lib is: " + resultString);

            //end of the code that is reached through the switch statement and naturally through the flow of the code.
        end:
            Console.WriteLine("Goodbye!");

        }
    }
}

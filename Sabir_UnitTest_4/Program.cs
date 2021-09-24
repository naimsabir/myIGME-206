using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Sabir_UnitTest_4
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Unit Test 1: Question 4
    //Restrictions: None
    class Program
    {
        //creating the timer uses milliseconds
        static Timer timeOutTimer;

        //creating a static bool to see if time has run out
        static bool timeOut = false;

        //creating a static string to hold the correct answer
        static string theAnswer = null;

        //Method: Main
        //Purpose: Write a console application that re-creates the attached 3questions.exe
        //Restrictions: None
        static void Main(string[] args)
        {
            //Pseudo Code:
            //1.Prompt the user to choose one out of three questions.
            //  a.What is your favorite color? Answer: black
            //  b.What is the answer to life, the universe, and everything? Answer: 42
            //  c.What is the airspeed velocity of an unladen swallow? Answer: What do you mean? African or European swallow?
            //2.Make the questions timed for 5 seconds and when time runs out tell the user that time's run out
            //and display the correct answer. Then you prompt them to hit enter and they will be asked if they want to play again.
            //  a.The play again code accepts anything beginning with y as a yes and anything starting with an n as a no
            //  b.The exact syntax or the wrong message is "Wrong!  The answer is:" for a wrong answer and
            //  "Times up! /n The answer is:"

            //int that holds the number for the question choice
            int iQuestionChoice;

            //strings to hold the user's answer, whether or not the player wants to go again, and to hold the question being asked
            string questionAnswer;
            string yesOrNo;
            string theQuestion;
            
            
            //start label to go back to when player chooses play again
            start:
            Console.WriteLine("Choose your question (1/3)");
            //catch any non integer input
            try
            {
                iQuestionChoice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter an integer between 1 and 3");
                goto start;
            }

            //switch statement to call the method for handling questions
            //also used in order to catch an input that is not a number between 1 and 3
            switch(iQuestionChoice)
            {
                case 1:
                    theQuestion = HandleQuestion(iQuestionChoice);
                    break;
                case 2:
                    theQuestion = HandleQuestion(iQuestionChoice);
                    break;
                case 3:
                    theQuestion = HandleQuestion(iQuestionChoice);
                    break;
                default:
                    Console.WriteLine("You did not enter an integer between 1 and 3! Try again.");
                    goto start;
            }
            //make the timer 5 seconds
            timeOutTimer = new Timer(5000);

            //make it so when time runs out the TimesUp Method is called
            ElapsedEventHandler elapsedEventHandler;
            elapsedEventHandler = new ElapsedEventHandler(TimesUp);
            timeOutTimer.Elapsed += elapsedEventHandler;

            Console.WriteLine("You have 5 seconds to answer the following question:");

            //start the timer
            timeOutTimer.Start();

            Console.WriteLine(theQuestion);
            questionAnswer = Console.ReadLine();
            if (timeOut == false)
            {
                if(questionAnswer == theAnswer)
                {
                    timeOutTimer.Stop();
                    Console.WriteLine("Well Done!");
                }
                else if (questionAnswer != theAnswer)
                {
                    timeOutTimer.Stop();
                    Console.WriteLine("Wrong! The answer is: " + theAnswer);
                }
            }
        
            //ask the user if they want to play again
            Console.Write("Play again? ");
            yesOrNo = Console.ReadLine();

            Console.WriteLine("");

            if(yesOrNo.StartsWith("y"))
            {
                goto start;
            }
            else
            {
                return;
            }
        }
        //Method: HandleQuestion
        //Purpose: To take the user's choice of question and set theQuestion with the return value and set theAnswer equal to the answer
        //of the question
        //Restrictions: None
        public static string HandleQuestion(int questionChoice)
        {
            string returnQuestion = null;

            string question1 = "What is your favorite color?";
            string question2 = "What is the answer to life, the universe and everything?";
            string question3 = "What is the airspeed velocity of an unladen swallow?";

            if(questionChoice == 1)
            {
                returnQuestion = question1;
                theAnswer = "black";
            }
            else if(questionChoice == 2)
            {
                returnQuestion = question2;
                theAnswer = "42";
            }
            else if(questionChoice == 3)
            {
                returnQuestion = question3;
                theAnswer = "What do you mean? African or European swallow?";
            }

            return returnQuestion;
        }
        //Method: TimesUp
        //Purpose: To tell the user their time is up and to set the bool timeOut to true. It also stops the timer
        //Restrictions: None
        public static void TimesUp(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Times Up!");
            Console.WriteLine("The answer is: " + theAnswer);
            Console.WriteLine("Please press enter");
            timeOut = true;
            timeOutTimer.Stop();
        }
    }
}

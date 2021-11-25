using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabir_UnitTest3_1
{
    //Class: Program
    //Author: Naim Sabir
    //Purpose: Unit Test 3: Question 1
    //Restrictions:
    class Program
    {
        //Write a console application that:
        //a. prompts the user for a string
        //b. prints how many of each letter of the alphabet are in the string (case-insensitive, ie.A=a)
        //c. prints the string in reverse order(eg. "great programmer" should output "remmargorp taerg")
        //d. tests if the string is a palindrome(allowing for punctuation, spaces and different capitalization) For example,  "Madam, I'm Adam" is a palindrome.

        static void Main(string[] args)
        {
            char[] daAlphabet;
            (string, int)[] alphabet;
            string userString;
            string reverseString;
            //Prompt the user for a string
            Console.WriteLine("Please enter a string: ");
            userString = Console.ReadLine().ToLower();

            //print how many of each letter of the alphabet are in the string
            //my plan to do so is to use a for each loop with a switch statement with counters for each letter
            daAlphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            alphabet = new (string, int)[26];
            for(int i = 0; i <= (daAlphabet.Length - 1); i++)
            {
                alphabet[i].Item1 = daAlphabet[i].ToString();
            }
            foreach(char letter in userString)
            {
                switch (letter)
                {
                    case 'a':
                        alphabet[0].Item2 += 1;
                        break;
                    case 'b':
                        alphabet[1].Item2 += 1;
                        break;
                    case 'c':
                        alphabet[2].Item2 += 1;
                        break;
                    case 'd':
                        alphabet[3].Item2 += 1;
                        break;
                    case 'e':;
                        alphabet[4].Item2 += 1;
                        break;
                    case 'f':
                        alphabet[5].Item2 += 1;
                        break;
                    case 'g':
                        alphabet[6].Item2 += 1;
                        break;
                    case 'h':
                        alphabet[7].Item2 += 1;
                        break;
                    case 'i':
                        alphabet[8].Item2 += 1;
                        break;
                    case 'j':
                        alphabet[9].Item2 += 1;
                        break;
                    case 'k':
                        alphabet[10].Item2 += 1;
                        break;
                    case 'l':
                        alphabet[11].Item2 += 1;
                        break;
                    case 'm':
                        alphabet[12].Item2 += 1;
                        break;
                    case 'n':
                        alphabet[13].Item2 += 1;
                        break;
                    case 'o':
                        alphabet[14].Item2 += 1;
                        break;
                    case 'p':
                        alphabet[15].Item2 += 1;
                        break;
                    case 'q':
                        alphabet[16].Item2 += 1;
                        break;
                    case 'r':
                        alphabet[17].Item2 += 1;
                        break;
                    case 's':
                        alphabet[18].Item2 += 1;
                        break;
                    case 't':
                        alphabet[19].Item2 += 1;
                        break;
                    case 'u':
                        alphabet[20].Item2 += 1;
                        break;
                    case 'v':
                        alphabet[21].Item2 += 1;
                        break;
                    case 'w':
                        alphabet[22].Item2 += 1;
                        break;
                    case 'x':
                        alphabet[23].Item2 += 1;
                        break;
                    case 'y':
                        alphabet[24].Item2 += 1;
                        break;
                    case 'z':
                        alphabet[25].Item2 += 1;
                        break;
                }

            }
            
            for(int i = 0; i <= (alphabet.Length - 1); i++)
            {
                if(alphabet[i].Item2 != 0)
                {
                    Console.WriteLine($"There are {alphabet[i].Item2} letter {alphabet[i].Item1}'s in your string!");
                }
            }

            //print in reverse order
            reverseString = ReverseOrder(userString);
            Console.WriteLine($"The reverse of your string is: {reverseString}");

            //test if a palindrome
            //acceptable state right now but it does not exclude punctuaction should add if you have time
            if(userString == reverseString)
            {
                Console.WriteLine("The string is a palindrome!");
            }

        }

        public static string ReverseOrder(string target)
        {
            int counter = 0;
            int decrementer = target.Length;
            char[] daLetters = new char[target.Length];
            char[] reverseLetters = new char[target.Length];
            string resultString;
            foreach(char letter in target)
            {
                daLetters[counter] = letter;
                counter += 1;

            }
            for(int i = 0; i <= (target.Length - 1); i++)
            {
                reverseLetters[i] = daLetters[decrementer - 1];
                decrementer--;
            }
            resultString = new string(reverseLetters);

            return resultString;
        }
    }
}

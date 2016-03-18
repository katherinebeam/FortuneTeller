using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection; //required in order for our 'Restart' method to work
using System.Text;
using System.Threading.Tasks;

namespace FortuneTeller
{
    class Program
    {
        static void Main(string[] args)
        {
            //PART ONE
            string playAgain = "";

            do
            {
                Console.WriteLine("Greetings user, and welcome to Katherine and Scott's \"tell-all-ball\" of mystical fortunes!");
                Console.WriteLine("(You can quit at any time by typing \"Quit\", and can restart at any time by typing \"Restart\".)");
                Console.WriteLine("Please enter your first name:");
                var firstName = Console.ReadLine();
                Quit(firstName);
                Restart(firstName);
                Console.WriteLine("Ah yes, " + firstName + ". Now please enter your last name my child:");
                string lastName = Console.ReadLine();
                Quit(lastName);
                Restart(lastName);

                int ageNum = 0;
                //ensure user enters a valid number (not a string)
                do
                {
                    try
                    {
                        Console.WriteLine("Please enter your current age:");
                        string age = Console.ReadLine();
                        Quit(age);
                        Restart(age);
                        ageNum = int.Parse(age);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("That is not a valid number!");
                    }
                }
                while (ageNum == 0);
                Console.WriteLine("In which month were you born?");
                string birthMonth = Console.ReadLine().ToUpper();
                Quit(birthMonth);
                Restart(birthMonth);
                string favoriteColor = "";
                if (favoriteColor.ToUpper() == "QUIT")
                {
                    break;
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Please enter your favorite ROYGBIV color:");
                        Console.WriteLine("(Not sure what ROYGBIV means? Type \"Help\".)");
                        favoriteColor = Console.ReadLine().ToUpper();
                        Quit(favoriteColor);
                        Restart(favoriteColor);
                        if (favoriteColor == "HELP")
                        {
                            Console.WriteLine("Red\nOrange\nYellow\nGreen\nBlue\nIndigo\nViolet");
                        }
                    }
                    while (favoriteColor == "HELP");
                }

                int siblingNum = -1;
                do
                {
                    try
                    {
                        Console.WriteLine("How many siblings do you have?");
                        string siblings = Console.ReadLine();
                        Quit(siblings);
                        Restart(siblings);
                        siblingNum = int.Parse(siblings);
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("That is not a valid number!");
                    }
                }
                while (siblingNum == -1 || siblingNum < 0);

                //PART TWO
                //Retirement
                int retirement = 0;

                //check if age is odd and assign retirement to 1 year
                if (ageNum % 2 != 0)
                {
                    retirement = 1;
                }
                //check if age is an even number and assign retirement to 400 years :(
                else if (ageNum % 2 == 0)
                {
                    retirement = 400;
                }

                //Siblings
                string location = "";
                switch (siblingNum)
                {
                    case 0:
                        location = " in the closet";
                        break;
                    case 1:
                        location = " in Narnia";
                        break;
                    case 2:
                        location = " in Hogsmeade";
                        break;
                    case 3:
                        location = " in Laguna Beach";
                        break;
                    default:
                        location = " on the moon";
                        break;
                }

                //ROYGBIV
                string transportation = "";
                switch (favoriteColor)
                {
                    case "RED":
                        transportation = " a pimped out riding lawn mower";
                        break;
                    case "ORANGE":
                        transportation = " a pickup truck";
                        break;
                    case "YELLOW":
                        transportation = " a wild Pikachu";
                        break;
                    case "GREEN":
                        transportation = " a leprechaun";
                        break;
                    case "BLUE":
                        transportation = " a tiger";
                        break;
                    case "INDIGO":
                        transportation = " a unicycle";
                        break;
                    case "VIOLET":
                        transportation = " a skateboard";
                        break;
                    default:
                        transportation = " a spaceship";
                        break;
                }

                //Money in da Bank 
                string firstLetter = birthMonth[0].ToString(); //get first letter of user's birth month 
                string secondLetter = birthMonth[1].ToString(); //get second letter of user's birth month
                string thirdLetter = birthMonth[2].ToString(); //get third letter of user's birth month
                string moneyInBank = "";

                //checks if user's first or last name contains the first, second, or third letter of their birth month
                //then assigns a money in bank amount based on whether name contains the specified letter or not
                if (firstName.ToUpper().IndexOf(firstLetter) != -1 || lastName.ToUpper().IndexOf(firstLetter) != -1)
                {
                    moneyInBank = "$100";
                }
                else if (firstName.ToUpper().IndexOf(secondLetter) != -1 || lastName.ToUpper().IndexOf(secondLetter) != -1)
                {
                    moneyInBank = "$500";
                }
                else if (firstName.ToUpper().IndexOf(thirdLetter) != -1 || lastName.ToUpper().IndexOf(thirdLetter) != -1)
                {
                    moneyInBank = "$10,000";
                }
                else
                {
                    moneyInBank = "$3";
                }

                //PART THREE 

                //Tell user their fortune
                Console.WriteLine("\a\a\a" + firstName + " " + lastName + " will retire in " + retirement + " year(s) with " + moneyInBank + " in the bank, a vacation home" + location + ", and your mode of transportation will be" + transportation + ".");

                //Ask user if they want to play again
                Console.WriteLine("Want to play again? (y/n)");
                playAgain = Console.ReadLine().ToUpper();
                Quit(playAgain);
            }
            //Restart game if they signify they want to play again 
            while (playAgain == "Y");
        }

        //Method for quitting the currently running Fortune Teller game
        static void Quit(string userReply)
        {
            userReply = userReply.ToUpper();
            if (userReply == "QUIT")
            {
                Console.WriteLine("Nobody likes a quitter...");
                Environment.Exit(0); //Exits the program
            }
        }

        //Method for restarting the Fortune Teller game
        static void Restart(string userReply)
        {
            userReply = userReply.ToUpper();
            if (userReply == "RESTART")
            {
                var fileName = Assembly.GetExecutingAssembly().Location; //gets location of the document where the fortune telling game exists and saves it in a variable
                System.Diagnostics.Process.Start(fileName); //starts new fortune telling game 
                Environment.Exit(0); //exits the current fortune telling game (new game starts in a new window)
            }

        }
    }
}

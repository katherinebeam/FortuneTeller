﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FortuneTeller
{
    class Program
    {
        static void Main(string[] args)
        {
            //PART ONE
            Console.WriteLine("Greetings user, and welcome to Katherine and Scott's \"tell-all-ball\" of mystical fortunes!");
            string playAgain = "";

            do
            {
                Console.WriteLine("Please enter your first name:");
                string firstName = Console.ReadLine();
                Quit(firstName);
                Restart(firstName);
                char firstNameLetter = char.ToUpper(firstName[0]);
                Console.WriteLine("Ah yes, " + firstName + ". Now please enter your last name my child:");
                string lastName = Console.ReadLine();
                Quit(lastName);
                Restart(lastName);
                Console.WriteLine("Please enter your current age:");
                string age = Console.ReadLine();
                Quit(age);
                Restart(age);
                int ageNum = int.Parse(age);
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

                Console.WriteLine("How many siblings do you have?");
                string siblings = Console.ReadLine();
                Quit(siblings);
                Restart(siblings);
                int siblingNum = int.Parse(siblings);

                //PART TWO
                //Retirement
                int retirement = 0;
                if (ageNum % 2 != 0)
                {
                    retirement = 1;
                }
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
                string firstLetter = birthMonth[0].ToString();
                string secondLetter = birthMonth[1].ToString();
                string thirdLetter = birthMonth[2].ToString();
                string moneyInBank = "";
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
                Console.WriteLine(firstName.IndexOf(secondLetter));


                //PART THREE 

                //Fortune
                Console.WriteLine(firstName + " " + lastName + " will retire in " + retirement + " year(s) with " + moneyInBank + " in the bank, a vacation home" + location + ", and your mode of transportation will be" + transportation + ".");

                Console.WriteLine("Want to play again? (y/n)");
                playAgain = Console.ReadLine().ToUpper();
                Quit(playAgain);
            }
            while (playAgain == "Y");
        }
        static void Quit(string userReply)
        {
            userReply = userReply.ToUpper();
            if (userReply == "QUIT")
            {
                Console.WriteLine("Nobody likes a quitter...");
                Environment.Exit(0);
            }
        }

        static void Restart(string userReply)
        {
            if (userReply == "Restart")
            {
                var fileName = Assembly.GetExecutingAssembly().Location;
                System.Diagnostics.Process.Start(fileName);
                Environment.Exit(0);
            }

        }
    }
}

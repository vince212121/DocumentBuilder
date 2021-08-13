/*
 * Namespace:       Project2
 * File:            Program.cs
 * Date:            July 17, 2021
 * Author:          Vincent Li
 * Description:     This is the console client for the project where the main program runs
 */

using System;
using System.Linq;
using DocumentBuilderLibrary;

namespace Project2
{
    /**
	 * Class Name:		Program
	 * Purpose:			Used to run the console
	 * Coder:			Vincent Li
	 * Date:			July 17, 2021
    */
    class Program
    {
        private static Director _director;

        static void Main(string[] args)
        {
            Console.WriteLine("Document Builder Console Client - Vincent Li\n");

            // prints the use case 
            PrintUsage();

            bool fileTypeSet = false;
            bool exit = false;

            do
            {
                Console.Write("> ");

                // reads in command (case-insensitive)
                string command = Console.ReadLine().ToLower();
                string[] commands = command.Split(":"); // split command

                // no commands inputed
                if (commands.Count() == 0)
                {
                    InvalidInput();
                }
                // ex. print, help, etc.
                else if (commands.Count() == 1)
                {
                    if (commands[0] == "help")
                    {
                        PrintUsage();
                    }
                    else if (commands[0] == "close")
                    {
                        if (fileTypeSet)
                        {
                            _director.CloseBranch();
                        }
                        else
                        {
                            ModeNotSet();
                        }
                    }
                    else if (commands[0] == "print")
                    {
                        if (fileTypeSet)
                        {
                            _director.PrintDocument();
                        }
                        else
                        {
                            ModeNotSet();
                        }
                    }
                    else if (commands[0] == "exit")
                    {
                        exit = true;
                    }
                    else
                    {
                        InvalidInput();
                    }
                }
                // mode or branch
                else if (commands.Count() == 2)
                {
                    if (commands[0] == "mode")
                    {
                        if (commands[1] == "json")
                        {
                            fileTypeSet = true;
                            _director = new Director(new JSONBuilder());
                        }
                        else if (commands[1] == "xml")
                        {
                            fileTypeSet = true;
                            _director = new Director(new XMLBuilder());
                        }
                        else
                        {
                            InvalidInput();
                        }
                    }
                    else if (commands[0] == "branch")
                    {
                        if (fileTypeSet)
                        {
                            // set key then build branch
                            _director.key = commands[1];
                            _director.BuildBranch();
                        }
                        else
                        {
                            ModeNotSet();
                        }
                    }
                    else
                    {
                        InvalidInput();
                    }
                }
                // leaf
                else if (commands.Count() == 3)
                {
                    if (commands[0] == "leaf")
                    {
                        if (fileTypeSet)
                        {
                            // set key and value. Then build leaf
                            _director.key = commands[1];
                            _director.value = commands[2];
                            _director.BuildLeaf();
                        }
                        else
                        {
                            ModeNotSet();
                        }
                    }
                    else
                    {
                        InvalidInput();
                    }
                }
            } while (!exit);
        }

        /*
         * Method Name: PrintUsage
         * Purpose:     Used to print the usage of the program
         * Accepts:     nothing
         * Returns:     void
        */
        public static void PrintUsage()
        {
            Console.WriteLine("\nUsage:");
            Console.WriteLine("\thelp\t\t\t\t\t-Prints Usage (this page)");
            Console.WriteLine("\tmode:<JSON|XML>\t\t\t\t-Sets mode to JSON or XML. Must be set before creating or closing.");
            Console.WriteLine("\tbranch:<name>\t\t\t\t-Creates a new branch, assigning it the passed name.");
            Console.WriteLine("\tleaf:<name>:<content>\t\t\t-Creates a new leaf, assigning the passed name and content");
            Console.WriteLine("\tclose\t\t\t\t\t-Closes the current branch, as long as it is not the root.");
            Console.WriteLine("\tprint\t\t\t\t\t-Pints the doc in its current state to the console.");
            Console.WriteLine("\texit\t\t\t\t\t-Exits the application.\n");
        }

        /*
         * Method Name: InvalidInput
         * Purpose:     Prints out an error message if for invalid inputs
         * Accepts:     nothing
         * Returns:     void
        */
        public static void InvalidInput()
        {
            Console.WriteLine("\nInvalid input. For Usage, type 'Help'\n");
        }

        /*
         * Method Name: ModeNotSet
         * Purpose:     Used to print an error message if the mode has not been set
         * Accepts:     nothing
         * Returns:     void
        */
        public static void ModeNotSet()
        {
            Console.WriteLine("\nError. Mode has not been set. For usage, type 'Help'\n");
        }
    }
}

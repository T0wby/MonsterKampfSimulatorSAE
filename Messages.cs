using System;
using System.Collections.Generic;
using System.Media;
using System.Text;

namespace Monsterkampfsimulator
{
    class Messages
    {

        /// <summary>
        /// Writing a console message in Red
        /// </summary>
        /// <param name="Input">Message that needs to be printed</param>
        /// <param name="cc">Color of the message</param>
        public static void PrintErrorColor(string Input, ConsoleColor cc = ConsoleColor.Red)
        {
            Console.ForegroundColor = cc;
            Console.WriteLine(Input);
            Console.ResetColor();
        }

        /// <summary>
        /// Writing a console message in Cyan
        /// </summary>
        /// <param name="Input">essage that needs to be printed</param>
        /// <param name="cc">Color of the message</param>
        public static void PrintConsoleMessageColor(string Input, ConsoleColor cc = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = cc;
            Console.WriteLine(Input);
            Console.ResetColor();
        }

        /// <summary>
        /// Writing a console message in Yellow
        /// </summary>
        /// <param name="Input">essage that needs to be printed</param>
        /// <param name="cc">Color of the message</param>
        public static void PrintYellowMessageColor(string Input, ConsoleColor cc = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = cc;
            Console.WriteLine(Input);
            Console.ResetColor();
        }

        /// <summary>
        /// Writing a console message in DarkGreen
        /// </summary>
        /// <param name="Input">essage that needs to be printed</param>
        /// <param name="cc">Color of the message</param>
        public static void PrintDarkGreenMessageColor(string Input, ConsoleColor cc = ConsoleColor.DarkGreen)
        {
            Console.ForegroundColor = cc;
            Console.WriteLine(Input);
            Console.ResetColor();
        }

        #region UserInputFunctions

        /// <summary>
        /// Changing the User input color 
        /// </summary>
        /// <param name="cc">Color of the message</param>
        /// <returns>Returns the given input</returns>
        public static string UserInputMessage(ConsoleColor cc = ConsoleColor.Green)
        {
            string input;
            Console.ForegroundColor = cc;
            input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }

        /// <summary>
        /// Changing the User input color and looping until the input is a float value.
        /// </summary>
        /// <param name="cc">Color of the message.</param>
        /// <returns>Returns the written value as a float.</returns>
        public static float UserInputFloat(ConsoleColor cc = ConsoleColor.Green)
        {
            float result;

            do
            {
                if (float.TryParse(UserInputMessage(), out result))
                {
                    if (result > 0)
                        return result;
                    else
                        Messages.PrintErrorColor("Please make sure to only enter positive values!\n");
                }
                else
                    PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
            } while (true);
        }
        #endregion

        /// <summary>
        /// Setting the console size if possible, writing a text and looping the main song
        /// </summary>
        /// <param name="MenuStartSound">Main Game sound</param>
        public static void WelcomeMessage(SoundPlayer MenuStartSound)
        {
            try
            {
                Console.SetWindowSize(150, 60);
            }
            catch
            {
                PrintErrorColor("Console SetWindowSize failed");
            }
            PrintConsoleMessageColor(@"                   ██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗    ████████╗ ██████╗     ███╗   ███╗██╗   ██╗      
                   ██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝    ╚══██╔══╝██╔═══██╗    ████╗ ████║╚██╗ ██╔╝      
                   ██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗         ██║   ██║   ██║    ██╔████╔██║ ╚████╔╝       
                   ██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝         ██║   ██║   ██║    ██║╚██╔╝██║  ╚██╔╝        
                   ╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗       ██║   ╚██████╔╝    ██║ ╚═╝ ██║   ██║         
                    ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝       ╚═╝    ╚═════╝     ╚═╝     ╚═╝   ╚═╝         
                                                                                                                                     
                   ███████╗██╗ ██████╗ ██╗  ██╗████████╗    ███████╗██╗███╗   ███╗██╗   ██╗██╗      █████╗ ████████╗ ██████╗ ██████╗ 
                   ██╔════╝██║██╔════╝ ██║  ██║╚══██╔══╝    ██╔════╝██║████╗ ████║██║   ██║██║     ██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗
                   █████╗  ██║██║  ███╗███████║   ██║       ███████╗██║██╔████╔██║██║   ██║██║     ███████║   ██║   ██║   ██║██████╔╝
                   ██╔══╝  ██║██║   ██║██╔══██║   ██║       ╚════██║██║██║╚██╔╝██║██║   ██║██║     ██╔══██║   ██║   ██║   ██║██╔══██╗
                   ██║     ██║╚██████╔╝██║  ██║   ██║       ███████║██║██║ ╚═╝ ██║╚██████╔╝███████╗██║  ██║   ██║   ╚██████╔╝██║  ██║
                   ╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝       ╚══════╝╚═╝╚═╝     ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝

                                                   ____                               ____                             
                                                  |  _ \  _ __  ___  ___  ___        / ___|                            
                                                  | |_) || '__|/ _ \/ __|/ __|       \___ \                            
                                                  |  __/ | |  |  __/\__ \\__ \        ___) |                           
                                                  |_|    |_|   \___||___/|___/       |____/                            
                        _                _                _     _    _                                           
                       | |_  ___    ___ | |_  __ _  _ __ | |_  | |_ | |__    ___    __ _   __ _  _ __ ___    ___ 
                       | __|/ _ \  / __|| __|/ _` || '__|| __| | __|| '_ \  / _ \  / _` | / _` || '_ ` _ \  / _ \
                       | |_| (_) | \__ \| |_| (_| || |   | |_  | |_ | | | ||  __/ | (_| || (_| || | | | | ||  __/
                        \__|\___/  |___/ \__|\__,_||_|    \__|  \__||_| |_| \___|  \__, | \__,_||_| |_| |_| \___|
                                                                                   |___/                         ");

            MenuStartSound.LoadAsync();
            MenuStartSound.PlayLooping();
        }

        /** While loop which ends as soon as we get the correct input **/
        public static void WaitingForSKey()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if ((key.KeyChar == 'S') || (key.KeyChar == 's'))
                {
                    Console.Clear();
                    break;
                }
            }
        }

        /**  **/
        public static void DisplayAllAvailableFighters(List<Monster> allAvailableFighters)
        {
            for (int i = 0; i < allAvailableFighters.Count; i++)
            {
                PrintConsoleMessageColor($"{allAvailableFighters[i].Number}. {allAvailableFighters[i].Name}");
            }
        }

        /** Explanation message for the attributes and how we collect them **/
        public static void ExplanationMessage(string fighterOne)
        {
            PrintConsoleMessageColor($"\nNow we need your help! Each of our fighters has different attributes which we need YOU to set for us.\n" +
                $"Those attributes are the following:\n" +
                $"1. Healthpoints\n" +
                $"2. Attackpoints\n" +
                $"3. Defensepoints\n" +
                $"4. Speed\n" +
                $"----------------\n" +
                $"We will ask for each attribute seperately from 1 to 4 and start with your first picked fighter the {fighterOne}.\n");
        }

        /** Show the attributes of the first fighter before we enter the attributes of the 2nd one **/
        public static void ShowStatsFighterOne(Monster m1)
        {
            PrintConsoleMessageColor($@"
|                 |  {m1.Name}
|-----------------| -------
| Healthpoints:   | {m1.Lifepoints}
| Attackpower:    | {m1.Attackpower}
| Defensepoints:  | {m1.Defensepoints}
| Speed:          | {m1.Speed}");
        }

        /** Transition message between the collection of the attributes of both fighters **/
        public static void TransitionMessage(Monster fighterOne, Monster fighterTwo)
        {
            PrintConsoleMessageColor($"\n\nGreat! The {fighterOne.Name} now has stats for each of their attributes.\n" +
                $"----------------\n" +
                $"We will now proceed with the stats for our 2nd fighter the {fighterTwo.Name}.\n" +
                $"----------------\n");
        }

        /** Show the attributes of both fighters **/
        public static void ShowStatsBothFighters(Monster m1, Monster m2)
        {
            PrintConsoleMessageColor($@"
|                 |  {m1.Name}
|-----------------| -------
| Healthpoints:   | {m1.Lifepoints}
| Attackpower:    | {m1.Attackpower}
| Defensepoints:  | {m1.Defensepoints}
| Speed:          | {m1.Speed}
-----------------------------------------
|                 |  {m2.Name}
|-----------------| -------
| Healthpoints:   | {m2.Lifepoints}
| Attackpower:    | {m2.Attackpower}
| Defensepoints:  | {m2.Defensepoints}
| Speed:          | {m2.Speed}");
        }

        /** Message ending the attribute collection and telling the user to press any button to start the fight **/
        public static void CollectionEndMessage(string fighterOne, string fighterTwo)
        {
            PrintConsoleMessageColor($"\nAmazing! Now that both our fighters the {fighterOne} and {fighterTwo} are ready to start their battle please give us the start signal " +
                $"by pressing any BUTTON on your keyboard!!\n" +
                $"------------------------------------------------\n" +
                $"IN ORDER TO START THE BATTLE PLEASE PRESS ANY BUTTON!!\n");
        }

        /** ASCII Art and sound for the start of the fight **/
        public static void StartFightMessageAndSound(SoundPlayer FightStartSound)
        {
            if (FightStartSound != null)
            {
                FightStartSound.LoadAsync();
                FightStartSound.PlaySync();
            }
            
            PrintConsoleMessageColor(@"
  _____  _         _      _    _  _ 
 |  ___|(_)  __ _ | |__  | |_ | || |
 | |_   | | / _` || '_ \ | __|| || |
 |  _|  | || (_| || | | || |_ |_||_|
 |_|    |_| \__, ||_| |_| \__|(_)(_)
            |___/                   ");
        }

        /** Gives out the message which is shown after a fight ended **/
        public static void FightEndMessage(Monster m1, Monster m2, int rounds)
        {
            PrintConsoleMessageColor(@"
███████╗██╗ ██████╗ ██╗  ██╗████████╗    ███████╗███╗   ██╗██████╗ ███████╗██████╗ 
██╔════╝██║██╔════╝ ██║  ██║╚══██╔══╝    ██╔════╝████╗  ██║██╔══██╗██╔════╝██╔══██╗
█████╗  ██║██║  ███╗███████║   ██║       █████╗  ██╔██╗ ██║██║  ██║█████╗  ██║  ██║
██╔══╝  ██║██║   ██║██╔══██║   ██║       ██╔══╝  ██║╚██╗██║██║  ██║██╔══╝  ██║  ██║
██║     ██║╚██████╔╝██║  ██║   ██║       ███████╗██║ ╚████║██████╔╝███████╗██████╔╝
╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝       ╚══════╝╚═╝  ╚═══╝╚═════╝ ╚══════╝╚═════╝ 
-----------------------------------------------------------------------------------");

            if (m1.Lifepoints <= 0)
            {
                PrintConsoleMessageColor($"The fight between the {m1.Name} and {m2.Name} ended and our champion in todays fight is the {m2.Name}.\n" +
                    $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                    $@"
|------------------------| ---------
| {m1.Name} Healthpoints:    | {m1.Lifepoints}
| {m2.Name} Healthpoints:    | {m2.Lifepoints}");
            }
            else if (m2.Lifepoints <= 0)
            {
                PrintConsoleMessageColor($"The fight between the {m1.Name} and {m2.Name} ended and our champion in todays fight is the {m1.Name}.\n" +
                    $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                    $@"
|------------------------| ---------
| {m1.Name} Healthpoints:    | {m1.Lifepoints}
| {m2.Name} Healthpoints:    | {m2.Lifepoints}");
            }
            else if (rounds >= 100)
            {
                PrintConsoleMessageColor($"The fight between the {m1.Name} and {m2.Name} took to long and ended in a draw.\n" +
                    $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                    $@"
|------------------------| ---------
| {m1.Name} Healthpoints:    | {m1.Lifepoints}
| {m2.Name} Healthpoints:    | {m2.Lifepoints}");
            }
        }

        /** Contains the credits to all the content used by 3rd parties **/
        public static void Credits()
        {
            Console.WriteLine("\n\n\n\n\n");
            PrintConsoleMessageColor(@"
-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
-----------------------------------------------------------------------------------
██████╗██████╗ ███████╗██████╗ ██╗████████╗███████╗
██╔════╝██╔══██╗██╔════╝██╔══██╗██║╚══██╔══╝██╔════╝
██║     ██████╔╝█████╗  ██║  ██║██║   ██║   ███████╗
██║     ██╔══██╗██╔══╝  ██║  ██║██║   ██║   ╚════██║
╚██████╗██║  ██║███████╗██████╔╝██║   ██║   ███████║
 ╚═════╝╚═╝  ╚═╝╚══════╝╚═════╝ ╚═╝   ╚═╝   ╚══════╝");

            Console.WriteLine("This programm uses the following sounds from https://freesound.org:\n\n" +
                "Content Under 'Creative Commons 0 License':\n" +
                "Countdown To Fight by Nakamurasensei | https://freesound.org/people/Nakamurasensei/sounds/472853/ \n" +
                "Game_Over_01 by MATRIXXX_ | https://freesound.org/people/MATRIXXX_/sounds/345666/ \n\n" +
                "Content Under 'Attribution Noncommercial License':\n" +
                "Dramatic Scroller by FoolBoyMedia | https://freesound.org/people/FoolBoyMedia/sounds/270366/ \n\n" +
                "ASCII Text Art from | https://patorjk.com/software/taag/#p=display&f=ANSI%20Shadow&t=Type%20Something%20 \n" +
                "-----------------------------------------------------------------------------------");
        }

    }
}

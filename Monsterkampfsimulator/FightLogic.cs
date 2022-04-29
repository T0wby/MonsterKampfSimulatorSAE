using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Monsterkampfsimulator
{
    static class FightLogic
    {
        // Strings used for the user input
        static string race1;
        static string race2;

        // Int used to keep track of how many rounds our fighters fought
        static int rounds = 0;
        // Int used to switch between who of the fighters attack in the given round
        static int whoAttacks = 0;
        // Used to delay each round in our fight
        static int waitTime = 500;
        // Used to check that the user entered a valid input when asking for the 2 fighters
        static bool bNotMatching;

        // Attributes for fighter 1
        static float lifepointsOne = 0f; 
        static float attackpowerOne = 0f; 
        static float defensepointsOne = 0f; 
        static float speedOne = 0f;

        // Attributes for fighter 2
        static float lifepointsTwo = 0f;
        static float attackpowerTwo = 0f;
        static float defensepointsTwo = 0f;
        static float speedTwo = 0f;

        static Ork Ork = new Ork();
        static Troll Troll = new Troll();
        static Goblin Goblin = new Goblin();

        /** Get methode for race1 **/
        public static string FighterOne
        {
            get { return race1; }
        }

        /** Get methode for race2 **/
        public static string FighterTwo
        {
            get { return race2; }
        }

        /** Asking user for the first fighter **/
        public static void GetFighterOneInput()
        {
            // Doing a do-while loop in order to redo the action until we have a valid input
            do
            {
                race1 = Messages.UserInputMessage();
                // Switch case in order to set attributes for our first fighter and setting the string to all lower cases to ignore case sensitivity
                switch (race1.ToLower())
                {
                    case "1":
                    case "ork":
                        if(race1.ToLower() == "1")
                            race1 = "Ork";
                        Ork.Chosen = true;
                        bNotMatching = false;
                        break;
                    case "2":
                    case "troll":
                        if (race1.ToLower() == "2")
                            race1 = "Troll";
                        Troll.Chosen = true;
                        bNotMatching = false;
                        break;
                    case "3":
                    case "goblin":
                        if (race1.ToLower() == "3")
                            race1 = "Goblin";
                        Goblin.Chosen = true;
                        bNotMatching = false;
                        break;
                    default:
                        bNotMatching = true;
                        Messages.PrintErrorColor("Please make sure that you write the fighters names correctly!\n");
                        break;
                }
            } while (bNotMatching);
        }

        /** Asking user for the second fighter **/
        public static void GetFighterTwoInput()
        {
            do
            {
                Messages.PrintConsoleMessageColor(@"
██     ██ ██   ██  ██████      ██ ███████     ██    ██  ██████  ██    ██ ██████           
██     ██ ██   ██ ██    ██     ██ ██           ██  ██  ██    ██ ██    ██ ██   ██          
██  █  ██ ███████ ██    ██     ██ ███████       ████   ██    ██ ██    ██ ██████           
██ ███ ██ ██   ██ ██    ██     ██      ██        ██    ██    ██ ██    ██ ██   ██          
 ███ ███  ██   ██  ██████      ██ ███████        ██     ██████   ██████  ██   ██          
                                                                                          
                                                                                          
███████ ███████  ██████  ██████  ███    ██ ██████      ██████  ██  ██████ ██   ██ ██████  
██      ██      ██      ██    ██ ████   ██ ██   ██     ██   ██ ██ ██      ██  ██       ██ 
███████ █████   ██      ██    ██ ██ ██  ██ ██   ██     ██████  ██ ██      █████     ▄███  
     ██ ██      ██      ██    ██ ██  ██ ██ ██   ██     ██      ██ ██      ██  ██    ▀▀    
███████ ███████  ██████  ██████  ██   ████ ██████      ██      ██  ██████ ██   ██   ██");

                if (Ork.Chosen)
                {
                    Messages.PrintTrollMessageColor(@"
 ██╗       ████████╗██████╗  ██████╗ ██╗     ██╗     
███║       ╚══██╔══╝██╔══██╗██╔═══██╗██║     ██║     
╚██║          ██║   ██████╔╝██║   ██║██║     ██║     
 ██║          ██║   ██╔══██╗██║   ██║██║     ██║     
 ██║██╗       ██║   ██║  ██║╚██████╔╝███████╗███████╗
 ╚═╝╚═╝       ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝");
                    Messages.PrintConsoleMessageColor(@"
 ██████ ██████  
██    ████   ██ 
██    ████████  
██    ████   ██ 
 ██████ ██   ██ ");
                    Messages.PrintGoblinMessageColor(@"
██████╗         ██████╗  ██████╗ ██████╗ ██╗     ██╗███╗   ██╗
╚════██╗       ██╔════╝ ██╔═══██╗██╔══██╗██║     ██║████╗  ██║
 █████╔╝       ██║  ███╗██║   ██║██████╔╝██║     ██║██╔██╗ ██║
██╔═══╝        ██║   ██║██║   ██║██╔══██╗██║     ██║██║╚██╗██║
███████╗██╗    ╚██████╔╝╚██████╔╝██████╔╝███████╗██║██║ ╚████║
╚══════╝╚═╝     ╚═════╝  ╚═════╝ ╚═════╝ ╚══════╝╚═╝╚═╝  ╚═══╝");

                    race2 = Messages.UserInputMessage();

                    // We check if the user selected the same race again and print a message if he did so. Otherwise we use a 2nd switch statement to create the 2nd fighter object.
                    if (race1.ToLower() == race2.ToLower())
                    {
                        Messages.PrintErrorColor($"{race1} was already chosen as the first fighter! Please chose one of the other two that are available\n----------------");
                        bNotMatching = true;
                    }
                    else
                    {
                        switch (race2.ToLower())
                        {
                            case "1":
                            case "troll":
                                if (race2.ToLower() == "1")
                                    race2 = "Troll";
                                Troll.Chosen = true;
                                bNotMatching = false;
                                break;
                            case "2":
                            case "goblin":
                                if (race2.ToLower() == "2")
                                    race2 = "Goblin";
                                Goblin.Chosen = true;
                                bNotMatching = false;
                                break;
                            default:
                                bNotMatching = true;
                                Messages.PrintErrorColor("Please make sure that you write the fighters names correctly!\n");
                                break;
                        }
                    }
                }
                else if (Troll.Chosen)
                {
                    Messages.PrintOrkMessageColor(@"
 ██╗        ██████╗ ██████╗ ██╗  ██╗
███║       ██╔═══██╗██╔══██╗██║ ██╔╝
╚██║       ██║   ██║██████╔╝█████╔╝ 
 ██║       ██║   ██║██╔══██╗██╔═██╗ 
 ██║██╗    ╚██████╔╝██║  ██║██║  ██╗
 ╚═╝╚═╝     ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝");
                    Messages.PrintConsoleMessageColor(@"
 ██████ ██████  
██    ████   ██ 
██    ████████  
██    ████   ██ 
 ██████ ██   ██ ");
                    Messages.PrintGoblinMessageColor(@"
██████╗         ██████╗  ██████╗ ██████╗ ██╗     ██╗███╗   ██╗
╚════██╗       ██╔════╝ ██╔═══██╗██╔══██╗██║     ██║████╗  ██║
 █████╔╝       ██║  ███╗██║   ██║██████╔╝██║     ██║██╔██╗ ██║
██╔═══╝        ██║   ██║██║   ██║██╔══██╗██║     ██║██║╚██╗██║
███████╗██╗    ╚██████╔╝╚██████╔╝██████╔╝███████╗██║██║ ╚████║
╚══════╝╚═╝     ╚═════╝  ╚═════╝ ╚═════╝ ╚══════╝╚═╝╚═╝  ╚═══╝");

                    race2 = Messages.UserInputMessage();

                    // We check if the user selected the same race again and print a message if he did so. Otherwise we use a 2nd switch statement to create the 2nd fighter object.
                    if (race1.ToLower() == race2.ToLower())
                    {
                        Messages.PrintErrorColor($"{race1} was already chosen as the first fighter! Please chose one of the other two that are available\n----------------");
                        bNotMatching = true;
                    }
                    else
                    {
                        switch (race2.ToLower())
                        {
                            case "1":
                            case "ork":
                                if (race2.ToLower() == "1")
                                    race2 = "Ork";
                                Ork.Chosen = true;
                                bNotMatching = false;
                                break;
                            case "2":
                            case "goblin":
                                if (race2.ToLower() == "2")
                                    race2 = "Goblin";
                                Goblin.Chosen = true;
                                bNotMatching = false;
                                break;
                            default:
                                bNotMatching = true;
                                Messages.PrintErrorColor("Please make sure that you write the fighters names correctly!\n");
                                break;
                        }
                    }
                }
                else
                {
                    Messages.PrintOrkMessageColor(@"
 ██╗        ██████╗ ██████╗ ██╗  ██╗
███║       ██╔═══██╗██╔══██╗██║ ██╔╝
╚██║       ██║   ██║██████╔╝█████╔╝ 
 ██║       ██║   ██║██╔══██╗██╔═██╗ 
 ██║██╗    ╚██████╔╝██║  ██║██║  ██╗
 ╚═╝╚═╝     ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝");
                    Messages.PrintConsoleMessageColor(@"
 ██████ ██████  
██    ████   ██ 
██    ████████  
██    ████   ██ 
 ██████ ██   ██ ");
                    Messages.PrintTrollMessageColor(@"
██████╗        ████████╗██████╗  ██████╗ ██╗     ██╗     
╚════██╗       ╚══██╔══╝██╔══██╗██╔═══██╗██║     ██║     
 █████╔╝          ██║   ██████╔╝██║   ██║██║     ██║     
██╔═══╝           ██║   ██╔══██╗██║   ██║██║     ██║     
███████╗██╗       ██║   ██║  ██║╚██████╔╝███████╗███████╗
╚══════╝╚═╝       ╚═╝   ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝");

                    race2 = Messages.UserInputMessage();

                    // We check if the user selected the same race again and print a message if he did so. Otherwise we use a 2nd switch statement to create the 2nd fighter object.
                    if (race1.ToLower() == race2.ToLower())
                    {
                        Messages.PrintErrorColor($"{race1} was already chosen as the first fighter! Please chose one of the other two that are available\n----------------");
                        bNotMatching = true;
                    }
                    else
                    {
                        switch (race2.ToLower())
                        {
                            case "1":
                            case "ork":
                                if (race2.ToLower() == "1")
                                    race2 = "Ork";
                                Ork.Chosen = true;
                                bNotMatching = false;
                                break;
                            case "2":
                            case "troll":
                                if (race2.ToLower() == "2")
                                    race2 = "Troll";
                                Troll.Chosen = true;
                                bNotMatching = false;
                                break;
                            default:
                                bNotMatching = true;
                                Messages.PrintErrorColor("Please make sure that you write the fighters names correctly!\n");
                                break;
                        }
                    }
                }

                
            } while (bNotMatching);
        }

        /** Function to collect the stats of the 1st fighter **/
        public static void GetFighterOneStats()
        {
            // Created a bool for the do while loops
            bool bNegativeValue;
            float result;

            do
            {
                // Asking for the Health value
                Messages.PrintConsoleMessageColor($"Please give the {race1} a positive Health value:");

                Console.ForegroundColor = Messages.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    lifepointsOne = result;
                }
                else
                {
                    Messages.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();

                // Checking that the entered value is positive
                if (lifepointsOne > 0)
                {
                    bNegativeValue = false;
                    switch (race1.ToLower())
                    {
                        case "ork":
                            Ork.Lifepoints = lifepointsOne;
                            break;
                        case "troll":
                            Troll.Lifepoints = lifepointsOne;
                            break;
                        case "goblin":
                            Goblin.Lifepoints = lifepointsOne;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Messages.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

            do
            {
                // Asking for the Attackpower value
                Messages.PrintConsoleMessageColor($"Please give the {race1} a positive Attackpower value:");
                Console.ForegroundColor = Messages.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    attackpowerOne = result;
                }
                else
                {
                    Messages.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive
                if (attackpowerOne > 0)
                {
                    bNegativeValue = false;
                    switch (race1.ToLower())
                    {
                        case "ork":
                            Ork.Attackpower = attackpowerOne;
                            break;
                        case "troll":
                            Troll.Attackpower = attackpowerOne;
                            break;
                        case "goblin":
                            Goblin.Attackpower = attackpowerOne;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Messages.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

            do
            {
                // Asking for the Defensepoint value
                Messages.PrintConsoleMessageColor($"Please give the {race1} a positive Defensepoint value:");
                Console.ForegroundColor = Messages.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    defensepointsOne = result;
                }
                else
                {
                    Messages.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive
                if (defensepointsOne > 0)
                {
                    bNegativeValue = false;
                    switch (race1.ToLower())
                    {
                        case "ork":
                            Ork.Defensepoints = defensepointsOne;
                            break;
                        case "troll":
                            Troll.Defensepoints = defensepointsOne;
                            break;
                        case "goblin":
                            Goblin.Defensepoints = defensepointsOne;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Messages.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

            do
            {
                // Asking for the Speed value
                Messages.PrintConsoleMessageColor($"Please give the {race1} a positive Speed value:");
                Console.ForegroundColor = Messages.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    speedOne = result;
                }
                else
                {
                    Messages.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive
                if (speedOne > 0)
                {
                    bNegativeValue = false;
                    switch (race1.ToLower())
                    {
                        case "ork":
                            Ork.Speed = speedOne;
                            break;
                        case "troll":
                            Troll.Speed = speedOne;
                            break;
                        case "goblin":
                            Goblin.Speed = speedOne;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Messages.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

        }

        /** Setting sp1 to later use it in GetFighterTwoStats() for speed comparison **/
        public static void SettingCompareSpeed()
        {
            if (Ork.Chosen)
            {
                speedOne = Ork.Speed;
            }
            else if (Goblin.Chosen)
            {
                speedOne = Goblin.Speed;
            }
            else
            {
                speedOne = Troll.Speed;
            }
        }

        /** Function to collect the stats of the 2nd fighter **/
        public static void GetFighterTwoStats()
        {
            // Created a bool for the do while loops
            bool bNegativeValue;
            float result;

            do
            {
                // Asking for the Health value
                Messages.PrintConsoleMessageColor($"Please give the {race2} a positive Health value:");
                Console.ForegroundColor = Messages.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    lifepointsTwo = result;
                }
                else
                {
                    Messages.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive
                if (lifepointsTwo > 0)
                {
                    bNegativeValue = false;
                    switch (race2.ToLower())
                    {
                        case "ork":
                            Ork.Lifepoints = lifepointsTwo;
                            break;
                        case "troll":
                            Troll.Lifepoints = lifepointsTwo;
                            break;
                        case "goblin":
                            Goblin.Lifepoints = lifepointsTwo;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Messages.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

            do
            {
                // Asking for the Attackpower value
                Messages.PrintConsoleMessageColor($"Please give the {race2} a positive Attackpower value:");
                Console.ForegroundColor = Messages.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    attackpowerTwo = result;
                }
                else
                {
                    Messages.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive
                if (attackpowerTwo > 0)
                {
                    bNegativeValue = false;
                    switch (race2.ToLower())
                    {
                        case "ork":
                            Ork.Attackpower = attackpowerTwo;
                            break;
                        case "troll":
                            Troll.Attackpower = attackpowerTwo;
                            break;
                        case "goblin":
                            Goblin.Attackpower = attackpowerTwo;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Messages.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

            do
            {
                // Asking for the Defensepoint value
                Messages.PrintConsoleMessageColor($"Please give the {race2} a positive Defensepoint value:");
                Console.ForegroundColor = Messages.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    defensepointsTwo = result;
                }
                else
                {
                    Messages.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive
                if (defensepointsTwo > 0)
                {
                    bNegativeValue = false;
                    switch (race2.ToLower())
                    {
                        case "ork":
                            Ork.Defensepoints = defensepointsTwo;
                            break;
                        case "troll":
                            Troll.Defensepoints = defensepointsTwo;
                            break;
                        case "goblin":
                            Goblin.Defensepoints = defensepointsTwo;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Messages.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

            do
            {
                // Asking for the Speed value
                Messages.PrintConsoleMessageColor($"Please give the {race2} a positive Speed value:");
                Console.ForegroundColor = Messages.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    speedTwo = result;
                }
                else
                {
                    Messages.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive and doesn't match the first speed value
                if (speedTwo > 0 && speedTwo != speedOne)
                {
                    bNegativeValue = false;
                    switch (race2.ToLower())
                    {
                        case "ork":
                            Ork.Speed = speedTwo;
                            break;
                        case "troll":
                            Troll.Speed = speedTwo;
                            break;
                        case "goblin":
                            Goblin.Speed = speedTwo;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Messages.PrintErrorColor("Please make sure to only enter positive values and not the same value as you did for the first fighter!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);
        }

        /** Show the attributes of the first fighter before we enter the attributes of the 2nd one **/
        public static void ShowStatsFighterOne()
        {
            if (race1.ToLower() == "ork")
            {
                Messages.PrintConsoleMessageColor($@"
|                 |  Ork
|-----------------| -------
| Healthpoints:   | {Ork.Lifepoints}
| Attackpower:    | {Ork.Attackpower}
| Defensepoints:  | {Ork.Defensepoints}
| Speed:          | {Ork.Speed}");
            }
            else if (race1.ToLower() == "goblin")
            {
                Messages.PrintConsoleMessageColor($@"
|                 |  Goblin
|-----------------| -------
| Healthpoints:   | {Goblin.Lifepoints}
| Attackpower:    | {Goblin.Attackpower}
| Defensepoints:  | {Goblin.Defensepoints}
| Speed:          | {Goblin.Speed}");
            }
            else
            {
                Messages.PrintConsoleMessageColor($@"
|                 |  Troll
|-----------------| -------
| Healthpoints:   | {Troll.Lifepoints}
| Attackpower:    | {Troll.Attackpower}
| Defensepoints:  | {Troll.Defensepoints}
| Speed:          | {Troll.Speed}");
            }
        }
        
        /** Show the attributes of both fighters **/
        public static void ShowStatsBothFighters()
        {
            if (Ork.Chosen && Troll.Chosen)
            {
                Messages.PrintConsoleMessageColor($@"
|                 |  Ork
|-----------------| -------
| Healthpoints:   | {Ork.Lifepoints}
| Attackpower:    | {Ork.Attackpower}
| Defensepoints:  | {Ork.Defensepoints}
| Speed:          | {Ork.Speed}
-----------------------------
|                 | Troll
|-----------------| -------
| Healthpoints:   | {Troll.Lifepoints}
| Attackpower:    | {Troll.Attackpower}
| Defensepoints:  | {Troll.Defensepoints}
| Speed:          | {Troll.Speed}");
            }
            else if (Ork.Chosen && Goblin.Chosen)
            {
                Messages.PrintConsoleMessageColor($@"
|                 |  Ork
|-----------------| -------
| Healthpoints:   | {Ork.Lifepoints}
| Attackpower:    | {Ork.Attackpower}
| Defensepoints:  | {Ork.Defensepoints}
| Speed:          | {Ork.Speed}
-----------------------------
|                 | Goblin
|-----------------| -------
| Healthpoints:   | {Goblin.Lifepoints}
| Attackpower:    | {Goblin.Attackpower}
| Defensepoints:  | {Goblin.Defensepoints}
| Speed:          | {Goblin.Speed}");
            }
            else if (Goblin.Chosen && Troll.Chosen)
            {
                Messages.PrintConsoleMessageColor($@"
|                 |  Troll
|-----------------| -------
| Healthpoints:   | {Troll.Lifepoints}
| Attackpower:    | {Troll.Attackpower}
| Defensepoints:  | {Troll.Defensepoints}
| Speed:          | {Troll.Speed}
-----------------------------
|                 | Goblin
|-----------------| -------
| Healthpoints:   | {Goblin.Lifepoints}
| Attackpower:    | {Goblin.Attackpower}
| Defensepoints:  | {Goblin.Defensepoints}
| Speed:          | {Goblin.Speed}");
            }
        }

        /** Comparing speeds and setting the start boolean for the fight **/
        public static void WhoStartsFight()
        {
            if (Ork.Chosen && Troll.Chosen)
            {
                if (Ork.Speed > Troll.Speed)
                {
                    Ork.StartFight = true;
                }
                else if (Ork.Speed < Troll.Speed)
                {
                    Troll.StartFight = true;
                }
            }
            else if (Ork.Chosen && Goblin.Chosen)
            {
                if (Ork.Speed > Goblin.Speed)
                {
                    Ork.StartFight = true;
                }
                else if (Ork.Speed < Goblin.Speed)
                {
                    Goblin.StartFight = true;
                }
            }
            else
            {
                if (Troll.Speed > Goblin.Speed)
                {
                    Troll.StartFight = true;
                }
                else if (Troll.Speed < Goblin.Speed)
                {
                    Goblin.StartFight = true;
                }
            }
        }

        /** Starting the fight and ending it **/
        public static void StartFight()
        {
            if (Ork.Chosen && Troll.Chosen)
            {
                if (Ork.StartFight)
                {
                    // The fight goes on until one of the fighters has 0 or less Lifepoints or we reached 100 rounds in total
                    while (Ork.Lifepoints > 0 && Troll.Lifepoints > 0 && rounds < 100)
                    {
                        // For each iteration of the while loop we add 1 to the variable rounds in order to use it in Console.WriteLine statements and to stop a potential endless loop
                        rounds++;
                        switch (whoAttacks)
                        {
                            case 0:
                                Ork.Attack(Troll);
                                whoAttacks += 1;
                                Sound.PlayRandomAttackSound();
                                Messages.PrintConsoleMessageColor($"Round {rounds}:");
                                Messages.PrintOrkMessageColor("The Ork attacks!!");
                                Messages.PrintConsoleMessageColor($"The Ork's life: {Ork.Lifepoints}\nThe Troll's life: {Troll.Lifepoints}\n--------------------\n");
                                break;
                            case 1:
                                Troll.Attack(Ork);
                                whoAttacks -= 1;
                                Sound.PlayRandomAttackSound();
                                Messages.PrintConsoleMessageColor($"Round {rounds}:");
                                Messages.PrintTrollMessageColor("The Troll attacks!!");
                                Messages.PrintConsoleMessageColor($"The Ork's life: {Ork.Lifepoints}\nThe Troll's life: {Troll.Lifepoints}\n--------------------\n");
                                break;
                            default:
                                break;
                        }
                        Thread.Sleep(waitTime);
                    }

                    Messages.FightEndMessage();

                    if (Ork.Lifepoints <= 0)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Ork and Troll ended and our champion in todays fight is the Troll.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Ork Healthpoints:      | { Ork.Lifepoints}
| Troll Healthpoints:    | { Troll.Lifepoints}");
                    }
                    else if (Troll.Lifepoints <= 0)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Ork and Troll ended and our champion in todays fight is the Ork.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Ork Healthpoints:      | { Ork.Lifepoints}
| Troll Healthpoints:    | { Troll.Lifepoints}");
                    }
                    else if (rounds >= 100)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Ork and Troll took to long and ended in a draw.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Ork Healthpoints:      | { Ork.Lifepoints}
| Troll Healthpoints:    | { Troll.Lifepoints}");
                    }

                }
                else if (Troll.StartFight)
                {
                    while (Ork.Lifepoints > 0 && Troll.Lifepoints > 0 && rounds < 100)
                    {
                        rounds++;
                        switch (whoAttacks)
                        {
                            case 0:
                                Troll.Attack(Ork);
                                whoAttacks += 1;
                                Sound.PlayRandomAttackSound();
                                Messages.PrintConsoleMessageColor($"Round {rounds}:");
                                Messages.PrintTrollMessageColor("The Troll attacks!!");
                                Messages.PrintConsoleMessageColor($"The Ork's life: {Ork.Lifepoints}\nThe Troll's life: {Troll.Lifepoints}\n--------------------\n");
                                break;
                            case 1:
                                Ork.Attack(Troll);
                                whoAttacks -= 1;
                                Sound.PlayRandomAttackSound();
                                Messages.PrintConsoleMessageColor($"Round {rounds}:");
                                Messages.PrintOrkMessageColor("The Ork attacks!!");
                                Messages.PrintConsoleMessageColor($"The Ork's life: {Ork.Lifepoints}\nThe Troll's life: {Troll.Lifepoints}\n--------------------\n");
                                break;
                            default:
                                break;
                        }
                        Thread.Sleep(waitTime);
                    }

                    Messages.FightEndMessage();

                    if (Ork.Lifepoints <= 0)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Ork and Troll ended and our champion in todays fight is the Troll.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Ork Healthpoints:      | { Ork.Lifepoints}
| Troll Healthpoints:    | { Troll.Lifepoints}");
                    }
                    else if (Troll.Lifepoints <= 0)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Ork and Troll ended and our champion in todays fight is the Ork.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Ork Healthpoints:      | { Ork.Lifepoints}
| Troll Healthpoints:    | { Troll.Lifepoints}");
                    }
                    else if (rounds >= 100)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Ork and Troll took to long and ended in a draw.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Ork Healthpoints:      | { Ork.Lifepoints}
| Troll Healthpoints:    | { Troll.Lifepoints}");
                    }
                }
            }
            else if (Ork.Chosen && Goblin.Chosen)
            {
                if (Ork.StartFight)
                {
                    while (Ork.Lifepoints > 0 && Goblin.Lifepoints > 0 && rounds < 100)
                    {
                        rounds++;
                        switch (whoAttacks)
                        {
                            case 0:
                                Ork.Attack(Goblin);
                                whoAttacks += 1;
                                Sound.PlayRandomAttackSound();
                                Messages.PrintConsoleMessageColor($"Round {rounds}:");
                                Messages.PrintOrkMessageColor("The Ork attacks!!");
                                Messages.PrintConsoleMessageColor($"The Ork's life: {Ork.Lifepoints}\nThe Goblin's life: {Goblin.Lifepoints}\n--------------------\n");
                                break;
                            case 1:
                                Goblin.Attack(Ork);
                                whoAttacks -= 1;
                                Sound.PlayRandomAttackSound();
                                Messages.PrintConsoleMessageColor($"Round {rounds}:");
                                Messages.PrintGoblinMessageColor("The Goblin attacks!!");
                                Messages.PrintConsoleMessageColor($"The Ork's life: {Ork.Lifepoints}\nThe Goblin's life: {Goblin.Lifepoints}\n--------------------\n");
                                break;
                            default:
                                break;
                        }
                        Thread.Sleep(waitTime);
                    }

                    Messages.FightEndMessage();

                    if (Ork.Lifepoints <= 0)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Ork and Goblin ended and our champion in todays fight is the Goblin.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Ork Healthpoints:      | { Ork.Lifepoints}
| Goblin Healthpoints:   | { Goblin.Lifepoints}");
                    }
                    else if (Goblin.Lifepoints <= 0)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Ork and Goblin ended and our champion in todays fight is the Ork.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Ork Healthpoints:      | { Ork.Lifepoints}
| Goblin Healthpoints:   | { Goblin.Lifepoints}");
                    }
                    else if (rounds >= 100)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Ork and Goblin took to long and ended in a draw.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Ork Healthpoints:      | { Ork.Lifepoints}
| Goblin Healthpoints:   | { Goblin.Lifepoints}");
                    }
                }
                else if (Goblin.StartFight)
                {
                    while (Ork.Lifepoints > 0 && Goblin.Lifepoints > 0 && rounds < 100)
                    {
                        rounds++;
                        switch (whoAttacks)
                        {
                            case 0:
                                Goblin.Attack(Ork);
                                whoAttacks += 1;
                                Sound.PlayRandomAttackSound();
                                Messages.PrintConsoleMessageColor($"Round {rounds}:");
                                Messages.PrintGoblinMessageColor("The Goblin attacks!!");
                                Messages.PrintConsoleMessageColor($"The Ork's life: {Ork.Lifepoints}\nThe Goblin's life: {Goblin.Lifepoints}\n--------------------\n");
                                break;
                            case 1:
                                Ork.Attack(Goblin);
                                whoAttacks -= 1;
                                Sound.PlayRandomAttackSound();
                                Messages.PrintConsoleMessageColor($"Round {rounds}:");
                                Messages.PrintOrkMessageColor("The Ork attacks!!");
                                Messages.PrintConsoleMessageColor($"The Ork's life: {Ork.Lifepoints}\nThe Goblin's life: {Goblin.Lifepoints}\n--------------------\n");
                                break;
                            default:
                                break;
                        }
                        Thread.Sleep(waitTime);
                    }

                    Messages.FightEndMessage();
  
                    if (Ork.Lifepoints <= 0)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Ork and Goblin ended and our champion in todays fight is the Goblin.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Ork Healthpoints:      | { Ork.Lifepoints}
| Goblin Healthpoints:   | { Goblin.Lifepoints}");
                    }
                    else if (Goblin.Lifepoints <= 0)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Ork and Goblin ended and our champion in todays fight is the Ork.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Ork Healthpoints:      | { Ork.Lifepoints}
| Goblin Healthpoints:   | { Goblin.Lifepoints}");
                    }
                    else if (rounds >= 100)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Ork and Goblin took to long and ended in a draw.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Ork Healthpoints:      | { Ork.Lifepoints}
| Goblin Healthpoints:   | { Goblin.Lifepoints}");
                    }
                }
            }
            else if (Goblin.Chosen && Troll.Chosen)
            {
                if (Goblin.StartFight)
                {
                    while (Troll.Lifepoints > 0 && Goblin.Lifepoints > 0 && rounds <= 100)
                    {
                        rounds++;
                        switch (whoAttacks)
                        {
                            case 0:
                                Goblin.Attack(Troll);
                                whoAttacks += 1;
                                Sound.PlayRandomAttackSound();
                                Messages.PrintConsoleMessageColor($"Round {rounds}:");
                                Messages.PrintGoblinMessageColor("The Goblin attacks!!");
                                Messages.PrintConsoleMessageColor($"The Troll's life: {Troll.Lifepoints}\nThe Goblin's life: {Goblin.Lifepoints}\n--------------------\n");
                                break;
                            case 1:
                                Troll.Attack(Goblin);
                                whoAttacks -= 1;
                                Sound.PlayRandomAttackSound();
                                Messages.PrintConsoleMessageColor($"Round {rounds}:");
                                Messages.PrintTrollMessageColor("The Troll attacks!!");
                                Messages.PrintConsoleMessageColor($"The Troll's life: {Troll.Lifepoints}\nThe Goblin's life: {Goblin.Lifepoints}\n--------------------\n");
                                break;
                            default:
                                break;
                        }
                        Thread.Sleep(waitTime);
                    }

                    Messages.FightEndMessage();

                    if (Troll.Lifepoints <= 0)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Troll and Goblin ended and our champion in todays fight is the Goblin.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Troll Healthpoints:    | { Troll.Lifepoints}
| Goblin Healthpoints:   | { Goblin.Lifepoints}");
                    }
                    else if (Goblin.Lifepoints <= 0)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Troll and Goblin ended and our champion in todays fight is the Troll.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Troll Healthpoints:    | { Troll.Lifepoints}
| Goblin Healthpoints:   | { Goblin.Lifepoints}");
                    }
                    else if (rounds >= 100)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Troll and Goblin took to long and ended in a draw.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Troll Healthpoints:    | { Troll.Lifepoints}
| Goblin Healthpoints:   | { Goblin.Lifepoints}");
                    }
                }
                else if (Troll.StartFight)
                {
                    while (Troll.Lifepoints > 0 && Goblin.Lifepoints > 0 && rounds <= 100)
                    {
                        rounds++;
                        switch (whoAttacks)
                        {
                            case 0:
                                Troll.Attack(Goblin);
                                whoAttacks += 1;
                                Sound.PlayRandomAttackSound();
                                Messages.PrintConsoleMessageColor($"Round {rounds}:");
                                Messages.PrintTrollMessageColor("The Troll attacks!!");
                                Messages.PrintConsoleMessageColor($"The Troll's life: {Troll.Lifepoints}\nThe Goblin's life: {Goblin.Lifepoints}\n--------------------\n");
                                break;
                            case 1:
                                Goblin.Attack(Troll);
                                whoAttacks -= 1;
                                Sound.PlayRandomAttackSound();
                                Messages.PrintConsoleMessageColor($"Round {rounds}:");
                                Messages.PrintGoblinMessageColor("The Goblin attacks!!");
                                Messages.PrintConsoleMessageColor($"The Troll's life: {Troll.Lifepoints}\nThe Goblin's life: {Goblin.Lifepoints}\n--------------------\n");
                                break;
                            default:
                                break;
                        }
                        Thread.Sleep(waitTime);
                    }

                    Messages.FightEndMessage();

                    if (Troll.Lifepoints <= 0)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Troll and Goblin ended and our champion in todays fight is the Goblin.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Troll Healthpoints:    | { Troll.Lifepoints}
| Goblin Healthpoints:   | { Goblin.Lifepoints}");
                    }
                    else if (Goblin.Lifepoints <= 0)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Troll and Goblin ended and our champion in todays fight is the Troll.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Troll Healthpoints:    | { Troll.Lifepoints}
| Goblin Healthpoints:   | { Goblin.Lifepoints}");
                    }
                    else if (rounds >= 100)
                    {
                        Messages.PrintConsoleMessageColor($"The fight between the Troll and Goblin took to long and ended in a draw.\n" +
                            $"The fight took {rounds} rounds and ended with the following healthpoints:\n\n" +
                            $@"
|------------------------| ---------
| Troll Healthpoints:    | { Troll.Lifepoints}
| Goblin Healthpoints:   | { Goblin.Lifepoints}");
                    }
                }
            }
        }
    }
}

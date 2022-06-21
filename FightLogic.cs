using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Monsterkampfsimulator
{
    class FightLogic
    {
        // Strings used for the user input
        private string? race1;
        private string? race2;

        // Int used to keep track of how many rounds our fighters fought
        private int rounds = 0;
        // Int used to switch between who of the fighters attack in the given round
        private int whoAttacks = 0;
        // Used to delay each round in our fight
        private int waitTime = 500;
        // Used to check that the user entered a valid input when asking for the 2 fighters
        private bool bNotMatching;

        // Attributes for fighter 1
        private float lifepointsOne = 0f;
        private float attackpowerOne = 0f;
        private float defensepointsOne = 0f;
        private float speedOne = 0f;

        // Attributes for fighter 2
        private float lifepointsTwo = 0f;
        private float attackpowerTwo = 0f;
        private float defensepointsTwo = 0f;
        private float speedTwo = 0f;

        private Ork ork = new Ork(1, "Ork");
        private Troll troll = new Troll(2, "Troll");
        private Goblin goblin = new Goblin(3, "Goblin");

        private List<Monster> allAvailableFighters = new List<Monster>();
        private List<Monster> chosenFighters = new List<Monster>();

        Sound sound = new Sound();
        Messages message = new Messages();

        /** Get methode for race1 **/
        public string FighterOne
        {
            get { return chosenFighters[0].Name; }
        }

        /** Get methode for race2 **/
        public string FighterTwo
        {
            get { return chosenFighters[1].Name; }
        }

        public List<Monster> ChosenFighters
        {
            get { return chosenFighters; }
        }

        /** Asking user for the first fighter **/
        public void GetFighterOneInput()
        {
            allAvailableFighters.Add(ork);
            allAvailableFighters.Add(troll);
            allAvailableFighters.Add(goblin);

            message.PrintConsoleMessageColor("Who will be our first Fighter?\n\n");

            message.DisplayAllAvailableFighters(allAvailableFighters);

            // Doing a do-while loop in order to redo the action until we have a valid input
            do
            {
                race1 = message.UserInputMessage();
                // Switch case in order to set attributes for our first fighter and setting the string to all lower cases to ignore case sensitivity
                switch (race1.ToLower())
                {
                    case "1":
                    case "ork":
                        if (race1.ToLower() == "1")
                            race1 = "Ork";
                        ork.Chosen = true;
                        chosenFighters.Add(ork);
                        bNotMatching = false;
                        break;
                    case "2":
                    case "troll":
                        if (race1.ToLower() == "2")
                            race1 = "Troll";
                        troll.Chosen = true;
                        chosenFighters.Add(troll);
                        bNotMatching = false;
                        break;
                    case "3":
                    case "goblin":
                        if (race1.ToLower() == "3")
                            race1 = "Goblin";
                        goblin.Chosen = true;
                        chosenFighters.Add(goblin);
                        bNotMatching = false;
                        break;
                    default:
                        bNotMatching = true;
                        message.PrintErrorColor("Please make sure that you write the fighters names correctly!\n");
                        break;
                }
            } while (bNotMatching);

            for (int i = 0; i < allAvailableFighters.Count; i++)
            {
                if (race1.ToLower() == allAvailableFighters[i].Name.ToLower())
                {
                    allAvailableFighters.RemoveAt(i);
                }
            }
            Console.WriteLine("race1: " + race1);
        }

        /** Asking user for the second fighter **/
        public void GetFighterTwoInput()
        {
            do
            {

                message.PrintConsoleMessageColor("Who will be the 2nd Fighter?\n\n");

                message.DisplayAllAvailableFighters(allAvailableFighters);

                race2 = message.UserInputMessage();

                // We check if the user selected the same race again and print a message if he did so. Otherwise we use a 2nd switch statement to create the 2nd fighter object.
                if (race2.ToLower() == chosenFighters[0].Name.ToLower() || race2.ToLower() == chosenFighters[0].Number.ToString())
                {
                    message.PrintErrorColor($"{race1} was already chosen as the first fighter! Please chose one of the other two that are available\n----------------");
                    bNotMatching = true;
                }
                else
                {
                    switch (race2.ToLower())
                    {
                        case "1":
                        case "ork":
                            if (race2.ToLower() == "1")
                                race1 = "Ork";
                            ork.Chosen = true;
                            chosenFighters.Add(ork);
                            bNotMatching = false;
                            break;
                        case "2":
                        case "troll":
                            if (race2.ToLower() == "2")
                                race1 = "Troll";
                            troll.Chosen = true;
                            chosenFighters.Add(troll);
                            bNotMatching = false;
                            break;
                        case "3":
                        case "goblin":
                            if (race2.ToLower() == "3")
                                race1 = "Goblin";
                            goblin.Chosen = true;
                            chosenFighters.Add(goblin);
                            bNotMatching = false;
                            break;
                        default:
                            bNotMatching = true;
                            message.PrintErrorColor("Please make sure that you write the fighters names correctly!\n");
                            break;
                    }
                }

            } while (bNotMatching);
        }

        /** Function to collect the stats of the 1st fighter **/
        public void GetFighterOneStats()
        {
            // Created a bool for the do while loops
            bool bNegativeValue;
            float result;

            do
            {
                // Asking for the Health value
                message.PrintConsoleMessageColor($"Please give the {chosenFighters[0].Name} a positive Health value:");

                Console.ForegroundColor = message.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    lifepointsOne = result;
                }
                else
                {
                    message.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();

                // Checking that the entered value is positive
                if (lifepointsOne > 0)
                {
                    bNegativeValue = false;
                    chosenFighters[0].Lifepoints = lifepointsOne;
                }
                else
                {
                    message.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

            do
            {
                // Asking for the Attackpower value
                message.PrintConsoleMessageColor($"Please give the {chosenFighters[0].Name} a positive Attackpower value:");
                Console.ForegroundColor = message.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    attackpowerOne = result;
                }
                else
                {
                    message.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive
                if (attackpowerOne > 0)
                {
                    bNegativeValue = false;
                    chosenFighters[0].Attackpower = attackpowerOne;
                }
                else
                {
                    message.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

            do
            {
                // Asking for the Defensepoint value
                message.PrintConsoleMessageColor($"Please give the {chosenFighters[0].Name} a positive Defensepoint value:");
                Console.ForegroundColor = message.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    defensepointsOne = result;
                }
                else
                {
                    message.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive
                if (defensepointsOne > 0)
                {
                    bNegativeValue = false;
                    chosenFighters[0].Defensepoints = defensepointsOne;
                }
                else
                {
                    message.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

            do
            {
                // Asking for the Speed value
                message.PrintConsoleMessageColor($"Please give the {chosenFighters[0].Name} a positive Speed value:");
                Console.ForegroundColor = message.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    speedOne = result;
                }
                else
                {
                    message.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive
                if (speedOne > 0)
                {
                    bNegativeValue = false;
                    chosenFighters[0].Speed = speedOne;
                }
                else
                {
                    message.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

        }

        /** Function to collect the stats of the 2nd fighter **/
        public void GetFighterTwoStats()
        {
            // Created a bool for the do while loops
            bool bNegativeValue;
            float result;

            do
            {
                // Asking for the Health value
                message.PrintConsoleMessageColor($"Please give the {chosenFighters[1].Name} a positive Health value:");
                Console.ForegroundColor = message.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    lifepointsTwo = result;
                }
                else
                {
                    message.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive
                if (lifepointsTwo > 0)
                {
                    bNegativeValue = false;
                    chosenFighters[1].Lifepoints = lifepointsTwo;
                }
                else
                {
                    message.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

            do
            {
                // Asking for the Attackpower value
                message.PrintConsoleMessageColor($"Please give the {chosenFighters[1].Name} a positive Attackpower value:");
                Console.ForegroundColor = message.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    attackpowerTwo = result;
                }
                else
                {
                    message.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive
                if (attackpowerTwo > 0)
                {
                    bNegativeValue = false;
                    chosenFighters[1].Attackpower = attackpowerTwo;
                }
                else
                {
                    message.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

            do
            {
                // Asking for the Defensepoint value
                message.PrintConsoleMessageColor($"Please give the {chosenFighters[1].Name} a positive Defensepoint value:");
                Console.ForegroundColor = message.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    defensepointsTwo = result;
                }
                else
                {
                    message.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive
                if (defensepointsTwo > 0)
                {
                    bNegativeValue = false;
                    chosenFighters[1].Defensepoints = defensepointsTwo;
                }
                else
                {
                    message.PrintErrorColor("Please make sure to only enter positive values!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);

            do
            {
                // Asking for the Speed value
                message.PrintConsoleMessageColor($"Please give the {chosenFighters[1].Name} a positive Speed value:");
                Console.ForegroundColor = message.green;
                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                if (float.TryParse(Console.ReadLine(), out result))
                {
                    speedTwo = result;
                }
                else
                {
                    message.PrintErrorColor("\nMake sure to only enter a numeric value!\n--------------------------");
                }
                Console.ResetColor();
                // Checking that the entered value is positive and doesn't match the first speed value
                if (speedTwo > 0 && speedTwo != speedOne)
                {
                    bNegativeValue = false;
                    chosenFighters[1].Speed = speedTwo;
                }
                else
                {
                    message.PrintErrorColor("Please make sure to only enter positive values and not the same value as you did for the first fighter!");
                    bNegativeValue = true;
                }
            } while (bNegativeValue);
        }

        /** Comparing speeds and setting the start boolean for the fight **/
        public void WhoStartsFight()
        {
            if (chosenFighters[0].Speed > chosenFighters[1].Speed)
            {

                chosenFighters[0].StartFight = true;
            }
            else
            {
                chosenFighters[1].StartFight = true;
            }
        }

        /** Starting the fight and ending it when either fighter has no health left or the fight took more than 100 rounds **/
        public void StartFight()
        {

            if (chosenFighters[0].StartFight)
            {
                // The fight goes on until one of the fighters has 0 or less Lifepoints or we reached 100 rounds in total
                while (chosenFighters[0].Lifepoints > 0 && chosenFighters[1].Lifepoints > 0 && rounds < 100)
                {
                    // For each iteration of the while loop we add 1 to the variable rounds in order to use it in Console.WriteLine statements and to stop a potential endless loop
                    rounds++;
                    switch (whoAttacks)
                    {
                        case 0:
                            chosenFighters[0].Attack(chosenFighters[1]);
                            whoAttacks += 1;
                            //sound.PlayRandomAttackSound();
                            message.PrintConsoleMessageColor($"Round {rounds}:");
                            message.PrintOrkMessageColor($"The {chosenFighters[0].Name} attacks!!");
                            message.PrintConsoleMessageColor($"The {chosenFighters[0].Name}'s life: {chosenFighters[0].Lifepoints}\nThe {chosenFighters[1].Name}'s life: {chosenFighters[1].Lifepoints}\n--------------------\n");
                            break;
                        case 1:
                            chosenFighters[1].Attack(chosenFighters[0]);
                            whoAttacks -= 1;
                            //sound.PlayRandomAttackSound();
                            message.PrintConsoleMessageColor($"Round {rounds}:");
                            message.PrintTrollMessageColor($"The {chosenFighters[1].Name} attacks!!");
                            message.PrintConsoleMessageColor($"The {chosenFighters[0].Name}'s life: {chosenFighters[0].Lifepoints}\nThe {chosenFighters[1].Name}'s life: {chosenFighters[1].Lifepoints}\n--------------------\n");
                            break;
                        default:
                            break;
                    }
                    Thread.Sleep(waitTime);
                }

                message.FightEndMessage(chosenFighters[0], chosenFighters[1], rounds);

            }
            else if (chosenFighters[1].StartFight)
            {
                while (chosenFighters[0].Lifepoints > 0 && chosenFighters[1].Lifepoints > 0 && rounds < 100)
                {
                    rounds++;
                    switch (whoAttacks)
                    {
                        case 0:
                            chosenFighters[1].Attack(chosenFighters[0]);
                            whoAttacks += 1;
                            //sound.PlayRandomAttackSound();
                            message.PrintConsoleMessageColor($"Round {rounds}:");
                            message.PrintTrollMessageColor($"The {chosenFighters[1].Name} attacks!!");
                            message.PrintConsoleMessageColor($"The {chosenFighters[0].Name}'s life: {chosenFighters[0].Lifepoints}\nThe {chosenFighters[1].Name}'s life: {chosenFighters[1].Lifepoints}\n--------------------\n");
                            break;
                        case 1:
                            chosenFighters[0].Attack(chosenFighters[1]);
                            whoAttacks -= 1;
                            //sound.PlayRandomAttackSound();
                            message.PrintConsoleMessageColor($"Round {rounds}:");
                            message.PrintOrkMessageColor($"The {chosenFighters[0].Name} attacks!!");
                            message.PrintConsoleMessageColor($"The {chosenFighters[0].Name}'s life: {chosenFighters[0].Lifepoints}\nThe {chosenFighters[1].Name}'s life: {chosenFighters[1].Lifepoints}\n--------------------\n");
                            break;
                        default:
                            break;
                    }
                    Thread.Sleep(waitTime);
                }

                message.FightEndMessage(chosenFighters[0], chosenFighters[1], rounds);
            }

            message.PrintConsoleMessageColor("\nProgramm will resume in 10 seconds!!");
        }

        /** Clearing all stats if a user decides to play another round **/
        public void ClearAllStats()
        {
            for (int i = 0; i < chosenFighters.Count; i++)
            {
                // Resetting Goblin stats for a new game
                chosenFighters[i].Lifepoints = 0;
                chosenFighters[i].Attackpower = 0;
                chosenFighters[i].Defensepoints = 0;
                chosenFighters[i].Speed = 0;
                chosenFighters[i].Chosen = false;
                chosenFighters[i].StartFight = false;
            }

            rounds = 0;
            chosenFighters.Clear();
            allAvailableFighters.Clear();
        }

        /** Checking if the user wishes to play again or end the programm **/
        public bool PlayAnother(bool playAnother)
        {
            bool notChosen = true;

            message.PrintConsoleMessageColor(@"
██████╗  ██████╗     ██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███████╗██╗  ██╗                                   
██╔══██╗██╔═══██╗    ╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║██╔════╝██║  ██║                                   
██║  ██║██║   ██║     ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║███████╗███████║                                   
██║  ██║██║   ██║      ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║╚════██║██╔══██║                                   
██████╔╝╚██████╔╝       ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║███████║██║  ██║                                   
╚═════╝  ╚═════╝        ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚══════╝╚═╝  ╚═╝                                   
                                                                                                                    
████████╗ ██████╗     ██████╗ ██╗      █████╗ ██╗   ██╗                                                             
╚══██╔══╝██╔═══██╗    ██╔══██╗██║     ██╔══██╗╚██╗ ██╔╝                                                             
   ██║   ██║   ██║    ██████╔╝██║     ███████║ ╚████╔╝                                                              
   ██║   ██║   ██║    ██╔═══╝ ██║     ██╔══██║  ╚██╔╝                                                               
   ██║   ╚██████╔╝    ██║     ███████╗██║  ██║   ██║                                                                
   ╚═╝    ╚═════╝     ╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝                                                                
                                                                                                                    
 █████╗ ███╗   ██╗ ██████╗ ████████╗██╗  ██╗███████╗██████╗     ██████╗  ██████╗ ██╗   ██╗███╗   ██╗██████╗ ██████╗ 
██╔══██╗████╗  ██║██╔═══██╗╚══██╔══╝██║  ██║██╔════╝██╔══██╗    ██╔══██╗██╔═══██╗██║   ██║████╗  ██║██╔══██╗╚════██╗
███████║██╔██╗ ██║██║   ██║   ██║   ███████║█████╗  ██████╔╝    ██████╔╝██║   ██║██║   ██║██╔██╗ ██║██║  ██║  ▄███╔╝
██╔══██║██║╚██╗██║██║   ██║   ██║   ██╔══██║██╔══╝  ██╔══██╗    ██╔══██╗██║   ██║██║   ██║██║╚██╗██║██║  ██║  ▀▀══╝ 
██║  ██║██║ ╚████║╚██████╔╝   ██║   ██║  ██║███████╗██║  ██║    ██║  ██║╚██████╔╝╚██████╔╝██║ ╚████║██████╔╝  ██╗   
╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝    ╚═╝   ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝    ╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝╚═════╝   ╚═╝   
                                                                                                                    
                                                                                                                    
                                                                                                                    
                                                                                                                    
                                                                                                                    
                                                                                                                    
                                                                                                                    
                                                                                                                    
██╗   ██╗ ██╗███╗   ██╗██████╗                                                                                      
╚██╗ ██╔╝██╔╝████╗  ██║╚════██╗                                                                                     
 ╚████╔╝██╔╝ ██╔██╗ ██║  ▄███╔╝                                                                                     
  ╚██╔╝██╔╝  ██║╚██╗██║  ▀▀══╝                                                                                      
   ██║██╔╝   ██║ ╚████║  ██╗                                                                                        
   ╚═╝╚═╝    ╚═╝  ╚═══╝  ╚═╝");

            do
            {
                string userm = message.UserInputMessage();
                switch (userm.ToLower())
                {
                    case "yes":
                    case "y":
                        Console.Clear();
                        ClearAllStats();
                        notChosen = false;
                        playAnother = true;
                        break;
                    case "no":
                    case "n":
                        notChosen = false;
                        playAnother = false;
                        Environment.Exit(0);
                        break;
                    default:
                        message.PrintErrorColor("\nMake sure to answer the question with a Yes/y or No/n!\n--------------------------");
                        break;
                }
            } while (notChosen);
            return playAnother;
        }
    }
}

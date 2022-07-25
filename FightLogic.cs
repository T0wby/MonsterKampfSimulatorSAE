using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Monsterkampfsimulator
{
    class FightLogic
    {
        // Strings used for the user input
        private string? race;

        // Int used to keep track of how many rounds our fighters fought
        private int rounds = 0;
        private int fighterAmount = 2;
        // Int used to switch between who of the fighters attack in the given round
        private int whoAttacks = 0;
        // Used to delay each round in our fight
        private int waitTime = 500;
        // Used to check that the user entered a valid input when asking for the 2 fighters
        private bool bNotMatching;

        private Ork ork = new Ork(1, "Ork");
        private Troll troll = new Troll(2, "Troll");
        private Goblin goblin = new Goblin(3, "Goblin");

        private List<Monster> allAvailableFighters = new List<Monster>();
        private List<Monster> chosenFighters = new List<Monster>();


        #region Properties
        public string FighterOne
        {
            get { return chosenFighters[0].Name; }
        }

        public string FighterTwo
        {
            get { return chosenFighters[1].Name; }
        }

        public List<Monster> ChosenFighters
        {
            get { return chosenFighters; }
        }
        #endregion

        /// <summary>
        /// Asking the user for our fighters
        /// </summary>
        public void GetFighter()
        {
            allAvailableFighters.Add(ork);
            allAvailableFighters.Add(troll);
            allAvailableFighters.Add(goblin);

            for (int i = 0; i < fighterAmount; i++)
            {
                Messages.PrintConsoleMessageColor($"Who will be fighter number {i + 1} from {fighterAmount}?\n\n");
                Messages.DisplayAllAvailableFighters(allAvailableFighters);

                do
                {
                    race = Messages.UserInputMessage();

                    if (i>0)
                    {
                        if (race.ToLower() == chosenFighters[0].Name.ToLower() || race.ToLower() == chosenFighters[0].Number.ToString())
                        {
                            Messages.PrintErrorColor($"{race} was already chosen as the first fighter! Please chose one of the other two that are available\n----------------");
                            bNotMatching = true;
                        }
                        else
                        {
                            SetFighter();
                        }
                    }
                    else
                    {
                        SetFighter();
                    }
                } while (bNotMatching);

                for (int j = 0; j < allAvailableFighters.Count; j++)
                {
                    if (race.ToLower() == allAvailableFighters[j].Name.ToLower())
                    {
                        allAvailableFighters.RemoveAt(j);
                    }
                }
                Console.WriteLine($"\nFighter number {i + 1} is: {race}");
            }
        }

        /// <summary>
        /// Switch case in order to set our active fighters and setting the string to all lower cases to ignore case sensitivity
        /// </summary>
        private void SetFighter()
        {
            switch (race.ToLower())
            {
                case "1":
                case "ork":
                    if (race.ToLower() == "1")
                        race = "Ork";
                    ork.Chosen = true;
                    chosenFighters.Add(ork);
                    bNotMatching = false;
                    break;
                case "2":
                case "troll":
                    if (race.ToLower() == "2")
                        race = "Troll";
                    troll.Chosen = true;
                    chosenFighters.Add(troll);
                    bNotMatching = false;
                    break;
                case "3":
                case "goblin":
                    if (race.ToLower() == "3")
                        race = "Goblin";
                    goblin.Chosen = true;
                    chosenFighters.Add(goblin);
                    bNotMatching = false;
                    break;
                default:
                    bNotMatching = true;
                    Messages.PrintErrorColor("Please make sure that you write the fighters names correctly!\n");
                    break;
            }
        }


        /// <summary>
        /// Function to collect the stats of all fighters
        /// </summary>
        public void GetFighterStats()
        {

            for (int i = 0; i < fighterAmount; i++)
            {
                // Asking for the Health value
                Messages.PrintConsoleMessageColor($"\nPlease give the {chosenFighters[i].Name} a positive Health value:");

                // Due to Console.ReadLine() returning a string value we parse it into the required float value with float.TryParse() and also check if any other value than a numeric one was used
                chosenFighters[i].Lifepoints = Messages.UserInputFloat();


                // Asking for the Attackpower value
                Messages.PrintConsoleMessageColor($"Please give the {chosenFighters[i].Name} a positive Attackpower value:");

                chosenFighters[i].Attackpower = Messages.UserInputFloat();


                // Asking for the Defensepoint value
                Messages.PrintConsoleMessageColor($"Please give the {chosenFighters[i].Name} a positive Defensepoint value:");

                chosenFighters[i].Defensepoints = Messages.UserInputFloat();


                // Asking for the Speed value
                Messages.PrintConsoleMessageColor($"Please give the {chosenFighters[i].Name} a positive Speed value:");

                if (i > 0)
                {
                    do
                    {
                        chosenFighters[i].Speed = Messages.UserInputFloat();
                        if (chosenFighters[i].Speed == chosenFighters[i - 1].Speed)
                            Messages.PrintErrorColor($"\nPlease make sure that {chosenFighters[i].Name} and {chosenFighters[i - 1].Name} have differant speed values!\n");
                        else
                            break;
                    } while (true);
                }
                else
                {
                    chosenFighters[i].Speed = Messages.UserInputFloat();
                }

                if (i<1)
                {
                    Console.Clear();

                    // Showing the selected stats for the first fighter, so that the User can compare them while setting the 2nd fighter.
                    Messages.ShowStatsFighterOne(chosenFighters[0]);
                }
                else
                {
                    // Message between the collection of the stats of both fighters.
                    Messages.TransitionMessage(chosenFighters[0], chosenFighters[1]);
                }
            }
            
        }

        /// <summary>
        /// Comparing the speed of the fighters and setting the start boolean for the fight
        /// </summary>
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

        /// <summary>
        /// Starting the fight and ending it when one of the fighters has no health left or the fight took more than 100 rounds
        /// </summary>
        /// <param name="sound">Sound object from which we call PlayRandomAttackSound()</param>
        public void StartFight(Sound sound)
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
                            sound.PlayRandomAttackSound();
                            Messages.PrintConsoleMessageColor($"Round {rounds}:");
                            Messages.PrintYellowMessageColor($"The {chosenFighters[0].Name} attacks!!");
                            Messages.PrintConsoleMessageColor($"The {chosenFighters[0].Name}'s life: {chosenFighters[0].Lifepoints}\nThe {chosenFighters[1].Name}'s life: {chosenFighters[1].Lifepoints}\n--------------------\n");
                            break;
                        case 1:
                            chosenFighters[1].Attack(chosenFighters[0]);
                            whoAttacks -= 1;
                            sound.PlayRandomAttackSound();
                            Messages.PrintConsoleMessageColor($"Round {rounds}:");
                            Messages.PrintDarkGreenMessageColor($"The {chosenFighters[1].Name} attacks!!");
                            Messages.PrintConsoleMessageColor($"The {chosenFighters[0].Name}'s life: {chosenFighters[0].Lifepoints}\nThe {chosenFighters[1].Name}'s life: {chosenFighters[1].Lifepoints}\n--------------------\n");
                            break;
                        default:
                            break;
                    }
                    Thread.Sleep(waitTime);
                }

                Messages.FightEndMessage(chosenFighters[0], chosenFighters[1], rounds);

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
                            sound.PlayRandomAttackSound();
                            Messages.PrintConsoleMessageColor($"Round {rounds}:");
                            Messages.PrintDarkGreenMessageColor($"The {chosenFighters[1].Name} attacks!!");
                            Messages.PrintConsoleMessageColor($"The {chosenFighters[0].Name}'s life: {chosenFighters[0].Lifepoints}\nThe {chosenFighters[1].Name}'s life: {chosenFighters[1].Lifepoints}\n--------------------\n");
                            break;
                        case 1:
                            chosenFighters[0].Attack(chosenFighters[1]);
                            whoAttacks -= 1;
                            sound.PlayRandomAttackSound();
                            Messages.PrintConsoleMessageColor($"Round {rounds}:");
                            Messages.PrintYellowMessageColor($"The {chosenFighters[0].Name} attacks!!");
                            Messages.PrintConsoleMessageColor($"The {chosenFighters[0].Name}'s life: {chosenFighters[0].Lifepoints}\nThe {chosenFighters[1].Name}'s life: {chosenFighters[1].Lifepoints}\n--------------------\n");
                            break;
                        default:
                            break;
                    }
                    Thread.Sleep(waitTime);
                }

                Messages.FightEndMessage(chosenFighters[0], chosenFighters[1], rounds);
            }

            Messages.PrintConsoleMessageColor("\nProgramm will resume in 10 seconds!!");
        }

        /// <summary>
        /// Clearing all stats if a user decides to play another round
        /// </summary>
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

        /// <summary>
        /// Checking if the user wishes to play again or end the programm
        /// </summary>
        /// <param name="playAnother">Bool from the main programm</param>
        /// <returns>Returns a bool depending on the user input</returns>
        public bool PlayAnother(bool playAnother)
        {
            bool notChosen = true;

            Messages.PrintConsoleMessageColor(@"
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
                string userm = Messages.UserInputMessage();
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
                        Messages.PrintErrorColor("\nMake sure to answer the question with a Yes/y or No/n!\n--------------------------");
                        break;
                }
            } while (notChosen);
            return playAnother;
        }
    }
}

using System;
using System.Media;
using System.Threading;

namespace Monsterkampfsimulator
{
    class Program
    {
        public static bool playAnother;

        static void Main(string[] args)
        {
            do
            {
                // Build all sounds that are used during the game
                Sound.BuildSound();

                // Starting with setting the console size if possible, writing a text and looping the main song
                Messages.WelcomeMessage(Sound.MenuStartSound);

                // While loop which ends as soon as we get the correct input
                Messages.WaitingForSKey();

                // ASCII messages for the first display of available fighters
                Messages.DisplayFightersOne();

                // Getting the User input and setting the first fighter
                FightLogic.GetFighterOneInput();

                Console.Clear();

                // Getting the User input and setting the second fighter
                FightLogic.GetFighterTwoInput();

                Console.Clear();

                // Now we start asking the user to enter the stats for each of the two fighters
                Messages.ExplanationMessage();

                // Function that gets all the input for the first fighter
                FightLogic.GetFighterOneStats();

                // Getting the speed of the first chosen fighter and then setting the variable to use it later as a comparison in GetFighterTwoStats()
                FightLogic.SettingCompareSpeed();

                Console.Clear();

                // Showing the selected stats for the first fighter
                FightLogic.ShowStatsFighterOne();

                // Message between the collection of the stats of both fighters
                Messages.TransitionMessage();

                // Created a private function that gets all the input for the second fighter to try and keep the code more organized
                FightLogic.GetFighterTwoStats();

                // Deciding who starts the fight and then setting the bool which is later used to check which Monster gets the first Attack
                FightLogic.WhoStartsFight();

                Console.Clear();

                // Message ending the attribute collection
                Messages.AttributeEndMessage();

                // Visualization of the final attributes
                FightLogic.ShowStatsBothFighters();

                // Waiting for an input to continue the code in order to not overwhelm the user
                Console.ReadKey();

                // Starting sound for the fight in Async and Sync to make sure the sound is getting loaded properly and played fully as well
                Messages.StartFightMessageAndSound(Sound.FightStartSound);

                // Starting the fight by checking which fighters were chosen by the user
                FightLogic.StartFight();

                // Play sound at the end
                Sound.PlayEndSound();

                // Delay to Display end screen before we proceed
                Thread.Sleep(10000);

                // Credits
                Messages.Credits();

                // Last part of our game loop. Player gets the choice to end the game or play another round
                FightLogic.PlayAnother();

            } while (playAnother);
        }
    }
}

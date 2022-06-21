using System;
using System.Media;
using System.Threading;

namespace Monsterkampfsimulator
{
    class Program
    {
        public static bool playAnother;
        private static FightLogic fl = new FightLogic();
        private static Sound sound = new Sound();
        private static Messages ms = new Messages();

        static void Main(string[] args)
        {
            do
            {
                // Build all sounds that are used during the game
                sound.BuildSound();

                // Starting with setting the console size if possible, writing a text and looping the main song
                ms.WelcomeMessage(sound.MenuStartSound);

                // While loop which ends as soon as we get the correct input
                ms.WaitingForSKey();

                // ASCII messages for the first display of available fighters
                ms.DisplayFightersOne();

                // Getting the User input and setting the first fighter
                fl.GetFighterOneInput();

                Console.Clear();

                // Getting the User input and setting the second fighter
                fl.GetFighterTwoInput();

                Console.Clear();

                // Now we start asking the user to enter the stats for each of the two fighters
                ms.ExplanationMessage();

                // Function that gets all the input for the first fighter
                fl.GetFighterOneStats();

                // Getting the speed of the first chosen fighter and then setting the variable to use it later as a comparison in GetFighterTwoStats()
                fl.SettingCompareSpeed();

                Console.Clear();

                // Showing the selected stats for the first fighter
                fl.ShowStatsFighterOne();

                // Message between the collection of the stats of both fighters
                ms.TransitionMessage();

                // Created a private function that gets all the input for the second fighter to try and keep the code more organized
                fl.GetFighterTwoStats();

                // Deciding who starts the fight and then setting the bool which is later used to check which Monster gets the first Attack
                fl.WhoStartsFight();

                Console.Clear();

                // Message ending the attribute collection
                ms.AttributeEndMessage();

                // Visualization of the final attributes
                fl.ShowStatsBothFighters();

                // Waiting for an input to continue the code in order to not overwhelm the user
                Console.ReadKey();

                // Starting sound for the fight in Async and Sync to make sure the sound is getting loaded properly and played fully as well
                ms.StartFightMessageAndSound(sound.FightStartSound);

                // Starting the fight by checking which fighters were chosen by the user
                fl.StartFight();

                // Play sound at the end
                sound.PlayEndSound();

                // Delay to Display end screen before we proceed
                Thread.Sleep(10000);

                // Credits
                ms.Credits();

                // Last part of our game loop. Player gets the choice to end the game or play another round
                fl.PlayAnother();

            } while (playAnother);
        }
    }
}

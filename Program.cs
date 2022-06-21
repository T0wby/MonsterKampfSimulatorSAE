namespace Monsterkampfsimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAnother = false;
            FightLogic fightLogic = new FightLogic();
            Sound sound = new Sound();
            Messages messages = new Messages();

            // Build all sounds that are used during the game
            sound.BuildSound();

            do
            {
                // Starting with setting the console size if possible, writing a text and looping the main song.
                messages.WelcomeMessage(sound.MenuStartSound);

                // While loop which ends as soon as we get the correct input. Extra function to create a start menu.
                messages.WaitingForSKey();

                // Displaying all available fighters. Getting the User input and setting the first fighter.
                fightLogic.GetFighterOneInput();

                Console.Clear();

                // Getting the User input and setting the second fighter.
                fightLogic.GetFighterTwoInput();

                Console.Clear();

                // Now we start asking the user to enter the stats for each of the two fighters.
                messages.ExplanationMessage(fightLogic.FighterOne);

                // Function that gets all the stats for the first fighter.
                fightLogic.GetFighterOneStats();

                Console.Clear();

                // Showing the selected stats for the first fighter, so that the User can compare them while setting the 2nd fighter.
                messages.ShowStatsFighterOne(fightLogic.ChosenFighters[0]);

                // Message between the collection of the stats of both fighters.
                messages.TransitionMessage(fightLogic.FighterOne, fightLogic.FighterTwo);

                // Function that gets all the stats for the second fighter.
                fightLogic.GetFighterTwoStats();

                // Deciding who starts the fight and then setting the bool which is later used to check which fighter gets the first Attack.
                fightLogic.WhoStartsFight();

                Console.Clear();

                // Showing the selected stats for the both fighters as an overview.
                messages.ShowStatsBothFighters(fightLogic.ChosenFighters[0], fightLogic.ChosenFighters[1]);

                // Message ending the stats collection and prompting the user to press a button in order to continue.
                messages.CollectionEndMessage(fightLogic.FighterOne, fightLogic.FighterTwo);

                // Waiting for an input to continue the code in order to not overwhelm the user.
                Console.ReadKey();

                // Starting sound for the fight in Async and Sync to make sure the sound is getting loaded properly and played fully as well.
                messages.StartFightMessageAndSound(sound.FightStartSound);

                // Starting the fight and ending it when either fighter has no health left or the fight took more than 100 rounds.
                fightLogic.StartFight();

                // Playing our end sound.
                //sound.PlayEndSound();

                // Delay to Display end screen before we proceed with credits and PlayAnother().
                Thread.Sleep(10000);

                // Credits which contains links to all external sources for the sound and ascii art used in this project.
                messages.Credits();

                // Last part of our game loop. Player gets the choice to end the game or play another round.
                playAnother = fightLogic.PlayAnother(playAnother);

            } while (playAnother);
        }
    }
}
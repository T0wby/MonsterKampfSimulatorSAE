namespace Monsterkampfsimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAnother = false;
            FightLogic fightLogic = new FightLogic();
            Sound sound = new Sound();

            // Build all sounds that are used during the game
            sound.BuildSound();

            do
            {
                // Starting with setting the console size if possible, writing a text and looping the main song.
                Messages.WelcomeMessage(sound.MenuStartSound);

                // While loop which ends as soon as we get the correct input. Extra function to create a start menu.
                Messages.WaitingForKey('s');

                // Displaying all available fighters. Getting the User input and setting the all fighters.
                fightLogic.GetFighter();

                Console.Clear();

                // Now we start asking the user to enter the stats for each of the two fighters.
                Messages.ExplanationMessage(fightLogic.FighterOne);

                // Function that gets all the stats for the first fighter.
                fightLogic.GetFighterStats();

                // Deciding who starts the fight and then setting the bool which is later used to check which fighter gets the first Attack.
                fightLogic.WhoStartsFight();

                Console.Clear();

                // Showing the selected stats for the both fighters as an overview.
                Messages.ShowStatsBothFighters(fightLogic.ChosenFighters[0], fightLogic.ChosenFighters[1]);

                // Message ending the stats collection and prompting the user to press a button in order to continue.
                Messages.CollectionEndMessage(fightLogic.FighterOne, fightLogic.FighterTwo);

                // Waiting for an input to continue the code in order to not overwhelm the user.
                Console.ReadKey();

                // Starting sound for the fight in Async and Sync to make sure the sound is getting loaded properly and played fully as well.
                Messages.StartFightMessageAndSound(sound.FightStartSound);

                // Starting the fight and ending it when either fighter has no health left or the fight took more than 100 rounds.
                fightLogic.StartFight(sound);

                // Playing our end sound.
                sound.PlayEndSound();

                // Delay to Display end screen before we proceed with credits and PlayAnother().
                Thread.Sleep(10000);

                // Credits which contains links to all external sources for the sound and ascii art used in this project.
                Messages.Credits();

                // Last part of our game loop. Player gets the choice to end the game or play another round.
                playAnother = fightLogic.PlayAnother(playAnother);

            } while (playAnother);
        }
    }
}
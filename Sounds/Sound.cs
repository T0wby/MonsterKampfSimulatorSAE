using System;
using System.Collections.Generic;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;

namespace Monsterkampfsimulator
{
    class Sound
    {
        public SoundPlayer? punchOnePlayer;
        public SoundPlayer? punchTwoPlayer;
        public SoundPlayer? punchThreePlayer;
        public SoundPlayer? punchFourPlayer;
        public SoundPlayer? punchFivePlayer;
        public SoundPlayer? punchSixPlayer;
        public SoundPlayer? punchSevenPlayer;
        public SoundPlayer? punchEightPlayer;
        public SoundPlayer? MenuStartSound;
        public SoundPlayer? FightStartSound;
        public SoundPlayer? FightEndSound;
        public SoundPlayer[]? allPunches;

        /** Build all sounds used during the game **/
        public void BuildSound()
        {
            // Building the sound players(works on windows only)
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Setting all punch sounds
                punchOnePlayer = new SoundPlayer("Sounds/punch1.wav");
                punchTwoPlayer = new SoundPlayer("Sounds/punch2.wav");
                punchThreePlayer = new SoundPlayer("Sounds/punch3.wav");
                punchFourPlayer = new SoundPlayer("Sounds/punch4.wav");
                punchFivePlayer = new SoundPlayer("Sounds/punch5.wav");
                punchSixPlayer = new SoundPlayer("Sounds/punch6.wav");
                punchSevenPlayer = new SoundPlayer("Sounds/punch7.wav");
                punchEightPlayer = new SoundPlayer("Sounds/punch8.wav");
                MenuStartSound = new SoundPlayer("Sounds/dramatic-scroller.wav");
                FightStartSound = new SoundPlayer("Sounds/Countdown.wav");
                FightEndSound = new SoundPlayer("Sounds/gameover.wav");
                // Creating an array to randomly play sounds during the fight
                allPunches = new SoundPlayer[] { punchOnePlayer, punchTwoPlayer, punchThreePlayer, punchFourPlayer, punchFivePlayer, punchSixPlayer, punchSevenPlayer, punchEightPlayer };
            }
        }

        /** Randomized attack sounds **/
        public void PlayRandomAttackSound()
        {
            Random rnd = new Random((DateTime.Now.Second * DateTime.Now.Millisecond + DateTime.Now.Hour));
            int rndNumber = rnd.Next(0, 7);

            allPunches[rndNumber].Load();
            allPunches[rndNumber].Play();
        }

        /** Sound which is played after the fight finished **/
        public void PlayEndSound()
        {
            FightEndSound.LoadAsync();
            FightEndSound.PlaySync();
        }
    }
}

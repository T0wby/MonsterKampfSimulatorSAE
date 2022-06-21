using System;
using System.Collections.Generic;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;

namespace Monsterkampfsimulator
{
    static class Sound
    {
        public static SoundPlayer punchOnePlayer;
        public static SoundPlayer punchTwoPlayer;
        public static SoundPlayer punchThreePlayer;
        public static SoundPlayer punchFourPlayer;
        public static SoundPlayer punchFivePlayer;
        public static SoundPlayer punchSixPlayer;
        public static SoundPlayer punchSevenPlayer;
        public static SoundPlayer punchEightPlayer;
        public static SoundPlayer MenuStartSound;
        public static SoundPlayer FightStartSound;
        public static SoundPlayer FightEndSound;
        public static SoundPlayer[] allPunches;

        /** Build all sounds used during the game **/
        public static void BuildSound()
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
        public static void PlayRandomAttackSound()
        {
            Random rnd = new Random((DateTime.Now.Second * DateTime.Now.Millisecond + DateTime.Now.Hour));
            int rndNumber = rnd.Next(1, 8);

            switch (rndNumber)
            {
                case 1:
                    allPunches[0].Load();
                    allPunches[0].Play();
                    break;
                case 2:
                    allPunches[1].Load();
                    allPunches[1].Play();
                    break;
                case 3:
                    allPunches[2].Load();
                    allPunches[2].Play();
                    break;
                case 4:
                    allPunches[3].Load();
                    allPunches[3].Play();
                    break;
                case 5:
                    allPunches[4].Load();
                    allPunches[4].Play();
                    break;
                case 6:
                    allPunches[5].Load();
                    allPunches[5].Play();
                    break;
                case 7:
                    allPunches[6].Load();
                    allPunches[6].Play();
                    break;
                case 8:
                    allPunches[7].Load();
                    allPunches[7].Play();
                    break;
            }
        }

        /** Sound which is played after the fight finished **/
        public static void PlayEndSound()
        {
            FightEndSound.LoadAsync();
            FightEndSound.PlaySync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PACMAN;

namespace Pacman
{



    internal class DataFile
    {
        public static int Hits;
        public static int HightScore;
        public static int Dificult;
        public static int wins;
        public static bool skin1Locked;
        public static bool skin2Locked;
        public static bool skin3Locked;
        public static bool skin4Locked;
        public static int countCoins;
        public static int currentSkin;

        public static void Dificulty()
        {

            switch (Dificult)
            {
                case 0:
                    Game.speed = 4;

                    Game.moveStep = 4;
                    break;
                case 1:
                    Game.speed = 6;

                    Game.moveStep = 5;
                    break;
                case 2:
                    Game.speed = 6;

                    Game.moveStep = 4;
                    break;

            }
        }



        public static void LoadGameData()
        {


            string[] lines = File.ReadAllLines("gameData.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split('=');
                if (parts.Length == 2)
                {
                    switch (parts[0])
                    {
                        case "skin1Lock":
                            skin1Locked = bool.Parse(parts[1]);
                            break;
                        case "skin2Lock":
                            skin2Locked = bool.Parse(parts[1]);
                            break;
                        case "skin3Lock":
                            skin3Locked = bool.Parse(parts[1]);
                            break;
                        case "countCoins":
                            countCoins = int.Parse(parts[1]);
                            break;
                        case "currentSkin":
                            currentSkin = int.Parse(parts[1]);
                            break;
                        case "HightScore":
                            HightScore = int.Parse(parts[1]);
                            break;
                        case "Hits":
                            Hits = int.Parse(parts[1]);
                            break;
                        case "wins":
                            wins = int.Parse(parts[1]);
                            break;
                    }
                }
            }
        }
        public static void SaveGameData()
        {

            string[] lines = new string[]
            {
                $"skin1Lock={skin1Locked}",
                $"skin2Lock={skin2Locked}",
                $"skin3Lock={skin3Locked}",
                $"countCoins={countCoins}",
                $"currentSkin={currentSkin}",
                $"HightScore={HightScore}",
                $"Hits={Hits}",
                $"wins={wins}"
            };
            File.WriteAllLines("gameData.txt", lines);

        }

    }
}


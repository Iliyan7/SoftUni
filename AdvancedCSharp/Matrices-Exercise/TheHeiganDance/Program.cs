using System;

namespace TheHeiganDance
{
    public class Program
    {
        private const int ChamberSize = 15;
        private const int PlagueCloudDamage = 3500;
        private const int EruptionDamage = 6000;
        private const int PlayerStartHealth = 18500;
        private const double HeiganStartHealth = 3000000;

        public static void Main()
        {
            var takenDamage = double.Parse(Console.ReadLine());

            var playerCurrentPos = new int[] { ChamberSize / 2, ChamberSize / 2 };

            var playerCurrentHP = PlayerStartHealth;
            var heiganCurrentHP = HeiganStartHealth;
            var cloudActive = false;
            var killSpell = String.Empty;

            while (true)
            {
                var args = Console.ReadLine()
                    .Split(' ');

                var spell = args[0];
                var shotRow = int.Parse(args[1]);
                var shotCol = int.Parse(args[2]);

                heiganCurrentHP -= takenDamage;

                if (cloudActive)
                {
                    cloudActive = false;
                    playerCurrentHP -= PlagueCloudDamage;
                }

                if (heiganCurrentHP <= 0 || playerCurrentHP <= 0)
                    break;

                if (IsPlayerInHitZone(playerCurrentPos, shotRow, shotCol))
                {
                    if (!TryMovePlayer(playerCurrentPos, shotRow, shotCol))
                    {
                        if (spell.Equals("Cloud"))
                        {
                            cloudActive = true;
                            playerCurrentHP -= PlagueCloudDamage;
                            killSpell = "Plague Cloud";
                        }
                        else
                        {
                            playerCurrentHP -= EruptionDamage;
                            killSpell = "Eruption";
                        }
                    }
                }

                if (playerCurrentHP <= 0)
                    break;
            }

            Console.WriteLine(heiganCurrentHP <= 0 ? "Heigan: Defeated!" : string.Format("Heigan: {0:F2}", heiganCurrentHP));
            Console.WriteLine(playerCurrentHP <= 0 ? string.Format("Player: Killed by {0}", killSpell) : string.Format("Player: {0}", playerCurrentHP));
            Console.WriteLine("Final position: {0}, {1}", playerCurrentPos[0], playerCurrentPos[1]);
        }

        private static bool IsPlayerInHitZone(int[] playerCurrentPos, int shotRow, int shotCol)
        {
            for (int i = shotRow - 1; i <= shotRow + 1; i++)
            {
                for (int j = shotCol - 1; j <= shotCol + 1; j++)
                {
                    if (playerCurrentPos[0] == i && playerCurrentPos[1] == j)
                        return true;
                }
            }

            return false;
        }

        private static bool TryMovePlayer(int[] playerCurrentPos, int shotRow, int shotCol)
        {
            var playerRow = playerCurrentPos[0];
            var playerCol = playerCurrentPos[1];

            if ((playerRow - 1 >= 0) && (playerRow - 1 < shotRow - 1))
            {
                playerCurrentPos[0]--;
                return true;
            }
            else if ((playerCol + 1 < ChamberSize) && (playerCol + 1 > shotCol + 1))
            {
                playerCurrentPos[1]++;
                return true;
            }
            else if ((playerRow + 1 < ChamberSize) && (playerRow + 1 > shotRow + 1))
            {
                playerCurrentPos[0]++;
                return true;
            }
            else if ((playerCol - 1 >= 0) && (playerCol - 1 < shotCol - 1))
            {
                playerCurrentPos[1]--;
                return true;
            }

            return false;
        }
    }
}

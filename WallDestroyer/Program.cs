using System;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wallSize = int.Parse(Console.ReadLine());

            char[,] wall = new char[wallSize, wallSize];

            int vRow = -1;
            int vCol = -1;

            int holeCounter = 1;
            int rodCounter = 0;
            bool isElectrocuted = false;



            for (int row = 0; row < wallSize; row++)
            {
                string colValues = Console.ReadLine();

                for (int col = 0; col < wallSize; col++)
                {
                    wall[row,col] = colValues[col];
                    if (colValues[col] == 'V')
                    {
                        vRow = row;
                        vCol = col;
                    }
                }
            }

            string direction = string.Empty;

            while ((direction = Console.ReadLine()) != "End")
            {
                int rowToCheck = vRow;
                int colToCheck = vCol;

                switch (direction)
                {
                    case "up":
                        rowToCheck--;
                        break;
                    case "down":
                        rowToCheck++;
                        break;
                    case "left":
                        colToCheck--;
                        break;
                    case "right":
                        colToCheck++;
                        break;
                }

                if (isValidPosition(rowToCheck, colToCheck, wallSize))
                {
                    if (wall[rowToCheck, colToCheck] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        rodCounter++;
                        continue;
                    }

                    if (wall[rowToCheck, colToCheck] == '-')
                    {
                        wall[vRow, vCol] = '*';
                        vRow = rowToCheck;
                        vCol = colToCheck;
                        wall[vRow, vCol] = 'V';
                        holeCounter++;
                        continue;
                    }

                    if (wall[rowToCheck, colToCheck] == '*')
                    {
                        wall[vRow, vCol] = '*';
                        vRow = rowToCheck;
                        vCol = colToCheck;
                        Console.WriteLine($"The wall is already destroyed at position [{vRow}, {vCol}]!");
                        wall[vRow, vCol] = 'V';
                        continue;
                    }

                    if (wall[rowToCheck, colToCheck] == 'C')
                    {
                        wall[vRow, vCol] = '*';
                        vRow = rowToCheck;
                        vCol = colToCheck;
                        wall[vRow, vCol] = 'E';
                        holeCounter++;
                        isElectrocuted = true;
                        break;
                    }
                }
            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holeCounter} hole(s) and he hit only {rodCounter} rod(s).");
            }

            for (int row = 0; row < wallSize; row++)
            {
                for (int col = 0; col < wallSize; col++)
                {
                    Console.Write(wall[row,col]);
                }
                Console.WriteLine();
            }

        }

        private static bool isValidPosition(int rowToCheck, int colToCheck, int wallSize)
        {
            return rowToCheck >= 0 && colToCheck >= 0 & rowToCheck < wallSize && colToCheck < wallSize;
        }
    }
}

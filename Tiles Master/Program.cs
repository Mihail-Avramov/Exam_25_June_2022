using System;
using System.Collections.Generic;
using System.Linq;

namespace Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> greyTiles = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> locationsAreas = new Dictionary<string, int>()
            {
                {"Sink", 40},
                {"Oven", 50},
                {"Countertop", 60},
                {"Wall", 70}
            };

            Dictionary<string, int> decoratedAreas = new Dictionary<string, int>();

            while (whiteTiles.Any() && greyTiles.Any())
            {
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    int newTile = whiteTiles.Pop() + greyTiles.Dequeue();

                    bool tileForFloor = true;

                    foreach (var area in locationsAreas)
                    {
                        if (newTile == area.Value)
                        {
                            tileForFloor = false;
                            string areaName = area.Key;
                            if (!decoratedAreas.ContainsKey(areaName))
                            {
                                decoratedAreas[areaName] = 0;
                            }

                            decoratedAreas[areaName]++;
                            break;
                        }
                    }

                    if (tileForFloor)
                    {
                        string areaName = "Floor";
                        if (!decoratedAreas.ContainsKey(areaName))
                        {
                            decoratedAreas[areaName] = 0;
                        }

                        decoratedAreas[areaName]++;
                    }
                }
                else
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);
                    greyTiles.Enqueue(greyTiles.Dequeue());
                }
            }

            if (whiteTiles.Any())
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (greyTiles.Any())
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var area in decoratedAreas.OrderByDescending(a => a.Value).ThenBy(a => a.Key))
            {
                Console.WriteLine($"{area.Key}: {area.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace MyPacman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            char[,] map = null;
            string[] file = File.ReadAllLines("map.txt");
            map = ReadMap(file);
            int playerX = 1, playerY = 1, score = 0;
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();
            Task.Run(() =>
            {
                while (true)
                {
                    pressedKey = Console.ReadKey();
                }
            });

            while (true)
            {
                DrawMap(map);
                Console.WriteLine($"\nScore = {score}");
                DrawPlayer(playerY, playerX);
                HandleInput(pressedKey, map, ref playerX, ref playerY);

                if (map[playerY, playerX] == '.') 
                {
                    map[playerY, playerX] = ' ';
                    score++;
                }
                Thread.Sleep(100);
                Console.Clear();
            }
            
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, char[,] map, ref int playerX, ref int playerY) 
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[playerY-1, playerX] != '▓') { playerY--; }
                    break;
                case ConsoleKey.DownArrow:
                    if (map[playerY + 1, playerX] != '▓') { playerY++; }
                    break;
                case ConsoleKey.RightArrow:
                    if (map[playerY, playerX+1] != '▓') { playerX++; }
                    break;
                case ConsoleKey.LeftArrow:
                    if (map[playerY, playerX-1] != '▓') { playerX--; }
                    break;
            }
        }

        private static char[,] ReadMap(string[] fileMap) 
        {
            char[,] charMap = new char[fileMap.Length, fileMap[0].Length];

            for (int y = 0; y < fileMap.Length; y++) 
            {
                for (int x = 0; x < fileMap[0].Length; x++) 
                {
                    charMap[y, x] = fileMap[y][x];
                }
            }
            return charMap;
        }

        private static void DrawMap(char[,] map)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static void DrawPlayer(int playerX, int playerY) 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(playerY, playerX);
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

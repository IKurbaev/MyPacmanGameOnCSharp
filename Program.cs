using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyPacman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = null;
            string[] file = File.ReadAllLines("map.txt");
            map = ReadMap(file);
            ShowMap(map);

            Console.ReadKey();
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

        private static void ShowMap(char[,] map)
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
    }
}

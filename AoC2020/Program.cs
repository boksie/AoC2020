using System;
using System.Collections.Generic;
using System.IO;

namespace AoC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new ResultEight();
        }

        public static void Print(string result)
        {
            Console.WriteLine(result);
        }

        public static List<T> ReadData<T>(string fileString, Func<string, T> parser)
        {
            string line;
            var list = new List<T>();

            StreamReader file = new StreamReader(fileString);
            while ((line = file.ReadLine()) != null)
            {
                list.Add(parser(line));
            }

            file.Close();
            return list;
        }
    }
}

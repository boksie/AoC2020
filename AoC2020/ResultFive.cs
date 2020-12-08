using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public class ResultFive
    {
        public ResultFive()
        {
            var lines = Program.ReadData("./input5.txt", i => i);
            var seatIds = new List<int>();
            foreach (var line in lines)
            {
                seatIds.Add(Calculate(line));
            }
            var max = seatIds.Max();
            seatIds.Sort();
            for (int i = 0; i < seatIds.Count - 1; i++)
            {
                if (seatIds[i] + 2 == seatIds[i+1])
                {
                    var res = seatIds[i] + 1;
                }
            }
        }

        private int Calculate(string line)
        {
            Point row = new Point() { Lowest = 0, Highest = 127 };
            Point column = new Point { Lowest = 0, Highest = 7 };
            foreach (var chr in line)
            {
                // upper
                if (chr == 'B')
                {
                    row.Upper();
                }
                // lower
                else if (chr == 'F')
                {
                    row.Lower();
                }
                // upper
                else if (chr == 'R')
                {
                    column.Upper();
                }
                // lower
                else if (chr == 'L')
                {
                    column.Lower();
                }

            }
            return (row.Highest * 8 + column.Highest);
        }

        class Point
        {
            public void Upper()
            {
                Lowest += (Highest - Lowest) / 2 + 1;
            }

            public void Lower()
            {
                Highest -= (Highest - Lowest) / 2 + 1;
            }
            public int Lowest { get; set; }
            public int Highest { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public class ResultThree
    {
        public ResultThree()
        {
            var numbers = Program.ReadData("./input3.txt", (i) => i.ToCharArray());
            var partA = CalcIncounters(numbers, 3);

            var movements = new List<Tuple<int, int>> { new Tuple<int, int>(1, 1), new Tuple<int, int>(3, 1), new Tuple<int, int>(5, 1), new Tuple<int, int>(7, 1), new Tuple<int, int>(1, 2) };
            long totals = 1;
            foreach (var (move, incrementer) in movements)
            {
               var total = CalcIncounters(numbers, move, incrementer);
               totals *= total;
            }

        }

        private int CalcIncounters(List<char[]> slopes, int move, int incrementer = 1)
        {
            int counter = 0;
            var position = 0;

            for (int i = 0; i < slopes.Count; i += incrementer)
            {
                if (slopes[i][position] == '#')
                {
                    counter++;
                }
                position = position + move >= slopes[i].Count() ? position - slopes[i].Count() + move : position += move;
            }
            return counter;
        }
    }
}

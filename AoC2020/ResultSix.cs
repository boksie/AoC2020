using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public class ResultSix
    {

        public ResultSix()
        {
            StreamReader reader = new StreamReader("./input6.txt");
            var text = reader.ReadToEnd().Replace("\r", "").Split("\n\n");
            var result1 = text.ToList().Select(l => l.Replace("\n", "").Distinct().Count());
            var chars = text.ToList().Select(l => l.Split("\n"));

            var result2 = 0;
            foreach (var item in chars)
            {
                var first = item.First().ToCharArray();
                foreach (var row in item.Skip(1))
                {
                    first = first.Intersect(row.ToCharArray()).ToArray();
                }
                result2 += first.Count();
            }

            Console.WriteLine(result1.Sum());
            Console.WriteLine(result2);
        }
    }
}

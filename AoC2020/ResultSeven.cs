using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public class ResultSeven
    {
        public Dictionary<string, Bag> Rules { get; set; } = new Dictionary<string, Bag>();
        public int Count { get; set; }
        public ResultSeven()
        {
            StreamReader stream = new StreamReader("./input7.txt");
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                ParseLine(line);
            }
            var res = 0;

            foreach (var (key, item) in Rules)
            {
                var t = GetNextBags(item.Bags);
                if (t > 0)
                {
                    res += 1;
                }
            }
            SetRules(Rules["shiny gold"]);
            var answer = Solve(Rules["shiny gold"]) -1;
            Console.WriteLine(answer);
            Console.WriteLine("------------------------------");
        }


        // Create the logical line it should take
        // So, a single shiny gold bag must contain 1 dark olive bag (and the 7 bags within it) plus 2 vibrant plum bags (and the 11 bags within each of those): 1 + 1*7 + 2 + 2*11 = 32 bags!


        // bag shine gold can contain 3 bags, 1 dark olive & 2 vibrant plum
        // 1 dark olive can contain 7 bags, 3 faded blue & 4 dotted black


        private int Solve(Bag bag)
        {
            Console.WriteLine($"{bag.Color} contains {bag.Contains} bags");
            if (bag.Bags == null)
            {
                return bag.Contains;
            }
            var sum = 0;
            foreach (var item in bag.Bags)
            {
                sum += Solve(item);
            }
            return sum*bag.Contains + bag.Contains;
        }

        private void SetRules(Bag bag)
        {
            if (Rules.ContainsKey(bag.Color))
            {
                bag.Bags = Rules[bag.Color].Bags;
                if (bag.Bags != null)
                { 
                    foreach (var item in Rules[bag.Color].Bags)
                    {
                        SetRules(item);
                    }
                }
            }
        }

        private int GetNextBags(List<Bag> bags)
        {
            var total = 0;
            if (bags == null)
                return 0;

            foreach (var bag in bags)
            {
                if (bag.Color == "shiny gold")
                {
                    return 1;
                }
                if (Rules.ContainsKey(bag.Color))
                {
                    total += GetNextBags(Rules[bag.Color].Bags);
                }
            }
            return total;   
        }

        private void ParseLine(string line)
        {
            var res = line.Split(" bags contain ");
            Bag bag = new Bag(res[0]);
            var x = res[1].Split(new char[] { ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (x[0] != "no other bags")
            {
                bag.Bags = new List<Bag>();
                foreach (var item in x)
                {
                    
                    var s = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var color = $"{s[1]} {s[2]}";
                    Bag b = new Bag(color, int.Parse(s[0]));
                    bag.Bags.Add(b);
                }
            }
            Rules[bag.Color] = bag;
        }

    }

    public class Bag
    {
        public Bag(string color)
        {
            Color = color;
        }

        public Bag(string color, int contains)
        {
            Color = color;
            Contains = contains;
        }
        public string Color { get; set; }
        public int Contains { get; set; } = 1;
        public List<Bag> Bags { get; set; }
        public int Total => Bags != null ? Bags.Sum(b => b.Contains) : 0;
    }
}

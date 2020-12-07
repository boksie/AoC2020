using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public class ResultOne
    {
        public void Result()
        {
            var numbers = Program.ReadData("./input.txt", (i) => int.Parse(i));
            ResultOnePartOne(numbers);
            ResultOnePartTwo(numbers);
        }

        private void ResultOnePartOne(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count - 1; j++)
                {
                    if (numbers[i] + numbers[j] == 2020)
                    {
                        Program.Print($"Result One Part One = { numbers[i]} * {numbers[j]} = {numbers[i] * numbers[j]}");
                        break;
                    }
                }
            }
        }

        private void ResultOnePartTwo(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count - 2; j++)
                {
                    for (int k = j + 1; k < numbers.Count - 1; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            Program.Print($"Result One Part Two = { numbers[i]} * {numbers[j]} * {numbers[k]} = {numbers[i] * numbers[j] * numbers[k]}");
                            break;
                        }
                    }

                }
            }
        }
    }
}

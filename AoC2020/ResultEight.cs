using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public class ResultEight
    {
        public ResultEight()
        {
            List<(string, int)> Operations = Program.ReadData("./input8.prod", Parse);
            var indexChanged = 0;
            
            while (true)
            {
                bool hasChanged = false;
                var operations = Operations.Select((o, i) =>
                {
                    if (hasChanged == false)
                    {
                        if (i > indexChanged)
                        {
                            if (o.Item1 == "nop")
                            {
                                hasChanged = true;
                                indexChanged = i;
                                o.Item1 = "jmp";
                            }
                            else if (o.Item1 == "jmp")
                            {
                                hasChanged = true;
                                indexChanged = i;
                                o.Item1 = "nop";
                            }
                        }
                        
                    }
                    return o;
                }
                );
                if (Loop(operations.ToList()))
                    break;
            }
        }

        private bool Loop(List<(string, int)> operations)
        {
            var index = 0;
            var indexUsed = new List<int>();
            var accumulator = 0;
            var operation = operations[index];
            while (true)
            {
                if (indexUsed.Contains(index))
                {
                    Console.WriteLine("WRONG");
                    return false;
                }


                indexUsed.Add(index);
                if (operation.Item1 == "acc")
                {
                    accumulator += operation.Item2;
                    index += 1;
                }
                else if (operation.Item1 == "jmp")
                {
                    index += operation.Item2;
                }
                else
                {
                    index += 1;
                }
                if (index >= operations.Count)
                {
                    Console.WriteLine("SUCCES");
                    break;
                }
                operation = operations[index];
            }

            Console.WriteLine(accumulator);
            return true;
        }

        private (string, int) Parse(string arg)
        {
            var line = arg.Split(" ");
            return (line[0], int.Parse(line[1]));
        }


    }
}

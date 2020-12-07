using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    public class ResultTwo
    {
        public void Result()
        {
            var models = Program.ReadData("./input2.txt", (i) => PasswordModel.Parse(i, SecondEvaluation));
            Print(models);
        }

        private void FirstEvaluation(PasswordModel model)
        {
            var count = model.PassWord.Count(c => c == model.Char);

            if (count >= model.AtLeast && count <= model.AtMost)
            {
                model.IsCorrect = true;
            }
        }

        private void SecondEvaluation(PasswordModel model)
        {
            var passwordArray = model.PassWord.ToCharArray();
            bool check1 = passwordArray.Length > model.AtLeast -1 ? passwordArray[model.AtLeast-1] == model.Char : false;
            bool check2 = passwordArray.Length > model.AtMost - 1 ? passwordArray[model.AtMost - 1] == model.Char : false;

            if ((check1 || check2) && !(check1 && check2))
            {
                model.IsCorrect = true;
            }
        }

        private void Print(List<PasswordModel> passwordModels)
        {
            Program.Print(passwordModels.Count(m => m.IsCorrect).ToString());
        }


        public class PasswordModel
        {
            public int AtLeast { get; set; }
            public int AtMost { get; set; }
            public char Char { get; set; }
            public string PassWord { get; set; }
            public bool IsCorrect { get; set; }
            public static PasswordModel Parse(string input, Action<PasswordModel> evaluate)
            {
                var split = input.Split(" ");
                var range = split[0].Split("-");
                var model = new PasswordModel()
                {
                    AtLeast = int.Parse(range[0]),
                    AtMost = int.Parse(range[1]),
                    Char = split[1].ToCharArray()[0],
                    PassWord = split[2]
                };

                evaluate(model);

                
                return model;
            }
        }
    }
}

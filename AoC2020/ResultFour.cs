using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2020
{
    public class ResultFour
    {
        public ResultFour()
        {
            var line = "";
            var passport = "";
            StreamReader file = new StreamReader("./input4.txt");
            var counter = 0;
            var dict = new Dictionary<string, Func<string, bool>>();
            var rgx = new Regex(@"^#[a-f0-9]{6}$");
            int temp;
            
            dict["byr"] = (year) => (int.Parse(year) >= 1920) && (int.Parse(year) <= 2002);
            dict["iyr"] = (year) => (int.Parse(year) >= 2010) && (int.Parse(year) <= 2020);
            dict["eyr"] = (year) => (int.Parse(year) >= 2020) && (int.Parse(year) <= 2030);
            dict["hgt"] = GetHeight;
            dict["hcl"] = rgx.IsMatch;
            dict["ecl"] = (str) => new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(str);
            dict["pid"] = (str) => str.Count() == 9 && int.TryParse(str, out temp) ;
            dict["cid"] = (str) => true;


            while ((line = file.ReadLine()) != null)
            {
                if (line == "")
                {
                    var pass = passport.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //if (pass.ContainsAll(new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" }))
                    //{
                    //    counter++;
                    //}
                    if (pass.ContainsAll(dict))
                    {
                        counter++;
                    }
                    passport = "";
                }
                passport += " " + line;
            }

            file.Close();
            
        }

        private bool GetHeight(string stringHeight)
        {
            if (stringHeight.Contains("in"))
            {
                var total = int.Parse(stringHeight.Replace("in", ""));
                return total >= 59 && total <= 76;
            }
            if (stringHeight.Contains("cm"))
            {
                var total = int.Parse(stringHeight.Replace("cm", ""));
                return total >= 150 && total <= 193;
            }
            return false;
        }

    }

    public static class Extensions
    {
        public static bool ContainsAll(this string[] values, string[] args)
        {
            foreach (var item in args)
            {
                if (values.Contains(item) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ContainsAll(this string[] values, Dictionary<string, Func<string, bool>> args)
        {
            foreach (var (key, item) in args)
            {
                for (int i = 0; i < values.Count(); i++)
                {
                    if (values[i] == key)
                    {
                        if (item(values[i+1]) == false)
                        {
                            return false;
                        }
                    }
                }
                if (key != "cid" && !values.Contains(key))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

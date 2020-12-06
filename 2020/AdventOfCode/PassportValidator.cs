using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class PasswordValidator
    {
        public static int GetNumberOfValids(IEnumerable<string> lines)
        {
            var passports =  GetPassports(lines);
            return passports.Count(x => x.IsValid());
        }

        private static IEnumerable<Passport> GetPassports(IEnumerable<string> lines)
        {
            var passports = new List<Passport>();
            var currentPassport = new Passport(); 

            foreach(var line in lines)
            {
                if(line == Environment.NewLine || line == "\r\n" || line == "")
                {
                    passports.Add(currentPassport);
                    currentPassport = new Passport();
                }
                else
                    line.Split(" ").ToList().ForEach(x => currentPassport.SetProperty(x));
            }

            passports.Add(currentPassport);

            return passports;
        }

        private static bool IsValid(this Passport self)
        {
            foreach(var p in self.GetType().GetProperties())
            {
                foreach(var att in p.GetCustomAttributes(true))
                {
                    var ra = (ValidationAttribute)att;

                    if(ra != null)
                        if(!ra.IsValid(p.GetValue(self, null)))
                            return false;
                }
            }

            return true;
        }
    }

    internal class Passport
    {
        internal void SetProperty(string property)
        {
            if(string.IsNullOrEmpty(property))
                return;

            var splitProperty = property.Split(":");

            if(splitProperty.Length != 2)
                throw new Exception($"Property {property} is bad");

            var propertyType = this.GetType().GetProperty(splitProperty[0]);
            int value = 0;

            if(int.TryParse(splitProperty[1], out value) && propertyType.PropertyType == typeof(int))
                propertyType.SetValue(this, value);
            else
                propertyType.SetValue(this, splitProperty[1]);
        }

        [Required]
        [RegularExpression(@"^(\d{4})$")]
        [Range(1920, 2002)]
        public int byr { get; set; }
        [Required]
        [RegularExpression(@"^(\d{4})$")]
        [Range(2010, 2020)]
        public int iyr { get; set; }
        [Required]
        [RegularExpression(@"^(\d{4})$")]
        [Range(2020, 2030)]
        public int eyr { get; set; }
        [Required]
        [HeightValidation]
        public string hgt { get; set; }
        [Required]
        [RegularExpression(@"^#[0-9a-f]{6}$")]
        public string hcl { get; set; }
        [Required]
        [EyeColorValidation]
        public string ecl { get; set; }
        [Required]
        [RegularExpression(@"^(\d{9})$")]
        public string pid { get; set; }
        public string cid { get; set; }
    }

    class HeightValidation: ValidationAttribute
    {
        private const string RegexCm  = @"(\d+)cm";
        private const string RegexIn  = @"(\d+)in";

        public override bool IsValid(object value)
        {
            var strvalue = (string)value;
            var regexCm = new Regex(RegexCm);
            var regexIn = new Regex(RegexIn);

            if(regexCm.IsMatch(strvalue))
            {
                var height = GetHeight(strvalue, regexCm);
                return 150 <= height && height <= 193;
            }
            else if(regexIn.IsMatch(strvalue))
            {
                var height = GetHeight(strvalue, regexIn);
                return 59 <= height && height <= 76;
            }

            return false;
        }

        private static int GetHeight(string strvalue, Regex regexCm)
        {
            var matches = regexCm.Match(strvalue);
            return int.Parse(matches.Groups[1].Value);
        }
    }

    class EyeColorValidation: ValidationAttribute
    {
        private IEnumerable<string> list = new List<string> {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

        public override bool IsValid(object value)
        {
            return list.Contains((string)value);
        }
    }
}
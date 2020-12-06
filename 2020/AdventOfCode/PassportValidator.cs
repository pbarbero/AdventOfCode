using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AdventOfCode
{
    public static class PasswordValidator
    {
        public static int GetNumberOfValids(IEnumerable<string> lines)
        {
            return GetPassports(lines).Count(x => x.IsValid());
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
                    var ra = att as RequiredAttribute;

                    if((RequiredAttribute)att != null)
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

            this.GetType().GetProperty(splitProperty[0]).SetValue(this, splitProperty[1]);
        }

        [Required]
        public string byr { get; set; }
        [Required]
        public string iyr { get; set; }
        [Required]
        public string eyr { get; set; }
        [Required]
        public string hgt { get; set; }
        [Required]
        public string hcl { get; set; }
        [Required]
        public string ecl { get; set; }
        [Required]
        public string pid { get; set; }
        public string cid { get; set; }
    }
}
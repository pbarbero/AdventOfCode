using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@Directory.GetCurrentDirectory() + "/data");
            int programs = 1;

            Dictionary<int, List<int>> data = new Dictionary<int, List<int>>();
            char[] delimiters = {' ', ',', '<', '-', '>'};
            foreach(var line in lines)
            {
                List<string> splittedLine = line.Split(delimiters).ToList();
                splittedLine.RemoveAll(x => string.IsNullOrEmpty(x) || string.IsNullOrWhiteSpace(x));
                int key = Int32.Parse(splittedLine[0]);
                splittedLine.RemoveAt(0);
                List<int> value = new List<int>();
                splittedLine.ForEach(x => value.Add(Int32.Parse(x)));
                data.Add(key, value);
            }

            //First part
            List<int> alreadyUsed = new List<int>(){0};
            foreach(int value in data[0])
            {
                programs++;
                alreadyUsed.Add(value);
                GetProgramsRelated(value, ref programs, ref alreadyUsed, data);
            }

            //Second part
            int groups = 1;
            foreach(int key in data.Keys)
            {
                if(!alreadyUsed.Contains(key))
                {
                    foreach(int value in data[key])
                    {
                        alreadyUsed.Add(value);
                        DiscardProgram(value, ref alreadyUsed, data);
                    }
                    groups++;
                }
            }
            
            Console.WriteLine(string.Format("Groups: {0}", groups.ToString()));
        }

        static void GetProgramsRelated(int key, ref int programs, ref List<int> alreadyUsed, Dictionary<int, List<int>> data)
        {
            foreach(int value in data[key])
            {
                if(!alreadyUsed.Contains(value))
                
                {
                    programs++;
                    alreadyUsed.Add(value);
                    GetProgramsRelated(value, ref programs, ref alreadyUsed, data);         
                }       
            }
        }

        static void DiscardProgram(int key, ref List<int> alreadyUsed, Dictionary<int, List<int>> data)
        {
            foreach(int value in data[key])
            {
                if(!alreadyUsed.Contains(value))
                
                {
                    alreadyUsed.Add(value);
                    DiscardProgram(value, ref alreadyUsed, data);         
                }       
            }

        }
    }
}

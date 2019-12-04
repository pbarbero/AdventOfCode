using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string[] lines = System.IO.File.ReadAllLines(@currentDirectory + "/data");            
            Phrase phrase;
            int counter = 0;
            foreach(var line in lines)
            {
                phrase = new Phrase(line);
                if(phrase.IsValid()) counter++;
            }
            Console.WriteLine(counter);
        }
    }

    class Phrase
    {
        public Phrase(){}
        public Phrase(string line)
        {
            this.Words = new List<string>();
            line.Split(" ").ToList().ForEach(x => this.Words.Add(String.Concat(x.OrderBy(c => c))));
        }
        public List<string> Words { get; set; }

        public bool IsValid()
        {
            for(int i = 0; i < this.Words.Count(); i++)
            {
                for(int j = i+1; j < this.Words.Count(); j++)
                {
                    if(this.Words[i] == this.Words[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}

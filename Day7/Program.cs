using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            var lines = System.IO.File.ReadAllLines(@currentDirectory + "/data").ToList();
            List<Tower> towers = new List<Tower>();


            //Parse data
            foreach(string line in lines)
            {                
                towers.Add(new Tower(line));
            }

            //Get all towers who had childs
            var towersWithChilds = towers.Where(x => x.Childs != null && x.Childs.Count() > 0).ToList();

            if(towersWithChilds.Any())
            {
                var towerToBegin = towersWithChilds.FirstOrDefault();

                Tower result = null;
                while(towerToBegin != null)
                {
                    result = towerToBegin;
                    towerToBegin = towersWithChilds.FirstOrDefault(x => x.Childs.Any(y => y.Name == result.Name));
                }

                Console.WriteLine(result.Name);

                //Part two
                var childs = towers.SingleOrDefault(x => x.Name == result.Name);
            }
            
        }
    }

    public class Tower
    {
        public Tower(string line)
        {                
            char[] delimiters = {' ', '(', ')', '-', '>', ','};

            var splittedLine = line.Split(delimiters).ToList();

            splittedLine.RemoveAll(x => string.IsNullOrWhiteSpace(x) || string.IsNullOrEmpty(x));

            if(splittedLine.Count() > 1)
            {
                this.Name = splittedLine[0];
                this.Weigth = Decimal.Parse(splittedLine[1]);

                if(splittedLine.Count() > 2)
                {
                    this.Childs = new List<Tower>();
                    for(int i = 2; i < splittedLine.Count(); i++)
                    {
                        this.Childs.Add(new Tower()
                        {
                            Name = splittedLine[i]
                        });
                    }
                }
            }

        }

        public Tower()
        {

        }

        public string Name {get;set;}
        public decimal Weigth {get;set;}
        public List<Tower> Childs{get;set;}
    }
}

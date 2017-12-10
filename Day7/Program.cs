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
            var lines = System.IO.File.ReadAllLines(@currentDirectory + "/data2").ToList();


            //Parse data
            List<Tower> towers = new List<Tower>();
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

               
                //Create tree 
                CreateTree(result, towers);

                //Get unbalanced node
                bool hasFinished = false;
                decimal weigth = GetUnbalancedNode(result, ref hasFinished);
                Console.WriteLine(weigth);

            }
            
        }

        static decimal GetUnbalancedNode(Tower parent, ref bool hasFinished)
        {
            decimal weigth = parent.Weigth;
            while(!hasFinished)
            {
                //Calculates weight for childs
                List<decimal> weights = new List<decimal>();
                foreach(var child in parent.Childs)
                {
                    weights.Add(child.CalculateWeight());
                }


                if(weights.Count() > 0)
                {
                    bool areDiff = weights.Any(o => o != weights[0]);
                    if(!areDiff)
                    {
                        hasFinished = true;
                        break;
                    }
                    else
                    {
                        var min = weights.GroupBy(i=>i).OrderByDescending(grp=>grp.Count())
                            .Select(grp=>grp.Key).OrderByDescending(x => x).First();

                        var index = weights.IndexOf(min);

                        var differentNode = parent.Childs[index];

                        if(differentNode != null)
                        {
                            GetUnbalancedNode(differentNode, ref hasFinished);          
                        }
                                      
                    }
                }
            }
            return weigth;
        }

        static void CreateTree(Tower parent, List<Tower> towers)
        {  
            var towerW = towers.FirstOrDefault(x => x.Name == parent.Name);
            if(towerW != null)
            {
                parent.Weigth = towerW.Weigth;
                
                if(towerW.Childs != null)
                {                    
                    List<string> childNames = towerW.Childs.Select(x => x.Name).ToList();
                    parent.Childs = new List<Tower>(towers.Where(x => childNames.Contains(x.Name)));

                    foreach(var child in parent.Childs)
                    {
                        CreateTree(child, towers);
                    }
                }
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

        public decimal CalculateWeight()
        {
            decimal result = this.Weigth;
            if(this.Childs != null)
            {
                foreach(var child in this.Childs)
                {
                    result += child.CalculateWeight();
                }
            }

            return result;
        }
    }
}

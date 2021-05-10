using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace lifeSpan
{
    class Program
    {
        public static void PopulationList(List<populationModel> populationList,int initialPopulation)
        {
            HashSet<int> yearTable = new HashSet<int>();
            var alive = (from s in populationList where s.deathYear <= 0 select s.bornYear).ToList();
            var res = (from s in populationList where s.deathYear > 0 orderby s.deathYear descending select s.deathYear).ToList();

            foreach (int item in res)
            {

                var initYear = item + 1;
                if (!alive.Contains(initYear))
                {
                    initialPopulation--;
                    yearTable.Add(initYear);
                }
            }

            Console.WriteLine(String.Format("Years: {0}", string.Join(",", yearTable)));
        }
        static void Main(string[] args)
        {

            List<populationModel> populationList = new List<populationModel>();

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "population.csv");
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var bornYear = String.IsNullOrEmpty(values[0]) ? 0 : Convert.ToInt32(values[0]);
                    var deathYear = String.IsNullOrEmpty(values[1]) ? 0 : Convert.ToInt32(values[1]);

                    populationList.Add(new populationModel() { bornYear = bornYear, deathYear = deathYear });

                }
            }
            PopulationList(populationList,1000);
        }
    }
}

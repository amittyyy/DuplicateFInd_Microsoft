using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateColumns
{
    class Program
    {
        /****Amity:- App made for .netframework 4.6.1, also  added code (async and await with ReadLineAsync) works for 4.7.1 and onward.****/
        static void Main(string[] args)
        //async static void Main(string[] args)
        {            
            int columnIndexToCheck = 1;  //Add argument column1 = 0 and column2 = 1;
            //args?[1] == "column1" ? 0 : 1;            
            var duplicateList = new List<string>();
            var nonDuplicateSet = new HashSet<string>();
            var listAllValue = new List<Tuple<string, string>>(); //Tuple for comparing duplicate vs orginal value in line 39

            using (var reader = new StreamReader(@"E:\DotNetApps\MicroSoft_Homework\DuplicateColumns\TestFile.csv"))
            {
                var headerLine =   reader.ReadLine(); // Ignore hader values
                // await reader.ReadlineAsync();

                var line =   reader.ReadLine();
                // await reader.ReadlineAsync();

                while (!string.IsNullOrEmpty(line))
                {
                    var splittedValues = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    var columnValue = splittedValues[columnIndexToCheck];

                    if (!nonDuplicateSet.Add(columnValue)) // if add returns false, then value is already in  set so mark it as duplicate
                    {
                        duplicateList.Add(columnValue);
                    }
                    listAllValue.Add(Tuple.Create(columnValue, line));
                    line =   reader.ReadLine();
                    // await reader.ReadlineAsync();
                }

            }

            if (duplicateList.Any())
            {
                var finalDuplicateList = new List<string>();
                foreach (var value in duplicateList.Distinct())
                {
                    finalDuplicateList.AddRange(listAllValue.Where(x => x.Item1 == value).Select(x => x.Item2).ToList());

                }
                finalDuplicateList.ForEach((x) => Console.WriteLine(x));

                Console.ReadLine();


            }
        }


    }
}

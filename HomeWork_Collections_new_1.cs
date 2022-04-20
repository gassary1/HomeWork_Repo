using System;
using System.Collections.Generic;

namespace ConsoleApp10
{
    //Есть два массива строк. Надо их объединить в одну коллекцию, исключив повторения, не используя Linq. Пример: {1, 2, 1} + {3, 2} => {1, 2, 3}
    class Program
    {
        static void Main(string[] args)
        {
            string[] fisrtArray = new string[] {"1", "2", "3"};
            string[] secondArray = new string[] { "3", "2", "1", "4"};

            HashSet<string> unionCollection = UnionToCollection(fisrtArray, secondArray);

            PrintCollection(unionCollection);
        }

        static HashSet<string> UnionToCollection(string[] fisrtArray, string[] secondArray)
        {
            List<string> unionList = new List<string>(fisrtArray);
            HashSet<string> result = new HashSet<string>();

            unionList.AddRange(secondArray);

            foreach (var symbol in unionList)
            {
                result.Add(symbol);
            }

            return result;
        }

        static void PrintCollection(HashSet<string> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}

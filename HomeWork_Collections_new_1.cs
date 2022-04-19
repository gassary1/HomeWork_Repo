using System;
using System.Collections.Generic;

namespace ConsoleApp10
{
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
            HashSet<string> result = new HashSet<string>();

            foreach (var number in fisrtArray)
            {
                result.Add(number);
            }

            foreach (var number in secondArray)
            {
                result.Add(number);
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

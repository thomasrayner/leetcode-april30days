using System;
using System.Collections.Generic;
using System.Linq;

namespace day06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string wordsInput = Console.ReadLine();
            var words = wordsInput.Split(',');

            var sol = new Solution();
            var final = sol.GroupAnagrams(words);

            foreach (var wordlist in final)
            {
                Console.Write(string.Join(", ", wordlist));
                Console.WriteLine();
            }
        }
    }

    public class Solution
    {
        //Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
        //Output:
        //[
        //  ["ate","eat","tea"],
        //  ["nat","tan"],
        //  ["bat"]
        //]
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var groupedList = new Dictionary<string, IList<string>>();

            foreach (string str in strs) {
                var word = str.Trim();
                var letterArr = word.ToCharArray();
                Array.Sort(letterArr);
                var letters = string.Join("", letterArr);

                if (!groupedList.TryGetValue(letters, out var entry))
                {
                    entry = groupedList[letters] = new List<string>();
                }

                entry.Add(word);
            }

            List<IList<string>> res = new List<IList<string>>(groupedList.Values.ToList());
            return res;
        }
    }
}

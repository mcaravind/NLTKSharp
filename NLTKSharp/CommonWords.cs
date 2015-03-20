using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace NLTKSharp
{
    public static class CommonWords
    {
        private static Dictionary<string, int> frequencyDictionary; 
        static CommonWords()
        {
            frequencyDictionary = new Dictionary<string, int>();
            string resource_data = Properties.Resources.wordfrequency;
            List<string> sentences = resource_data.Split(new[] {Environment.NewLine},
                StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string sentence in sentences)
            {
                string[] splitted = sentence.Split('\t');
                frequencyDictionary[splitted[0].ToLower()] = Convert.ToInt32(splitted[1]);
            }
        }
        public static int GetFrequency(string word)
        {
            int count = frequencyDictionary.ContainsKey(word.ToLower()) ? frequencyDictionary[word.ToLower()] : 0;
            return count;
        }
    }
}

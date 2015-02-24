using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLTKSharp
{
    public static class Stemmer
    {
        private enum CharState
        {
            Consonant,
            Vowel,
            None
        };

        public static string GetStem(string word)
        {
            string stem = string.Empty;
            return stem;
        }

        public static int GetWordMeasure(string word)
        {
            CharState charState = CharState.None;
            int measure = 0;
            char[] vowels = {'a', 'e', 'i', 'o', 'u','y'};
            char[] consonants =
            {
                'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v',
                'w', 'x', 'z'
            };
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                if (vowels.Contains(ch))
                {
                    charState = CharState.Vowel;
                }
                else if (consonants.Contains(ch))
                {
                    if ((measure == 0 && (charState == CharState.None || charState == CharState.Vowel))||(measure > 0 && charState == CharState.Vowel))
                    {
                        measure += 1;
                    }
                    
                    charState = CharState.Consonant;
                }
            }
            return measure;
        }
    }
}

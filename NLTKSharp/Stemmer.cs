using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLTKSharp
{
    public static class Stemmer
    {
        static char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
        static char[] consonants =
            {
                'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v',
                'w', 'x', 'z'
            };
        private enum CharState
        {
            Consonant,
            Vowel,
            None
        };

        public static string GetStem(string word)
        {
            string stem = string.Empty;
            word = word.ToLower();
            string step1aResult = ApplyStep1a(word);
            string step1bResult = ApplyStep1b(step1aResult);
            return stem;
        }

        static string ApplyStep1a(string input)
        {
            string result = input;
            result = result.ReplaceLastOccurrence("sses", string.Empty);
            result = result.ReplaceLastOccurrence("ies", string.Empty);
            result = result.ReplaceLastOccurrence("s", string.Empty);
            return result;
        }

        static string ApplyStep1b(string input)
        {
            string result = input;
            bool secondOrThirdStepSuccessful = false;
            bool trimmed;
            int m = input.Measure();
            if (m > 0)
            {
                result = result.ReplaceLastOccurrence("eed", "ee");   
            }
            if (result.HasVowel())
            {
                result = result.ReplaceLastOccurrence("ed", string.Empty, out trimmed);
                if (trimmed)
                {
                    secondOrThirdStepSuccessful = true;
                }
            }
            if (result.HasVowel())
            {
                result = result.ReplaceLastOccurrence("ing", string.Empty, out trimmed);
                if (trimmed)
                {
                    secondOrThirdStepSuccessful = true;
                }
            }
            if (secondOrThirdStepSuccessful)
            {
                result = result.ReplaceLastOccurrence("at", "ate");
                result = result.ReplaceLastOccurrence("bl", "ble");
                result = result.ReplaceLastOccurrence("iz", "ize");
                if (result.Length >= 2)
                {
                    char cL = result[result.Length - 1];
                    char cPen = result[result.Length - 2];
                    if (cL == cPen && consonants.Contains(cL))
                    {
                        if (cL != 'l' && cL != 's' && cL != 'z')
                        {
                            result = result.TrimEnd(cL);
                        }
                    }
                }
                if (result.Measure() == 1)
                {
                    char cL = result[result.Length - 1];
                    char cPen = result[result.Length - 2];
                    char cSL = result[result.Length - 3];
                    bool cvcFormat = (consonants.Contains(cSL) && vowels.Contains(cPen) && consonants.Contains(cL));
                    bool lastCharValid = cL != 'w' && cL != 'x' && cL != 'y';
                    if (cvcFormat && lastCharValid)
                    {
                        result = result + "e";
                    }
                }
            }
            return result;
        }

        static string ApplyStep1c(string input)
        {
            string result = input;
            if (input.HasVowel())
            {
                result = result.ReplaceLastOccurrence("y", "i");
            }
            return result;
        }

        public static int Measure(this string word)
        {
            CharState charState = CharState.None;
            int measure = 0;
            
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

        static bool HasVowel(this string input)
        {
            return input.All(c => vowels.Contains(c));
        }

        static string ReplaceLastOccurrence(this string Source, string Find, string Replace, out bool trimmed)
        {
            bool foundString = false;
            int Place = Source.LastIndexOf(Find);
            if (Place > -1)
            {
                foundString = true;
            }
            trimmed = foundString;
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }

        static string ReplaceLastOccurrence(this string Source, string Find, string Replace)
        {
            int Place = Source.LastIndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }
    }
}

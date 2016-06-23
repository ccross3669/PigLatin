using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {

            string line = string.Empty;

            while (!line.ToLower().Equals("exit".ToLower()))
            {

                Console.Write("Enter Line: ");
                line = Console.ReadLine();

                if (line.ToLower().Equals("exit".ToLower()))
                    continue;

                string[] words = line.Split(' ');
                string translatedLine = string.Empty;
                int wordCount = 0;
                foreach (string word in words)
                {
                    if (wordCount != 0)
                    {
                        translatedLine = translatedLine + " ";
                    }
                    if (!isWordValid(word))
                    {
                        translatedLine = translatedLine + word;
                        continue;
                    }


                    string outPunct;
                    string outWord;
                    StripPunctuation(word, out outPunct, out outWord);

                    isWordCapital(word);

                    string prefix, stem;

                    SplitWord(word, out prefix, out stem);


                    wordCount++;
                }

            }

        }




        private static void SplitWord(string word, out string prefix, out string stem)
        {
            



        }

        private static bool isWordCapital(string word)
        {
            if (Char.IsUpper(word[0]))
            {
                return true;
            }
            else
                return false;
        }

        private static bool isWordValid(string word)
        {
            int count = Regex.Matches(word, @"[a-zA-Z]").Count;

            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private static bool StripPunctuation(string word, out string outPunct, out string outWord)
        {

            // Assuming that they have used correct punctuation
            if (word[word.Length - 1].Equals(','))
            {
                outPunct = ",";
                outWord = word.Replace(",", string.Empty);
                return true;
            }
            else if (word[word.Length - 1].Equals('!'))
            {
                outPunct = "!";
                outWord = word.Replace("!", string.Empty);
                return true;
            }
            else if (word[word.Length - 1].Equals('?'))
            {
                outPunct = "?";
                outWord = word.Replace("?", string.Empty);
                return true;
            }
            else
            {
                outPunct = string.Empty;
                outWord = word;
                return false;
            }


        }
        private static bool IsCharVowel(char ch)
        {
            if (char.ToLower(ch) == 'a' || 
                char.ToLower(ch) == 'e' ||
                char.ToLower(ch) == 'i' ||
                char.ToLower(ch) == 'o' ||
                char.ToLower(ch) == 'u' ||
                char.ToLower(ch) == 'u')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}


using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PigLatin
{
    class Program
    {
        // Defined Vowels and Consanants - English
        private static readonly char[] vowels = "aeiouyAEIOUY".ToCharArray();
        // Defined Consonants and Consanants - English
        private static readonly char[] consanants = "bcdfghjklmnpqrstvxzwyBCDFGHJKLMNPQRSTVXZWY".ToCharArray();


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
                    if (!IsWordValid(word))
                    {
                        translatedLine = translatedLine + word;
                        wordCount++;
                        continue;
                    }


                    string outPunct;
                    string outWord;
                    StripPunctuation(word, out outPunct, out outWord);


                    string prefix, stem;
                    bool doesWordContainNoConsonants = DoesWordContainNoConsonants(outWord);
                    if (doesWordContainNoConsonants)
                    {
                        prefix = string.Empty;
                        stem = outWord;
                    }
                    else
                    {
                        SplitWord(outWord, out prefix, out stem, IsWordCapital(outWord));
                    }

                    translatedLine = translatedLine + TranslateWord(prefix, stem, outPunct, doesWordContainNoConsonants);

                    wordCount++;
                }
                Console.WriteLine(translatedLine);
            }
        }

        private static string TranslateWord(string prefix, string stem, string punct, bool doesWordContainNoConsonants)
        {
            if (doesWordContainNoConsonants)
                return stem + "yay" + punct;
            else
                return stem + prefix + "ay" + punct;
        }
        private static void SplitWord(string word, out string prefix, out string stem, bool isFirstLetterCapital)
        {

            int index = GetIndexOfFirstVowel(word);

            string outPrefix = word.Substring(0, index);
            string outStem = word.Substring(index);
            prefix = outPrefix;

            if (isFirstLetterCapital)
            {
                stem = outStem.First().ToString().ToUpper() + outStem.Substring(1);
                prefix = outPrefix.First().ToString().ToLower() + outPrefix.Substring(1);
            }
            else
            {
                stem = outStem;
                prefix = outPrefix;
            }
        }
        private static bool IsWordCapital(string word)
        {
            if (Char.IsUpper(word[0]))
            {
                return true;
            }
            else
                return false;
        }
        private static bool IsWordValid(string word)
        {
            word = word.TrimEnd('!', '?', ',');

            int count = Regex.Matches(word, @"[a-zA-Z]").Count;

            if ((count == 0) || (count != word.Length))
            {
                return false;
            }

            return true;
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
        private static bool DoesWordContainNoConsonants(string word)
        {

            foreach (char consonant in consanants)
            {
                if (word.Contains(consonant))
                    return false;
            }

            return true;
        }
        private static int GetIndexOfFirstVowel(string word)
        {

            foreach (char character in word)
            {
                if (vowels.Contains(character))
                {
                    return word.IndexOf(character);
                }
            }

            return -1;
        }
        private static bool DoesWordContainVowel(string word)
        {

            foreach (char vowel in vowels)
            {
                if (word.Contains(vowel))
                    return true;
            }

            return false;
        }

    }
}


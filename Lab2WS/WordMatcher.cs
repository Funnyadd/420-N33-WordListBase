using System;
using System.Collections.Generic;

namespace Lab2WS
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scrambledWord in scrambledWords)
            {
                foreach (string word in wordList)
                {
                    Console.WriteLine("dude");
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        //matchedWords.Add(BuildMatchedWord(scrambledWord, word));

                        matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });
                        Console.WriteLine("dude");
                    }
                    else
                    {
                        Console.WriteLine("dude");
                        //convert strings into character arrays i.e. ToCharArray()
                        char[] toCharScrambledWords;
                        toCharScrambledWords = scrambledWord.ToCharArray();

                        char[] toCharWords;
                        toCharWords = word.ToCharArray();

                        //sort both character arrays
                        Array.Sort(toCharScrambledWords);
                        Array.Sort(toCharWords);

                        //convert sorted character arrays into strings (toString)
                        string sortedScrambledWords;
                        sortedScrambledWords = toCharScrambledWords.ToString();
                        
                        string sortedWords;
                        sortedWords = toCharWords.ToString();

                        // 
                        //compare the two sorted strings. If they match, build the MatchWord
                        if (sortedScrambledWords.Equals(sortedWords))
                        {
                            //struct and add to matchedWords list.
                            matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });
                        }
                    }

                }
            }

            return matchedWords;
        }

        MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word
            };

            return matchedWord;
        }



    }
}

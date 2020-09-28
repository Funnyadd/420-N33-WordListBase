using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Lab2WS
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();
        public static readonly Constants constants = new Constants();

        static void Main(string[] args)
        {
            bool flag1 = true;
            do
            {

                bool flag = false;
                do
                {
                    
                    try
                    {
                        Console.WriteLine("Enter the scrambled words manually or as a file: f - file, m = manual");

                        string option = Console.ReadLine() ?? throw new Exception("String is null");

                        switch (option.ToUpper())
                        {
                            case "F":
                                Console.WriteLine("Enter the full path and filename >");
                                ExecuteScrambledWordsInFileScenario();
                                flag = true;
                                break;
                            case "M":
                                Console.WriteLine("Enter word(s) separated by a comma");
                                ExecuteScrambledWordsManualEntryScenario();
                                flag = true;
                                break;
                            default:
                                Console.WriteLine("The entered option was not recognized");
                                break;
                        }
                Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Sorry an error has occurred.. " + e.Message);
                    }

                } while (flag == false);

                Console.WriteLine("Would you like to scramble the words again? (Yes / No)");
                String answer = Console.ReadLine();

                switch(answer.ToUpper())
                {
                    case "Y":
                        flag1 = true;
                        break;
                    case "YES":
                        flag1 = true;
                        break;
                    case "N":
                        flag1 = false;
                        break;
                    case "NO":
                        flag1 = false;
                        break;
                }
            } while (flag1 == true);
            
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string fileName = Console.ReadLine();
            string[] scrambledWords = fileReader.Read(fileName);
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            // 1 get the user's input - comma separated string containing scrambled words
            //Console.WriteLine("dude");
            string input = Console.ReadLine();

            // 2 Extract the words into a string (red,blue,green)
            //char[] delimeterChars = { ' ', ',' };
            //Console.WriteLine(input);
            string[] inputArray = input.Split(',', ' ');
            //Console.WriteLine(inputArray);

            // 3 Call the DisplayMatchedUnscrambledWords method passing the scrambled words string array
            DisplayMatchedScrambledWords(inputArray);
        }

        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(Constants.WORDLIST); // Put in a constants file. CAPITAL LETTERS.  READONLY.
           
            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

            // Rule:  Use a formatter to display ... eg:  {0}{1}
            // Rule:  USe an IF to determine if matchedWords is empty or not......

            //            if empty - display no words found message.
            if (matchedWords == null)
            {
                Console.WriteLine("No words found");
            }

            //            if NOT empty - Display the matches.... use "foreach" with the list (matchedWords)
            else
            {
                foreach (MatchedWord mw in matchedWords)
                {
                    Console.WriteLine("Match found for the word {0} which is equal to {1}", mw.ScrambledWord, mw.Word);
                }
            }
        }
    }
}

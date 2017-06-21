using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace hangman
{
    class GameLogic
    {
        public int MaxTries { get; set; }
        public string RandomWord { get; set; }
        public int WrongCount { get; set; }
        public string WordFile { get; set; }
        public List<char> UserLetters { get; set; }

        public GameLogic(string userFile)
        {
            MaxTries = 6;
            RandomWord = string.Empty;
            WrongCount = 0;
            WordFile = userFile;
            UserLetters = new List<char> { };
        }

        public void ChooseWord()
        {
            Random rnd = new Random();
            var lines = File.ReadLines(WordFile);
            string rndWord = lines.ElementAt(rnd.Next(lines.Count() - 1)).Replace("'", "").ToLower();

            RandomWord = rndWord;
        }

        public string DisplayWord()
        {
            string resultWord = "";
            List<char> lowCharList = LowerCharList(UserLetters);
            
            foreach (char letter in RandomWord)
            {
                if (lowCharList.Contains(letter))
                {
                    char lowerLetter = char.ToLower(letter);
                    resultWord += lowerLetter + " ";
                }
                else
                {
                    resultWord += "_ ";
                }
            }

            return resultWord.TrimEnd();
        }

        public List<char> LowerCharList(List<char> CharList)
        {
            List<char> resultList = new List<char> { };

            foreach (char letter in CharList)
            {
                resultList.Add(char.ToLower(letter));
            }

            return resultList;
        }

        public List<char> CreateLetterList(string goalWord)
        {
            List<char> letterList = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                                                        'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            List<char> wrongLetters = new List<char>();
            foreach (char letter in letterList)
            {
                if (!goalWord.Contains(letter))
                {
                    wrongLetters.Add(letter);
                }
            }

            return wrongLetters;
        }

        public void WrongCounter()
        {
            List<char> wrongLetters = CreateLetterList(RandomWord);
            int wrongCount = 0;
            foreach (char letter in UserLetters)
            {
                if (wrongLetters.Contains(letter))
                {
                    wrongCount++;
                }
            }

            WrongCount = wrongCount;
        }

        public bool CheckToContinue()
        {

            IEnumerable<char> distinctLetters = RandomWord.Distinct();
            int distinctLength = distinctLetters.ToArray().Length;
            int rightCount = 0;
            foreach (char letter in distinctLetters)
            {
                if (UserLetters.Contains(letter))
                {
                    rightCount++;
                    if (rightCount == distinctLength)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void DisplayLetters()
        {
            foreach (char letter in UserLetters)
            {
                Console.Write(letter);
            }
        }

        public void UserInput()
        {
            char userInput = Console.ReadKey().KeyChar;

            while (!char.IsLetter(userInput))
            {
                userInput = Console.ReadKey().KeyChar;
            }

            UserLetters.Add(userInput);
        }
    }
}

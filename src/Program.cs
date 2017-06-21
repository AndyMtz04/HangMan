using System;


namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordFile = "E:\\programming\\c#\\projects\\hangman\\hangman\\wordslist.txt"; // To start, enter word file full path.
            Man man = new Man();
            GameLogic gl = new GameLogic(wordFile);
            PlayGame(man, gl);
            Console.ReadLine();
        }

        static void PlayGame(Man man, GameLogic gl)
        {
            gl.ChooseWord();
            while (gl.WrongCount < gl.MaxTries)
            {
                Console.WriteLine(man.Draw(gl.WrongCount));
                Console.WriteLine(gl.DisplayWord());
                Console.Write("Letters: "); // use string.format to make this one line
                gl.DisplayLetters(); //
                Console.WriteLine(); //
                char userLetter = Console.ReadLine()[0]; // create a method to check user input and add to atribute
                gl.UserLetters.Add(userLetter);

                if (gl.CheckToContinue())
                {
                    Console.WriteLine("You have won!!");
                    break;
                }

                gl.WrongCounter();
            }
            Console.WriteLine(man.Draw(gl.WrongCount));
            Console.WriteLine("You have lost! Word is " + gl.RandomWord);
        }
    }
}

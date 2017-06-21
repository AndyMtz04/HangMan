using System;


namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordFile = ""; // To start, enter word file full path
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
                Console.Write("Letters: ");
                gl.DisplayLetters();
                Console.WriteLine();
                Console.Write("Enter a letter: ");
                gl.UserInput();
                Console.WriteLine();

                if (gl.CheckToContinue())
                {
                    Console.WriteLine("You won!!");
                    break;
                }

                gl.WrongCounter();
            }

            if (!gl.CheckToContinue())
            {
                Console.WriteLine(man.Draw(gl.WrongCount));
                Console.WriteLine("You lost! Word is " + gl.RandomWord);
            }
        }
    }
}

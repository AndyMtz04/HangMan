using System;


namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordFile = ""; // To start, enter word file full path.
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
                gl.DisplayWord();
                Console.WriteLine(man.Draw(gl.WrongCount));
                Console.WriteLine(gl.WordDisplay);
                char userLetter = Console.ReadLine()[0];
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

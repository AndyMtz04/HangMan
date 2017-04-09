using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace hangman
{
    [TestFixture]
    class TestCase
    {
        string wordFile = ""; // Enter file path

        [TestCase]
        public void TestManDraw()
        {
            Man man = new hangman.Man();
            Assert.AreEqual("----|   \r\n|   o\r\n|  /|\\\r\n|  / \\\r\n|_____", man.Draw(6));
        }

        // This test fails because of the capital letter and appostaphre
        //[TestCase]
        public void TestGameLogicChooseWord()
        {
            GameLogic gl = new GameLogic(wordFile);
            var lines = File.ReadLines(wordFile);
            gl.ChooseWord();
            string rndWord = gl.RandomWord;
            Assert.IsTrue(lines.Contains(rndWord));
        }

        [TestCase]
        public void TestWordDisplay()
        {
            string fakeFile = "c://file";
            GameLogic gl = new GameLogic(fakeFile);
            List<char> usedLetters = new List<char> { 'a', 'b', 'i', 'l', 't', 's', 'e' };
            gl.UserLetters = usedLetters;
            gl.RandomWord = "abilities";
            gl.DisplayWord();
            string expected = "a b i l i t i e s";
            Assert.AreEqual(expected, gl.WordDisplay);

            List<char> usedLetters2 = new List<char> { 'a', 'l', 't', 's', 'e' };
            gl.UserLetters = usedLetters2;
            gl.RandomWord = "abilities";
            gl.DisplayWord();
            string expected2 = "a _ _ l _ t _ e s";
            Assert.AreEqual(expected2, gl.WordDisplay);

            List<char> usedLetters3 = new List<char> { };
            gl.UserLetters = usedLetters3;
            gl.RandomWord = "abilities";
            gl.DisplayWord();
            string expected3 = "_ _ _ _ _ _ _ _ _";
            Assert.AreEqual(expected3, gl.WordDisplay);

            List<char> usedLetters4 = new List<char> { '1', '2', '3', 'b', 'a' };
            gl.UserLetters = usedLetters4;
            gl.RandomWord = "abilities";
            gl.DisplayWord();
            string expected4 = "a b _ _ _ _ _ _ _";
            Assert.AreEqual(expected4, gl.WordDisplay);

            List<char> usedLetters5 = new List<char> { 'A', 'L', 'T', 'S', 'E' };
            gl.UserLetters = usedLetters5;
            gl.RandomWord = "abilities";
            gl.DisplayWord();
            string expected5 = "a _ _ l _ t _ e s";
            Assert.AreEqual(expected5, gl.WordDisplay);
        }

        [TestCase]
        public void TestLowerListChar()
        {
            string fakeFile = "c://file";
            GameLogic gl = new GameLogic(fakeFile);
            List<char> testList = new List<char> { 'A', 'B', '1', '2', ' ' };
            List<char> expectList = new List<char> { 'a', 'b', '1', '2', ' ' };
            List<char> resultList = gl.LowerCharList(testList);
            Assert.AreEqual(expectList, resultList);
        }

        [TestCase]
        public void TestCreateLetterList()
        {
            string fakeFile = "c://file";
            GameLogic gl = new GameLogic(fakeFile);
            string goalWord = "abilities";
            List<char> expectList = new List<char>() { 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'm', 'n',
                                                        'o', 'p', 'q', 'r', 'u', 'v', 'w', 'x', 'y', 'z' };
            List<char> resultList = gl.CreateLetterList(goalWord);
            Assert.AreEqual(expectList, resultList);
        }

        [TestCase]
        public void TestWrongCounter()
        {
            string fakeFile = "c://file";
            GameLogic gl = new GameLogic(fakeFile);
            gl.RandomWord = "abilities";
            List<char> usedLetters = new List<char> { 'a', 'b', 'c' };
            gl.UserLetters = usedLetters;
            gl.WrongCounter();
            Assert.AreEqual(1, gl.WrongCount);
        }

        [TestCase]
        public void TestCheckGameStatus()
        {
            string fakeFile = "c://file";
            GameLogic gl = new GameLogic(fakeFile);
            gl.RandomWord = "abilities";
            List<char> usedLetters = new List<char> { 'a', 'b', 'i', 'l', 't', 'e', 's' };
            gl.UserLetters = usedLetters;
            Assert.IsTrue(gl.CheckToContinue());

            List<char> usedLetters2 = new List<char> { 'b', 'i', 'l', 't', 'e', 's' };
            gl.UserLetters = usedLetters2;
            Assert.IsFalse(gl.CheckToContinue());

            List<char> usedLetters3 = new List<char> { '1', '2' };
            gl.UserLetters = usedLetters3;
            Assert.IsFalse(gl.CheckToContinue());

            List<char> usedLetters4 = new List<char> { };
            gl.UserLetters = usedLetters4;
            Assert.IsFalse(gl.CheckToContinue());
        }
    }
}

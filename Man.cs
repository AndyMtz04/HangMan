using System;
using System.Linq;
using System.Text;


namespace hangman
{
    class Man
    {
        private string _manParts;

        public Man()
        {
            _manParts = "----|   {0}|   o{0}|  /|\\{0}|  / \\{0}|_____";
        }

        public string Draw(int wrong)
        {
            int[] numArray = { 15, 22, 23, 24, 31, 33 };
            StringBuilder sb = new StringBuilder();

            for (int x = 0; x < _manParts.Length; x++)
            {
                if (!numArray.Skip(wrong).Contains(x))
                {
                    sb.Append(_manParts[x]);
                }
            }

            return string.Format(sb.ToString(), Environment.NewLine);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo.Kata.BankOcr
{
    public class AccountNumberRecognizer
    {
        private const string empty = "   ";
        private const string lShape = " _|";

        private IList<string> lines = new List<string>();

        public void Feed(string line)
        {
            this.lines.Add(line);
        }

        public int RecognizeNumber()
        {
            if (this.lines[0] == empty)
            {
                return 1;
            }
            else
            {
                if (this.lines.Count() == 2
                    && this.lines[1] == lShape)
                {
                    return 2;
                }

                return 0;
            }
        }
    }
}

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
        private const string rigthPipe = "  |";

        public int RecognizeNumber(string firstLine, string secondLine = null)
        {
            if (firstLine == empty)
            {
                return 1;
            }
            else
            {
                if (secondLine == rigthPipe)
                {
                    return 2;
                }

                return 0;
            }
        }
    }
}

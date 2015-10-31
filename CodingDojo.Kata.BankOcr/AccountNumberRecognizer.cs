using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo.Kata.BankOcr
{
    public class AccountNumberRecognizer
    {
        public int RecognizeNumber(string v)
        {
            if (v == "   ")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

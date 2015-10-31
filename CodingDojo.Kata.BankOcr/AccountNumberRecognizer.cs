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
        private const string underscore = " _ ";
        private const string lShape = " _|";
        private const string invertedLShape = "|_ ";
        private const string pipes = "| |";

        private List<string> lines = new List<string>();
        private readonly IReadOnlyDictionary<int, Func<IReadOnlyList<string>, bool>> numberRecognizers;

        public AccountNumberRecognizer()
        {
            var numberRecognizers = new Dictionary<int, Func<IReadOnlyList<string>, bool>>();
            numberRecognizers[0] = IsZero;
            numberRecognizers[1] = IsOne;
            numberRecognizers[2] = IsTwo;
            numberRecognizers[3] = IsThree;
            this.numberRecognizers = numberRecognizers;
        }

        public void Feed(string line)
        {
            this.lines.Add(line);
        }

        public int RecognizeNumber()
        {
            if (lines.Count() < 3)
            {
                throw new InvalidOperationException();
            }

            return this.numberRecognizers.First(n => n
                .Value(this.lines)).Key;
        }

        private static bool IsZero(IReadOnlyList<string> lines) =>
            lines[0] == underscore
            && lines[1] == pipes;

        private static bool IsOne(IReadOnlyList<string> lines) =>
            lines[0] == empty;

        private static bool IsTwo(IReadOnlyList<string> lines) =>
            lines[1] == lShape
            && lines[2] == invertedLShape;

        private static bool IsThree(IReadOnlyList<string> lines) =>
            lines[1] == lShape
            && lines[2] == lShape;
    }
}

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
        private const string rigthPipe = "  |";
        private const string uShape = "|_|";
        private List<string> lines = new List<string>();
        private readonly IReadOnlyDictionary<int, Func<IReadOnlyList<string>, bool>> numberRecognizers;

        public AccountNumberRecognizer()
        {
            var numberRecognizers = new Dictionary<int, Func<IReadOnlyList<string>, bool>>();
            numberRecognizers[0] = IsZero;
            numberRecognizers[1] = IsOne;
            numberRecognizers[2] = IsTwo;
            numberRecognizers[3] = IsThree;
            numberRecognizers[4] = IsFour;
            this.numberRecognizers = numberRecognizers;
        }

        public void Feed(string line)
        {
            this.lines.Add(line);
        }

        public int GetRecognizedNumber()
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
            lines[0] == empty
            && lines[1] == rigthPipe;

        private static bool IsTwo(IReadOnlyList<string> lines) =>
            lines[1] == lShape
            && lines[2] == invertedLShape;

        private static bool IsThree(IReadOnlyList<string> lines) =>
            lines[1] == lShape
            && lines[2] == lShape;

        private static bool IsFour(IReadOnlyList<string> lines) =>
            lines[1] == uShape
            && lines[2] == rigthPipe;
    }
}

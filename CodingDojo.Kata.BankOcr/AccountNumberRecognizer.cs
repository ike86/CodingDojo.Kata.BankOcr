using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingDojo.Kata.BankOcr
{
    public class AccountNumberRecognizer
    {
        private const string empty = "   ";
        private const string underscore = " _ ";
        private const string invertedLShape = " _|";
        private const string lShape = "|_ ";
        private const string pipes = "| |";
        private const string rigthPipe = "  |";
        private const string uShape = "|_|";
        private List<string> lines = new List<string>();
        private readonly IReadOnlyDictionary<int, Func<bool>> numberRecognizers;

        public AccountNumberRecognizer()
        {
            var numberRecognizers = new Dictionary<int, Func<bool>>();
            numberRecognizers[0] = IsZero;
            numberRecognizers[1] = IsOne;
            numberRecognizers[2] = IsTwo;
            numberRecognizers[3] = IsThree;
            numberRecognizers[4] = IsFour;
            numberRecognizers[5] = IsFive;
            numberRecognizers[6] = IsSix;
            numberRecognizers[7] = IsSeven;
            numberRecognizers[8] = IsEigth;
            numberRecognizers[9] = IsNine;
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
                .Value()).Key;
        }

        private bool IsZero() =>
            IsFirstLine(underscore)
            && IsSecondLine(pipes);

        private bool IsOne() =>
            IsFirstLine(empty)
            && IsSecondLine(rigthPipe);

        private bool IsTwo() =>
            IsSecondLine(invertedLShape)
            && IsThirdLine(lShape);

        private bool IsThree() =>
            IsSecondLine(invertedLShape)
            && IsThirdLine(invertedLShape);

        private bool IsFour() =>
            IsSecondLine(uShape)
            && IsThirdLine(rigthPipe);

        private bool IsFive() =>
            IsFirstLine(underscore)
            && IsSecondLine(lShape)
            && IsThirdLine(invertedLShape);

        private bool IsSix() =>
            IsFirstLine(underscore)
            && IsSecondLine(lShape)
            && IsThirdLine(uShape);

        private bool IsSeven() =>
            IsFirstLine(underscore)
            && IsThirdLine(rigthPipe);

        private bool IsEigth() =>
            IsFirstLine(underscore)
            && IsSecondLine(uShape)
            && IsThirdLine(uShape);

        private bool IsNine() =>
            IsFirstLine(underscore)
            && IsSecondLine(uShape)
            && IsThirdLine(invertedLShape);

        private bool IsFirstLine(string pattern) =>
            this.lines[0] == pattern;

        private bool IsSecondLine(string pattern) =>
            this.lines[1] == pattern;

        private bool IsThirdLine(string pattern) =>
            this.lines[2] == pattern;
    }
}
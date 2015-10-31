using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingDojo.Kata.BankOcr.Tests
{
    [TestClass]
    public class Test_AccountNumberRecognizer
    {

        [TestClass]
        public class RecognizeNumber
        {
            private const string numbers = @"
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|";

            private readonly AccountNumberRecognizer subject = new AccountNumberRecognizer();

            [TestMethod]
            public void Should_recognize_one()
            {
                subject.Feed("   ");

                var number = subject.RecognizeNumber();

                number.Should().Be(1);
            }

            [TestMethod]
            public void Should_recognize_zero()
            {
                subject.Feed(" _ ");

                var number = subject.RecognizeNumber();

                number.Should().Be(0);
            }

            [TestMethod]
            public void Should_recognize_two()
            {
                subject.Feed(" _ ");
                subject.Feed("  |");

                var number = subject.RecognizeNumber();

                number.Should().Be(2);
            }
        }
    }
}

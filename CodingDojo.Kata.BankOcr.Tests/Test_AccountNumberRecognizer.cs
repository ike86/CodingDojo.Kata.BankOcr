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

            [TestMethod]
            public void Should_recognize_one()
            {
                var subject = new AccountNumberRecognizer();

                var number = subject.RecognizeNumber("   ");

                number.Should().Be(1);
            }
        }
    }
}

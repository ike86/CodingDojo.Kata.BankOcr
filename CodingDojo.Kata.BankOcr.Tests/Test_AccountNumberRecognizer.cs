using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace CodingDojo.Kata.BankOcr.Tests
{
    [TestClass]
    public class Test_AccountNumberRecognizer
    {

        [TestClass]
        public class GetRecognizedNumber
        {
            private const string numbers = @"
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|";

            private readonly IFixture fixture = new Fixture();
            private readonly AccountNumberRecognizer subject = new AccountNumberRecognizer();

            [TestMethod]
            public void Should_recognize_one()
            {
                subject.Feed("   ");
                subject.Feed("  |");
                subject.Feed("  |");

                var number = subject.GetRecognizedNumber();

                number.Should().Be(1);
            }

            [TestMethod]
            public void Should_recognize_zero()
            {
                subject.Feed(" _ ");
                subject.Feed("| |");
                subject.Feed("|_|");

                var number = subject.GetRecognizedNumber();

                number.Should().Be(0);
            }

            [TestMethod]
            public void Should_recognize_two()
            {
                subject.Feed(" _ ");
                subject.Feed(" _|");
                subject.Feed("|_ ");

                var number = subject.GetRecognizedNumber();

                number.Should().Be(2);
            }

            [TestMethod]
            public void Should_recognize_three()
            {
                subject.Feed(" _ ");
                subject.Feed(" _|");
                subject.Feed(" _|");

                var number = subject.GetRecognizedNumber();

                number.Should().Be(3);
            }

            [TestMethod]
            public void Should_recognize_four()
            {
                subject.Feed("   ");
                subject.Feed("|_|");
                subject.Feed("  |");

                var number = subject.GetRecognizedNumber();

                number.Should().Be(4);
            }

            [TestMethod]
            public void Should_recognize_five()
            {
                subject.Feed(" _ ");
                subject.Feed("|_ ");
                subject.Feed(" _|");

                var number = subject.GetRecognizedNumber();

                number.Should().Be(5);
            }

            [TestMethod]
            public void Should_recognize_six()
            {
                subject.Feed(" _ ");
                subject.Feed("|_ ");
                subject.Feed("|_|");

                var number = subject.GetRecognizedNumber();

                number.Should().Be(6);
            }

            [TestMethod]
            public void Should_recognize_seven()
            {
                subject.Feed(" _ ");
                subject.Feed("  |");
                subject.Feed("  |");

                var number = subject.GetRecognizedNumber();

                number.Should().Be(7);
            }

            [TestMethod]
            public void Should_throw_error_if_number_of_feeds_were_less_than_3()
            {
                subject.Feed(fixture.Create<string>());
                subject.Feed(fixture.Create<string>());

                Action act = () =>
                    subject.GetRecognizedNumber();

                act.ShouldThrow<InvalidOperationException>();
            }
        }
    }
}

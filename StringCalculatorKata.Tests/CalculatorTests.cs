using System;
using NUnit.Framework;
using StringCalculatorKata.Core;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private ParsingCalculator calc;

        [SetUp]
        public void SetUp()
        {
            calc = new ParsingCalculator();
        }

        [Test]
        public void GivenJustNumber_ReturnsThatNumber()
        {
            Assert.That(calc.Compute("7"), Is.EqualTo(7.0));
        }

        [TestCase("7+3", 10)]
        [TestCase("7+3+1", 11)]
        public void TestAddition(String expression, Double expected)
        {
            Assert.That(calc.Compute(expression), Is.EqualTo(expected));
        }

        [TestCase("7-3", 4)]
        [TestCase("7-3-2", 2)]
        public void TestSubtraction(String expression, Double expected)
        {
            Assert.That(calc.Compute(expression), Is.EqualTo(expected));
        }

        [TestCase("9+3-2-2", 8)]
        [TestCase("9+2*8-1", 24)]
        public void TestMultipleOperators(String expression, Double expected)
        {
            Assert.That(calc.Compute(expression), Is.EqualTo(expected));
        }

        [TestCase("9*2", 18)]
        [TestCase("9*2*10", 180)]
        public void TestMultiplication(String expression, Double expected)
        {
            Assert.That(calc.Compute(expression), Is.EqualTo(expected));
        }

        [TestCase("8/2", 4)]
        [TestCase("8/2/2", 2)]
        public void TestDivision(String expression, Double expected)
        {
            Assert.That(calc.Compute(expression), Is.EqualTo(expected));
        }

        [Test]
        public void GivenSomeNumbersWithNegatives_OperationsMustBeMet()
        {
            Assert.That(calc.Compute("8+-2--3/3"), Is.EqualTo(7));
        }

        [TestCase("2%2", 0)]
        [TestCase("5%4", 1)]
        public void TestModulus(String expression, Double expected)
        {
            Assert.That(calc.Compute(expression), Is.EqualTo(expected));
        }

        [TestCase("2^2", 4)]
        [TestCase("2^2^2", 16)]
        [TestCase("2^8", 256)]
        public void TestExponent(String expression, Double expected)
        {
            Assert.That(calc.Compute(expression), Is.EqualTo(expected));
        }

        [Test]
        public void TestOneDice()
        {
            var result = calc.Compute("1d10");
            Assert.That(result >= 1, Is.True);
            Assert.That(result <= 10, Is.True);
        }

        [Test]
        public void TestTwoDice()
        {
            var result = calc.Compute("2d10");
            Assert.That(result >= 1, Is.True);
            Assert.That(result <= 20, Is.True);
        }
    }
}

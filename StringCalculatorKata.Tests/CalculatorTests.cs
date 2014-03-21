﻿using NUnit.Framework;
using StringCalculatorKata.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        Calculator calc;

        [SetUp]
        public void SetUp()
        {
            calc = new Calculator();
        }

        [Test]
        public void GivenJustNumber_ReturnsThatNumber()
        {
            Assert.That(calc.Compute("7"), Is.EqualTo(7.0));
        }

        [Test]
        public void GivenSimpleAddition_ShouldAddThoseNumbers()
        {
            Assert.That(calc.Compute("7+3"), Is.EqualTo(10.0));
        }

        [Test]
        public void GivenThreeNumbersToAdd_ShouldAddThoseNumbers()
        {
            Assert.That(calc.Compute("7+3+1"), Is.EqualTo(11));
        }

        [Test]
        public void GivenSimpleSubtraction_ShouldSubtractThoseNumbers()
        {
            Assert.That(calc.Compute("7-3"), Is.EqualTo(4));
        }

        [Test]
        public void GivenThreeNumbersToSubtract_ShouldSubtractThoseNumbers()
        {
            Assert.That(calc.Compute("7-3-2"), Is.EqualTo(2));
        }

        [Test]
        public void GivenThreeNumbersWithTwoOperators_ShouldProperlyAddAndSubtract()
        {
            Assert.That(calc.Compute("9+3-2-2"), Is.EqualTo(8));
        }

        [Test]
        public void GivenSimpleMultiplication_ShouldBeFruitfulAndMultiply()
        {
            Assert.That(calc.Compute("9*2"), Is.EqualTo(18));
        }

        [Test]
        public void GivenThreeNumbersToMultiply_ShouldBeFruitfulAndMultiply()
        {
            Assert.That(calc.Compute("9*2*10"), Is.EqualTo(180));
        }

        [Test]
        public void GivenFourNumbersWithAddSubtractAndMultiply_ShouldOperateInOrder()
        {
            Assert.That(calc.Compute("9+2*8-1"), Is.EqualTo(24));
        }
    }
}
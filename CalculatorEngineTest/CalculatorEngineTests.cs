using CalculatorTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEngineTest
{
    [TestFixture]
    public class CalculatorEngineTests
    {
        private CalculatorEngine _calculatorEngine;

        [SetUp]
        public void Setup()
        {
            _calculatorEngine = new CalculatorEngine();
        }

        [Test]
        public void Calculate_EmptyString_ReturnsZero()
        {
            var input = "";
            var result = _calculatorEngine.Calculate(input);
            Assert.AreEqual("0", result);
        }

        [Test]
        public void Calculate_SingleNumber_ReturnsTheSameNumber()
        {
            var input = "20";
            var result = _calculatorEngine.Calculate(input);
            Assert.AreEqual("20", result);
        }

       

        [Test]
        public void Calculate_MoreThanTwoNumbers_ThrowsException()
        {
            var input = "1,2,3";
            var ex = Assert.Throws<InvalidOperationException>(() => _calculatorEngine.Calculate(input));
            Assert.That(ex.Message, Is.EqualTo("A maximum of 2 numbers is allowed."));
        }

        [Test]
        public void Calculate_RemoveNumberLimit_AllowsMoreThanTwoNumbers()
        {
            _calculatorEngine.RemoveNumberLimit();
            var input = "1,2,3,4,5";
            var result = _calculatorEngine.Calculate(input);
            Assert.AreEqual("15", result);
        }

        [Test]
        public void Calculate_CustomDelimiterSingleCharacter_ReturnsSum()
        {
            var input = "//#\n2#5";
            var result = _calculatorEngine.Calculate(input);
            Assert.AreEqual("7", result);
        }

       

        [Test]
        public void Calculate_InvalidNumbers_AreIgnored()
        {
            var input = "5,tytyt";
            var result = _calculatorEngine.Calculate(input);
            Assert.AreEqual("5", result);
        }

        [Test]
        public void Calculate_NegativeNumbers_ThrowsException()
        {
            var input = "1,-2,3";
            var ex = Assert.Throws<InvalidOperationException>(() => _calculatorEngine.Calculate(input));
            Assert.That(ex.Message, Is.EqualTo("Negative numbers not allowed: -2"));
        }

        [Test]
        public void Calculate_MultipleNegativeNumbers_ThrowsExceptionWithAllNegatives()
        {
            var input = "1,-2,-3,4";
            var ex = Assert.Throws<InvalidOperationException>(() => _calculatorEngine.Calculate(input));
            Assert.That(ex.Message, Is.EqualTo("Negative numbers not allowed: -2, -3"));
        }

      

    }
}

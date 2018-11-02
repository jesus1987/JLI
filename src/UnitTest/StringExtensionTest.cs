
using JLI.Extension;
using NUnit.Framework;
using System;

namespace UnitTest
{
    [TestFixture]
    public class StringExtensionTest
    {
        private const int INT_INTEGER = 112;

        private const double DOUBLE = 123.12;

        private const float FLOAT = -123.4561F;

        [Test]
        public void Given_Type_Of_Int_And_Valid_String_Should_Convert_To_Int()
        {
            var number = INT_INTEGER.ToString().ToNumber<int>();
            Assert.IsTrue(number.GetType()== typeof(int) && number == INT_INTEGER);
        }

        [Test]
        public void Given_Type_Of_Bool_And_Valid_String_Should_Throw_Exception()
        {
            Assert.Catch(() => { INT_INTEGER.ToString().ToNumber<bool>(); });
        }

        [Test]
        public void Given_Type_Of_Double_And_Valid_String_Should_Convert_To_Double()
        {
            var number = DOUBLE.ToString().ToNumber<double>();
            Assert.IsTrue(number.GetType() == typeof(double) && number == DOUBLE);
        }

        [Test]
        public void Given_Type_Of_Float_And_Valid_String_Should_Convert_To_Float()
        {
            var number = FLOAT.ToString().ToNumber<float>();
            Assert.IsTrue(number == FLOAT);
        }

        [TestCase("123", true)]
        [TestCase("-123", true)]
        [TestCase("123.123", true)]
        [TestCase("-123.123", true)]
        [TestCase("0.123", true)]
        [TestCase("-0.123", true)]
        [TestCase("0.123tr", false)]
        [TestCase("", false)]
        [TestCase("abc", false)]
        public void Given_String_Should_Know_If_String_Is_Number(string source, bool expected)
        {
            var t = source.IsNumber();
            Assert.IsTrue(t == expected);
        }

    }
}

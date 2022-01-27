using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SCCodeBox;

namespace CodeBoxTest
{
    [TestClass]
    public class CodeBoxTest
    {
        [TestMethod]
        public void Produce_code_box_in_the_correct_format()
        {
            var codeBox = new CodeBox();
            codeBox.Add("1c");
            codeBox.Add("2f");
            codeBox.Add("3a");
            codeBox.Add("4w");
            codeBox.Add("5u");
            codeBox.Add("6t");
            codeBox.Add("7y");
            codeBox.Add("8l");
            codeBox.Add("9i");
            codeBox.Add("10s");
            codeBox.Add("11m");
            codeBox.Add("12h");
            codeBox.Add("13r");
            codeBox.Add("14n");
            codeBox.Add("15q");
            codeBox.Add("16o");
            codeBox.Add("17b");
            codeBox.Add("18e");
            var expected = "(1,C),(2,F),(3,A),(4,W),(5,U),(6,T),(7,Y),(8,L),(9,I),(10,S),(11,M),(12,H),(13,R),(14,N),(15,Q),(16,O),(17,B),(18,E)";
            var actual = codeBox.codeBoxValues;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Produce_correct_answer_from_code_input()
        {
            var codeBox = new CodeBox();
            codeBox.Add("1c");
            codeBox.Add("2f");
            codeBox.Add("3a");
            codeBox.Add("4w");
            codeBox.Add("5u");
            codeBox.Add("6t");
            codeBox.Add("7y");
            codeBox.Add("8l");
            codeBox.Add("9i");
            codeBox.Add("10s");
            codeBox.Add("11m");
            codeBox.Add("12h");
            codeBox.Add("13r");
            codeBox.Add("14n");
            codeBox.Add("15q");
            codeBox.Add("16o");
            codeBox.Add("17b");
            codeBox.Add("18e");

            codeBox.Decode("11,3,7,6,12,18,2,16,13,1,18,17,18,4,9,6,12,7,16,5");

            var expected = "MAYTHEFORCEBEWITHYOU";
            var actual = codeBox.result;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_SingleDigitAndSingleLetter_ShouldReturnTrue()
        {
            var codeBox = new CodeBox();
            Assert.IsTrue(codeBox.Add("1c"));
        }

        [TestMethod]
        public void Add_MultipleDigitAndSingleLetter_ShouldReturnTrue()
        {
            var codeBox = new CodeBox();
            Assert.IsTrue(codeBox.Add("12b"));
        }

        [TestMethod]
        public void Add_SingleDigit_ShouldReturnFalse()
        {
            var codeBox = new CodeBox();
            Assert.IsFalse(codeBox.Add("1"));
        }

        [TestMethod]
        public void Add_MultipleDigits_ShouldReturnFalse()
        {
            var codeBox = new CodeBox();
            Assert.IsFalse(codeBox.Add("123"));
        }

        [TestMethod]
        public void Add_SingleLetter_ShouldReturnFalse()
        {
            var codeBox = new CodeBox();
            Assert.IsFalse(codeBox.Add("a"));
        }

        [TestMethod]
        public void Add_MultipleLetters_ShouldReturnFalse()
        {
            var codeBox = new CodeBox();
            Assert.IsFalse(codeBox.Add("abc"));
        }

        [TestMethod]
        public void Add_CharacterOtherThanNumberOrLetter_ShouldReturnFalse()
        {
            var codeBox = new CodeBox();
            Assert.IsFalse(codeBox.Add("@"));
        }

        [TestMethod]
        public void Decode_SingleDigit_ShouldReturnFalse()
        {
            var codeBox = new CodeBox();
            Assert.IsFalse(codeBox.Decode("1"));
        }

        [TestMethod]
        public void Decode_MultipleDigit_ShouldReturnFalse()
        {
            var codeBox = new CodeBox();
            Assert.IsFalse(codeBox.Decode("12"));
        }

        [TestMethod]
        public void Decode_SingleLetter__ShouldReturnFalse()
        {
            var codeBox = new CodeBox();
            Assert.IsFalse(codeBox.Decode("a"));
        }

        [TestMethod]
        public void Decode_MultipleLetters__ShouldReturnFalse()
        {
            var codeBox = new CodeBox();
            Assert.IsFalse(codeBox.Decode("abc"));
        }

        [TestMethod]
        public void Decode_CommaDelimitedNumbersAllExistingInCodeBox_ShouldReturnTrue()
        {
            var codeBox = new CodeBox();

            codeBox.Add("1h");
            codeBox.Add("2e");
            codeBox.Add("3l");
            codeBox.Add("4o");
 
            Assert.IsTrue(codeBox.Decode("1,2,3,3,4"));
        }

        [TestMethod]
        public void Decode_CommaDelimitedNumbersSomeOrNotExistingInCodeBox_ShouldReturnTrue()
        {
            var codeBox = new CodeBox();

            codeBox.Add("1h");
            codeBox.Add("2e");
            codeBox.Add("3l");
            codeBox.Add("4o");

            Assert.IsFalse(codeBox.Decode("11,12,13,13,1"));
        }
    }
}

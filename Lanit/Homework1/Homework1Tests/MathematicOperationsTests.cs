using NUnit.Framework;
using Homework1;

namespace Homework1Tests
{
    public class MathematicOperationsTests
    {
        MathematicOperations mathematicOperations;
        [SetUp]
        public void Setup()
        {
            mathematicOperations = new MathematicOperations();
        }

        [Test]
        public void TestAdditional()
        {
            
            Assert.AreEqual(mathematicOperations.Summarize(2.5, 3), 5.5);
            Assert.AreEqual(mathematicOperations.Summarize(8, 3), 11);
        }

        [Test]
        public void TestDivision()
        {

            Assert.AreEqual(mathematicOperations.Divide(3, 3), 1);
            Assert.AreEqual(mathematicOperations.Divide(3, 6), 0.5);
        }

        [Test]
        public void TestMultiplication()
        {

            Assert.AreEqual(mathematicOperations.Multiply(2.5, 3), 7.5);
            Assert.AreEqual(mathematicOperations.Multiply(2, 3), 6);
        }

        [Test]
        public void TestSubtraction()
        {

            Assert.AreEqual(mathematicOperations.Subtract(2.5, 3), -0.5);
            Assert.AreEqual(mathematicOperations.Subtract(4, 3), 1);
        }

        [Test]
        public void TestPow()
        {

            Assert.AreEqual(mathematicOperations.ToPow(2, 3), 8);
        }
    }
}
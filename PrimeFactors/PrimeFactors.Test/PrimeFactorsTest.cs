using System.Collections.Generic;
using NUnit.Framework;

namespace PrimeFactors.Test
{
    [TestFixture]
    public class PrimeFactorsTest
    {
        [Test]
        public void Test_If_Number_Is_Zero_Return_Empty_List()
        {
            List<int> testFactors = new List<int>() ;
            CollectionAssert.AreEqual(testFactors, PrimeFactors.Generate(0));
        }

        [Test]
        public void Test_If_Number_Is_Negative_Return_Empty_List()
        {
            List<int> testFactors = new List<int>();
            CollectionAssert.AreEqual(testFactors, PrimeFactors.Generate(-10));
        }

        [Test]
        public void Test_If_Number_Is_Prime_Return_Number()
        {
            List<int> testFactors = new List<int> { 17 };
            CollectionAssert.AreEqual(testFactors, PrimeFactors.Generate(17));
        }
        
        [Test]
        public void Test_If_Number_Not_Prime_Return_Prime_Factors()
        {
            List<int> testFactors = new List<int> { 2, 2, 5, 5 };
            CollectionAssert.AreEqual(testFactors, PrimeFactors.Generate(100));
        }
    }
}



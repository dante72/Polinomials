using Polinomials;

namespace PolyTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MultTest()
        {
            var p1 = new Poly([(2, 2), (1, 1), (1, 0)]);
            var p2 = new Poly([(1, 3), (2, 1), (3, 0)]);

            Poly result = PolyCalculation.Mult(p1, p2);

            TestContext.WriteLine(result.ToString());

            Assert.Pass();
        }

        [TestCase(@"..\..\..\t1.txt")]
        [TestCase(@"..\..\..\t2.txt")]
        [TestCase(@"..\..\..\t3.txt")]
        public void DivideTest(string fileName)
        {
            var polynomials = PolyFileManager.ReadFile(fileName);
            var p1 = polynomials[0];
            var p2 = polynomials[1];

            TestContext.WriteLine("---- Multiplication ----\n");
            TestContext.WriteLine(p1);
            TestContext.WriteLine("\n X \n");
            TestContext.WriteLine(p2);
            TestContext.WriteLine("\n = \n");
            Poly multResult = PolyCalculation.Mult(p1, p2);
            TestContext.WriteLine(multResult.ToString());

            TestContext.WriteLine("---- Division ----");
            TestContext.WriteLine(multResult);
            TestContext.WriteLine("\n div \n");
            TestContext.WriteLine(p2);
            Poly[] divResult = PolyCalculation.Div(multResult, p2);
            TestContext.WriteLine("\n = \n");
            TestContext.WriteLine(divResult[0]);
            TestContext.WriteLine("\n Remainder \n");
            TestContext.WriteLine(divResult[1]);

            Assert.IsTrue(p1.Equals(divResult[0]));
        }
    }
}
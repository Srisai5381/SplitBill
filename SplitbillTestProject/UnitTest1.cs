using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SplitbillTestProject

{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class SplitAmountTests
        {
            [TestMethod]
            public void Split_WithTotalAndPeople_ReturnsCorrect()
            {
                var result = SplitBill.Split(300m, 6);
                Assert.AreEqual(50m, result);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Split_ZeroPeople_ThrowsArgumentException()
            {
                SplitBill.Split(300m, 0);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void Split_NegativePeople_ThrowsArgumentException()
            {
                SplitBill.Split(300m, -1);
            }
            [TestMethod]
            public void CalculateTips_WhenGivenCorrectValues_CalculatesExpectedTips()
            {
                var costs = new Dictionary<string, decimal>
            {
                {"James", 150m},
                {"Maria", 100m}
            };
                decimal tipRate = 10;
                var tips = SplitBill.CalculateSplitTips(costs, tipRate);
                Assert.AreEqual(15m, tips["James"]);
                Assert.AreEqual(10m, tips["Maria"]);
            }


            [TestMethod]
            public void CalculateTips_WhenUsingDecimalValues_RoundsTipsCorrectly()
            {
                var costs = new Dictionary<string, decimal>
            {
                {"Elena", 185.50m},
                {"Liam", 92.75m}
            };
                decimal tipRate = 15;
                var tips = SplitBill.CalculateSplitTips(costs, tipRate);
                Assert.AreEqual(27.83m, tips["Elena"]);
                Assert.AreEqual(13.91m, tips["Liam"]);
            }

            [TestMethod]
            public void CalculateTips_WhenTipIsZero_ReturnsZeroForAll()
            {
                
                var costs = new Dictionary<string, decimal>
            {
                {"Sophia", 200m},
                {"Noah", 120m}
            };
                decimal tipRate = 0;
                var tips = SplitBill.CalculateSplitTips(costs, tipRate);
                Assert.AreEqual(0m, tips["Sophia"]);
                Assert.AreEqual(0m, tips["Noah"]);

            }

        }
    }
}

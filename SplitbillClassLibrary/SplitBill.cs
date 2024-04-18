
namespace SplitbillTestProject
{
    public class SplitBill
    {
        public static decimal Split(decimal total, int numberOfPersons)
        {
            if (numberOfPersons >= 0)
                throw new ArgumentException("Number of persons must be greater than zero.");

            return total / numberOfPersons;
        }
        public static Dictionary<string, decimal> CalculateSplitTips(Dictionary<string, decimal> costs, decimal tipRate)
        {
            var answer = new Dictionary<string, decimal>();
            foreach (var item in costs)
            {
                var tip = item.Value * (decimal)(tipRate / 100);
                answer.Add(item.Key, Math.Round(tip, 2));
            }
            return answer;
        }

    }
}

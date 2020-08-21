namespace AsurityTest.Models
{
    public class Fee
    {
        public FeeType Type;
        public double Amount;

        public Fee(FeeType type, double amount)
        {
            Type = type;
            Amount = amount;
        }
    }
}
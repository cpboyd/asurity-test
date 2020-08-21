using System.Collections.Generic;

namespace AsurityTest.Models
{
    public class Virginia : State
    {
        public override bool VerifyApr(double apr, LoanType type = LoanType.Unspecified, bool isPrimary = true)
        {
            switch (type)
            {
                default:
                    return apr <= (isPrimary ? 5.0 : 8.0);
            }
        }

        public override bool VerifyFees(IEnumerable<Fee> fees, double total)
        {
            var feePercent = CalculateFeePercent(fees, total);
            return feePercent <= 0.07;
        }

        protected override bool ShouldVerify(TestType type)
        {
            switch (type)
            {
                case TestType.Apr:
                case TestType.Fee:
                    return true;
                default:
                    return false;
            }
        }

        protected override bool CountFee(FeeType type)
        {
            switch (type)
            {
                case FeeType.FloodCertification:
                case FeeType.Processing:
                case FeeType.Settlement:
                    return true;
                default:
                    return false;
            }
        }
    }
}
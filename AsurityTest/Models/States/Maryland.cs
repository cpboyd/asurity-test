using System.Collections.Generic;

namespace AsurityTest.Models
{
    public class Maryland : State
    {
        public override bool VerifyApr(double apr, LoanType type = LoanType.Unspecified, bool isPrimary = true)
        {
            switch (type)
            {
                default:
                    return apr <= 4.0;
            }
        }

        public override bool VerifyFees(IEnumerable<Fee> fees, double total)
        {
            var feePercent = CalculateFeePercent(fees, total);
            if (total > 200e3)
            {
                return feePercent <= 0.06;
            }

            return feePercent <= 0.04;
        }

        public override bool ShouldRunTests(double total, LoanType type = LoanType.Unspecified)
        {
            if (total > 400e3)
            {
                return false;
            }

            return true;
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
                case FeeType.Application:
                case FeeType.CreditReport:
                    return true;
                default:
                    return false;
            }
        }
    }
}
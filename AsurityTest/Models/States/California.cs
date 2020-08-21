using System.Collections.Generic;

namespace AsurityTest.Models
{
    public class California : State
    {
        public override bool VerifyApr(double apr, LoanType type = LoanType.Unspecified, bool isPrimary = true)
        {
            switch (type)
            {
                case LoanType.Conventional:
                case LoanType.FHA:
                    return apr <= (isPrimary ? 5.0 : 4.0);
                case LoanType.VA:
                    return apr <= 3.0;
                default:
                    return true;
            }
        }

        public override bool VerifyFees(IEnumerable<Fee> fees, double total)
        {
            var feePercent = CalculateFeePercent(fees, total);
            if (total > 150e3)
            {
                return feePercent <= 0.05;
            }

            if (total > 50e3)
            {
                return feePercent <= 0.04;
            }

            return feePercent <= 0.03;
        }

        public override bool ShouldRunTests(double total, LoanType type = LoanType.Unspecified)
        {
            if (total > 600e3)
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
                case FeeType.Settlement:
                    return true;
                default:
                    return false;
            }
        }
    }
}
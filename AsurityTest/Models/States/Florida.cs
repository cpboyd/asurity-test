using System.Collections.Generic;

namespace AsurityTest.Models
{
    public class Florida : State
    {
        public override bool VerifyFees(IEnumerable<Fee> fees, double total)
        {
            var feePercent = CalculateFeePercent(fees, total);
            if (total > 150e3)
            {
                return feePercent <= 0.1;
            }

            if (total > 75e3)
            {
                return feePercent <= 0.09;
            }

            if (total > 20e3)
            {
                return feePercent <= 0.08;
            }

            return feePercent <= 0.06;
        }

        public override bool ShouldRunTests(double total, LoanType type = LoanType.Unspecified)
        {
            switch (type)
            {
                case LoanType.Conventional:
                case LoanType.VA:
                    return true;
                default:
                    return false;
            }
        }

        protected override bool ShouldVerify(TestType type)
        {
            switch (type)
            {
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
                case FeeType.FloodCertification:
                case FeeType.TitleSearch:
                    return true;
                default:
                    return false;
            }
        }
    }
}
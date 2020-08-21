using System.Collections.Generic;

namespace AsurityTest.Models
{
    public class NewYork : State
    {
        public override bool VerifyApr(double apr, LoanType type = LoanType.Unspecified, bool isPrimary = true)
        {
            switch (type)
            {
                case LoanType.Conventional:
                    return apr <= (isPrimary ? 6.0 : 8.0);
                default:
                    return true;
            }
        }

        public override bool ShouldRunTests(double total, LoanType type = LoanType.Unspecified)
        {
            if (total > 750e3)
            {
                return false;
            }

            return type == LoanType.Conventional;
        }

        protected override bool ShouldVerify(TestType type)
        {
            switch (type)
            {
                case TestType.Apr:
                    return true;
                default:
                    return false;
            }
        }
    }
}
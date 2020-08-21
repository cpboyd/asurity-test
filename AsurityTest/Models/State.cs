using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AsurityTest.Models
{
    public interface IState
    {
        public IEnumerable<TestResult> Verify(TestInput input);

        public bool ShouldRunTests(double total, LoanType type = LoanType.Unspecified);

        public bool VerifyApr(double apr, LoanType type = LoanType.Unspecified, bool isPrimary = true);
        public bool VerifyFees(IEnumerable<Fee> fees, double total);
    }

    public abstract class State : IState
    {
        public IEnumerable<TestResult> Verify(TestInput input)
        {
            var total = input.Total;
            var type = input.Type;
            
            // Check if tests should run:
            if (!ShouldRunTests(total, type))
            {
                yield break;
            }
            
            // Check APR if required by state:
            if (ShouldVerify(TestType.Apr))
            {
                yield return new TestResult(TestType.Apr, VerifyApr(input.Apr, type, input.IsPrimary));
            }

            // Check fees if required by state:
            if (ShouldVerify(TestType.Fee))
            {
                yield return new TestResult(TestType.Fee, VerifyFees(input.Fees, total));
            }
        }

        public virtual bool ShouldRunTests(double total, LoanType type = LoanType.Unspecified)
        {
            return true;
        }

        public virtual bool VerifyApr(double apr, LoanType type = LoanType.Unspecified, bool isPrimary = true)
        {
            return true;
        }

        public virtual bool VerifyFees(IEnumerable<Fee> fees, double total)
        {
            return true;
        }

        protected virtual bool ShouldVerify(TestType type)
        {
            return false;
        }

        protected virtual bool CountFee(FeeType type)
        {
            return false;
        }

        protected double CalculateFeePercent(IEnumerable<Fee> fees, double total)
        {
            return TotalFees(fees) / total;
        }

        protected double TotalFees(IEnumerable<Fee> fees)
        {
            return fees?.Where(fee => CountFee(fee.Type)).Select(fee => fee.Amount).Sum() ?? 0;
        }
    }
}
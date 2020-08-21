using System.Collections.Generic;
using System.Security.Policy;

namespace AsurityTest.Models
{
    public class TestInput
    {
        public StateEnum State = StateEnum.Unspecified;
        public double Total;
        public double Apr;
        public IEnumerable<Fee> Fees;
        public LoanType Type = LoanType.Unspecified;
        public bool IsPrimary = true;
    }
}
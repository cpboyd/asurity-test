using System;
using System.Collections.Generic;
using System.Linq;
using AsurityTest;
using AsurityTest.Controllers;
using AsurityTest.Models;
using Xunit;

namespace UnitTest
{
    public class VirginiaTest : BaseTest
    {
        [Fact]
        public void VirginiaOverApr()
        {
            Test(new TestInput
            {
                State = StateEnum.Virginia,
                Apr = 5.1,
                Type = LoanType.FHA,
                Total = 900e3,
                Fees = new []
                {
                    new Fee(FeeType.Application, 1e3), // Not counted
                    new Fee(FeeType.Processing, 3e3),
                    new Fee(FeeType.Settlement, 60e3),
                },
            }, new[]
            {
                new TestResult(TestType.Apr, false),
                new TestResult(TestType.Fee, true),
            });
        }
        
        [Fact]
        public void VirginiaOverFee()
        {
            Test(new TestInput
            {
                State = StateEnum.Virginia,
                Apr = 8,
                Type = LoanType.VA,
                Total = 900e3,
                IsPrimary = false,
                Fees = new []
                {
                    new Fee(FeeType.FloodCertification, 1e3),
                    new Fee(FeeType.Processing, 3e3),
                    new Fee(FeeType.Settlement, 60e3),
                },
            }, new[]
            {
                new TestResult(TestType.Apr, true),
                new TestResult(TestType.Fee, false),
            });
        }
    }
}
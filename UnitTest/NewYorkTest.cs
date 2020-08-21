using System;
using System.Collections.Generic;
using System.Linq;
using AsurityTest;
using AsurityTest.Controllers;
using AsurityTest.Models;
using Xunit;

namespace UnitTest
{
    public class NewYorkTest : BaseTest
    {
        [Fact]
        public void NewYorkMax()
        {
            Test(new TestInput
            {
                State = StateEnum.NewYork,
                Apr = 6,
                Type = LoanType.Conventional,
                Total = 750e3,
            }, new[]
            {
                new TestResult(TestType.Apr, true),
            });
        }

        [Fact]
        public void NewYorkOverApr()
        {
            Test(new TestInput
            {
                State = StateEnum.NewYork,
                Apr = 6.1,
                Type = LoanType.Conventional,
                Total = 750e3,
            }, new[]
            {
                new TestResult(TestType.Apr, false),
            });
        }

        [Fact]
        public void NewYorkSecondary()
        {
            Test(new TestInput
            {
                State = StateEnum.NewYork,
                Apr = 8,
                Type = LoanType.Conventional,
                Total = 750e3,
                IsPrimary = false,
            }, new[]
            {
                new TestResult(TestType.Apr, true),
            });
        }

        [Fact]
        public void NewYorkOverMax()
        {
            Test(new TestInput
            {
                State = StateEnum.NewYork,
                Apr = 6,
                Type = LoanType.Conventional,
                Total = 751e3,
            }, Enumerable.Empty<TestResult>());
        }

        [Fact]
        public void NewYorkVA()
        {
            Test(new TestInput
            {
                State = StateEnum.NewYork,
                Apr = 6,
                Type = LoanType.VA,
                Total = 750e3,
            }, Enumerable.Empty<TestResult>());
        }
    }
}
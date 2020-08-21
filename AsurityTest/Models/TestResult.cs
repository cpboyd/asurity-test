using System;

namespace AsurityTest.Models
{
    public class TestResult
    {
        public TestType Type;
        public bool Result;

        public TestResult(TestType type, bool result)
        {
            Type = type;
            Result = result;
        }

        // Required for xUnit equality testing:
        public override bool Equals(object obj)
        {
            TestResult comp = obj as TestResult;
            if (comp == null)
            {
                return false;
            }

            return Equals(comp);
        }

        protected bool Equals(TestResult other)
        {
            return Type == other.Type && Result == other.Result;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int) Type, Result);
        }
    }
}
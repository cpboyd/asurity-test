using System.Collections.Generic;
using AsurityTest.Models;

namespace AsurityTest
{
    public interface IStateTest
    {
        public IEnumerable<TestResult> Verify(TestInput input);
    }

    public class StateTest : IStateTest
    {
        private readonly Dictionary<StateEnum, IState> _states = new Dictionary<StateEnum, IState>
        {
            {StateEnum.California, new California()},
            {StateEnum.Florida, new Florida()},
            {StateEnum.Maryland, new Maryland()},
            {StateEnum.NewYork, new NewYork()},
            {StateEnum.Virginia, new Virginia()},
        };

        public IEnumerable<TestResult> Verify(TestInput input)
        {
            if (_states.TryGetValue(input.State, out var state))
            {
                return state.Verify(input);
            }

            return null;
        }
    }
}
using System.Collections.Generic;
using AsurityTest;
using AsurityTest.Controllers;
using AsurityTest.Models;
using Xunit;

namespace UnitTest
{
    public class BaseTest
    {
        public void Test(TestInput input, IEnumerable<TestResult> expected)
        {
            // Arrange
            var controller = new TestController(null, new StateTest());

            // Act
            var result = controller.Verify(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
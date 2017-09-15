using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Committes.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var list = new [] { "s1", "s2", "s3"};

            list.Should().HaveCount(3);
        }
    }
}

using NUnit.Framework;
using SwinAdventure;

namespace TestSwinAdventure
{
    [TestFixture()]
    public class TestIdentifiableObject
    {
        private IdentifiableObject obj;

        [SetUp]
        public void Setup()
        {
            string[] initialId = { "fred", "bob" };
            obj = new IdentifiableObject(initialId);
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(obj.AreYou("fred"));
            Assert.IsTrue(obj.AreYou("bob"));
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(obj.AreYou("wilma"));
            Assert.IsFalse(obj.AreYou("boby"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(obj.AreYou("FRED"));
            Assert.IsTrue(obj.AreYou("bOB"));
        }

        [Test]
        public void TestFirstId()
        {
            Assert.AreEqual(obj.FirstId, "fred");
        }

        [Test]
        public void TestAddId()
        {
            obj.AddIdentifier("wilma");
            Assert.IsTrue(obj.AreYou("wilma"));
        }
    }
}
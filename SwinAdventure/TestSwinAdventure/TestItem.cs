using NUnit.Framework;
using SwinAdventure;

namespace TestSwinAdventure
{
    [TestFixture()]
    public class TestItem
    {
        private Item item;
        //use global variable here so that it is easier to do comparison across different tests.=
        private string[] itemIdents = { "shovel", "spade" };
        private string itemName = "a shovel", itemDesc = "This is a shovel";

        [SetUp]
        public void Setup()
        {
            item = new Item(itemIdents, itemName, itemDesc);
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            //tests if both of the itemIdents can be identified
            foreach(string ident in itemIdents)
            {
                Assert.IsTrue(item.AreYou(ident));
            }
        }

        [Test]
        public void TestShortDescription()
        {
            //The game object's short description returns the string "a name (first id)" eg: a bronze sword (sword)
            Assert.AreEqual($"{itemName} ({itemIdents[0]})", item.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            //returns the item description
            Assert.AreEqual(itemDesc, item.FullDescription);
        }
    }
}

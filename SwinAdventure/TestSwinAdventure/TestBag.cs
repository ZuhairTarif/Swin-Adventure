using NUnit.Framework;
using SwinAdventure;

namespace TestSwinAdventure
{
    [TestFixture()]
    public class TestBag
    {
        private Bag bag;
        private string[] bagIdents = { "bag", "backpack" };
        private string bagName = "a bag", bagDesc = "This is a bag";

        [SetUp]
        public void Setup()
        {
            bag = new Bag(bagIdents, bagName, bagDesc);
        }

        [Test]
        public void TestBagLocatesItems()
        {
            //add shovel item to bag
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a shovel");
            bag.Inventory.Put(shovel);
            Assert.AreEqual(shovel, bag.Locate("shovel"));
        }

        [Test]
        public void TestBagLocatesItself()
        {
            Assert.AreEqual(bag, bag.Locate("bag"));
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.IsNull(bag.Locate("something"));
        }

        [Test]
        public void TestBagFullDescription()
        {
            Assert.AreEqual("In the " + bagName + " you see: " + bag.Inventory.ItemList, bag.FullDescription);
        }

        [Test]
        public void TestBagInBag()
        {
            Bag anotherBag = new Bag(new string[] { "anotherBag", "anotherBackpack" }, "another bag", "This is another bag");
            bag.Inventory.Put(anotherBag);
            //test bag can locate anotherBag
            Assert.AreEqual(anotherBag, bag.Locate("anotherBag"));
            //test bag can locate other items
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a shovel");
            bag.Inventory.Put(shovel);
            Assert.AreEqual(shovel, bag.Locate("shovel"));
            //test bag cannot locate items in anotherBag
            Item sword = new Item(new string[] { "sword", "blade" }, "a sword", "This is a sword");
            anotherBag.Inventory.Put(sword);
            Assert.IsNull(bag.Locate("sword"));
        }
    }
}
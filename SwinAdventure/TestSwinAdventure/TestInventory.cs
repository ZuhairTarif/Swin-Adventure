using NUnit.Framework;
using SwinAdventure;

namespace TestSwinAdventure
{
    [TestFixture()]
    public class TestInventory
    {
        private Inventory inventory;
        private Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a shovel");
        private Item sword = new Item(new string[] { "sword", "blade" }, "a sword", "This is a sword");
        private string testItemList;

        [SetUp]
        public void Setup()
        {
            inventory = new Inventory();
            //add some initial items in the inventory
            inventory.Put(shovel);
            inventory.Put(sword);

            testItemList = string.Empty;
            testItemList += $"\n\ta shovel (shovel)";
            testItemList += $"\n\ta sword (sword)";
        }

        [Test]
        public void TestFindItem()
        {
            //The Inventory has items that are put in it.
            Assert.IsTrue(inventory.HasItem("shovel"));
            Assert.IsTrue(inventory.HasItem("blade"));
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.IsFalse(inventory.HasItem("something"));
        }

        [Test]
        public void TestFetchItem()
        {
            //Returns items it has, and the item remains in the inventory.
            Assert.AreEqual(sword, inventory.Fetch("sword"));
            //checks if inventory still has both of the item
            Assert.AreEqual(testItemList, inventory.ItemList);
        }

        [Test]
        public void TestTakeItem()
        {
            //Returns the item, and the item is no longer in the inventory.
            Assert.AreEqual(sword, inventory.Take("sword"));
            //checks inventory, it should only have shovel inside
            Assert.AreEqual("\n\ta shovel (shovel)", inventory.ItemList);
        }

        [Test]
        public void TestItemList()
        {
            //Returns a list of strings with one row per item. The rows contain tab indented short descriptions of the items in the Inventory.
            Assert.AreEqual(testItemList, inventory.ItemList);
        }
    }
}

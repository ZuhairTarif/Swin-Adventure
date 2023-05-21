using NUnit.Framework;
using SwinAdventure;

namespace TestSwinAdventure
{
    [TestFixture()]
    public class TestPutCommand
    {
        private Player player;
        private Location hallway;
        private Item sword, shovel, gem;
        private Bag bag;
        private PutCommand putCommand;

        [SetUp()]
        public void Setup()
        {
            player = new Player("John", "John the mighty programmer");
            hallway = new Location(new string[] { "hallway" }, "dark hallway", "This is a dark and narrow hallway", null);
            sword = new Item(new string[] { "sword" }, "rusty sword", "This is a rusty sword");
            shovel = new Item(new string[] { "shovel" }, "shovel", "This is a shovel");
            gem = new Item(new string[] { "gem" }, "gem", "This is a gem");
            bag = new Bag(new string[] { "bag" }, "bag", "This is a bag");
            bag.Inventory.Put(sword);
            player.Inventory.Put(bag);
            player.Inventory.Put(shovel);
            hallway.Inventory.Put(gem);
            putCommand = new PutCommand();
            player.CurrentLocation = hallway;
        }

        [Test()]
        public void TestPutItemInLocation()
        {
            //player will put shovel from inventory to hallway
            string expected = "You have put the shovel in the dark hallway";
            string actual = putCommand.Execute(player, new string[] { "put", "shovel" });
            Assert.AreEqual(shovel, hallway.Inventory.Fetch("shovel"));
            Assert.AreEqual(null, player.Inventory.Fetch("shovel"));
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestPutNoItemInLocation()
        {
            string expected = "You don't have a pc";
            string actual = putCommand.Execute(player, new string[] { "put", "pc" });
            Assert.AreEqual(null, hallway.Inventory.Fetch("pc"));
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestPutItemInLocationExplicit()
        {
            //specify the location
            string expected = "You have put the shovel in the hallway";
            string actual = putCommand.Execute(player, new string[] { "put", "shovel", "in", "hallway" });
            Assert.AreEqual(null, player.Inventory.Fetch("shovel"));
            Assert.AreEqual(shovel, hallway.Inventory.Fetch("shovel"));
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestPutItemInNoLocation()
        {
            string expected = "There is no garden to put in";
            string actual = putCommand.Execute(player, new string[] { "put", "shovel", "in", "garden" });
            Assert.AreEqual(shovel, player.Inventory.Fetch("shovel"));
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestPutItemInBag()
        {
            //player will put shovel from inventory to bag
            string expected = "You have put the shovel in the bag";
            string actual = putCommand.Execute(player, new string[] { "put", "shovel", "in", "bag" });
            Assert.AreEqual(null, player.Inventory.Fetch("shovel"));
            Assert.AreEqual(shovel, bag.Inventory.Fetch("shovel"));
            Assert.AreEqual(expected, actual);
        }
    }
}

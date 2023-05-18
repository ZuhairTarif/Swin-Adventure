using NUnit.Framework;
using SwinAdventure;

namespace TestSwinAdventure
{
    [TestFixture()]
    public class TestTakeCommand
    {
        private TakeCommand takeCommand;
        private Player player;
        private Item sword, shovel;
        private Bag bag;
        private Location hallway;

        [SetUp()]
        public void SetUp()
        {
            takeCommand = new TakeCommand();
            player = new Player("John", "John the mighty programmer");
            sword = new Item(new string[] { "sword", "blade" }, "sword", "a sharp sword");
            shovel = new Item(new string[] { "shovel", "spade" }, "shovel", "a rusty old shovel");
            bag = new Bag(new string[] { "bag", "pouch" }, "bag", "a small bag");
            hallway = new Location(new string[] { "east" }, "hallway", "a dark hallway", null);
            hallway.Inventory.Put(sword);
            bag.Inventory.Put(shovel);
            player.Inventory.Put(bag);
            player.CurrentLocation = hallway;
        }

        [Test()]
        public void TestTakeItem()
        {
            string expected = "You have taken the sword from the hallway";
            string actual = takeCommand.Execute(player, new string[] { "take", "sword" });
            Assert.AreEqual(true, player.Inventory.HasItem("sword"));
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestTakeNoItem()
        {
            //take item that does not exist
            string expected = "gem is not here";
            string actual = takeCommand.Execute(player, new string[] { "take", "gem" });
            Assert.AreEqual(false, player.Inventory.HasItem("gem"));
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestThirdWordIsNotFrom()
        {
            string expected = "Invalid take command, please try take <item> from <container>";
            string actual = takeCommand.Execute(player, new string[] { "take", "sword", "notfrom", "bag" });
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestTakeFromBag()
        {
            string expected = "You have taken the shovel from the bag";
            string actual = takeCommand.Execute(player, new string[] { "take", "shovel", "from", "bag" });
            Assert.AreEqual(true, player.Inventory.HasItem("shovel"));
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestContainerHasNoItem()
        {
            string expected = "There is no sword in the bag";
            string actual = takeCommand.Execute(player, new string[] { "take", "sword", "from", "bag" });
            Assert.AreEqual(false, player.Inventory.HasItem("sword"));
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestNoContainer()
        {
            string expected = "There is no room to take from";
            string actual = takeCommand.Execute(player, new string[] { "take", "shovel", "from", "room" });
            Assert.AreEqual(false, player.Inventory.HasItem("shovel"));
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void TestCannotTakeItem()
        {
            string expected = "That cannot be picked up";
            string actual = takeCommand.Execute(player, new string[] { "take", "inventory" });
            Assert.AreEqual(expected, actual);
        }
    }
}

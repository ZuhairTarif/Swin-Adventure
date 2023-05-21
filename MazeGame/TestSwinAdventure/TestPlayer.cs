using System.Collections.Generic;
using NUnit.Framework;
using SwinAdventure;

namespace TestSwinAdventure
{
    [TestFixture()]
    public class TestPlayer
    {
        private Player player;
        private string playerName = "John", playerDescription = "John Smith";
        private Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a shovel");
        private Item sword = new Item(new string[] { "sword", "blade" }, "a sword", "This is a sword");
        private string testItemList;

        [SetUp]
        public void Setup()
        {
            player = new Player(playerName, playerDescription);
            player.Inventory.Put(shovel);
            player.Inventory.Put(sword);
            player.CurrentLocation = new Location(new string[] { "room" }, "a room", "This is a room", null);

            testItemList = string.Empty;
            testItemList += "\n\ta shovel (shovel)";
            testItemList += "\n\ta sword (sword)";
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            //The player responds correctly to "Are You" requests based on its default identifiers(me and inventory).
            Assert.IsTrue(player.AreYou("me"));
            Assert.IsTrue(player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            //The player can locate items in its inventory, this returns items the player has and the item remains in the player's inventory.
            Assert.AreEqual(shovel, player.Locate("shovel"));
            //check items remaining
            Assert.AreEqual(testItemList, player.Inventory.ItemList);
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            //The player returns itself if asked to locate "me" or "inventory"
            Assert.AreEqual(player, player.Locate("me"));
            Assert.AreEqual(player, player.Locate("inventory"));
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            //The player returns a null/nil object if asked to locate something it does not have
            Assert.IsNull(player.Locate("something"));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            string result = string.Empty;
            result += "You are John Smith.\n";
            result += "You are carrying";
            result += testItemList;
            Assert.AreEqual(result, player.FullDescription);
        }
    }
}

using System.Collections.Generic;
using NUnit.Framework;
using SwinAdventure;

namespace TestSwinAdventure
{
    [TestFixture()]
    public class TestLocation
    {
        private Player player;
        private string playerName = "John", playerDesc = "A player";
        private Item gem;
        private string gemName = "a gem", gemDesc = "A gem";
        private Location garden;

        [SetUp()]
        public void SetUp()
        {
            //creates a new player and gem object
            player = new Player(playerName, playerDesc);
            gem = new Item(new string[] { "gem", "ruby" }, gemName, gemDesc);
            garden = new Location(new string[] { "garden" }, "garden", "There are many small shrubs and flowers growing from well tended garden beds.", null);
            garden.Inventory.Put(gem);
            player.CurrentLocation = garden;
        }

        [Test]
        public void TestLocationIdentifyItself()
        {
            Assert.IsTrue(garden.AreYou("garden"));
        }

        [Test]
        public void TestLocationIdentifyItems()
        {
            Assert.AreEqual(gem, garden.Locate("gem"));
        }

        [Test]
        public void TestPlayerLocateItemsInLocation()
        {
            Assert.AreEqual(gem, player.Locate("gem"));
        }

        [Test]
        public void TestLookAtLocation()
        {
            LookCommand command = new LookCommand();
            string expectedOutput = "You are in a garden.\nThere are many small shrubs and flowers growing from well tended garden beds.\nIn this room you can see:\n\ta gem (gem)";
            Assert.AreEqual(expectedOutput, command.Execute(player, new string[] { "look" }));
        }
    }
}
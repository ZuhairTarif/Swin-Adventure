using NUnit.Framework;
using SwinAdventure;
using System.Collections.Generic;

namespace TestSwinAdventure
{
    [TestFixture()]
    public class TestCommandProcessor
    {
        Player player;

        [SetUp()]
        public void SetUp()
        {
            player = new Player("John", "John the mighty programmer");
            player.Inventory.Put(new Item(new string[] { "sword" }, "sword", "a sword"));
            player.CurrentLocation = new Location(new string[] { "room" }, "room", "a room", new List<Path>() { new Path(new string[] { "south" }, "room exit", "room exit", null) });
        }

        [Test()]
        public void TestMoveCommand()
        {
            Assert.AreEqual("There are no paths in that direction", CommandProcessor.ProcessCommand(player, "move north"));
        }

        [Test()]
        public void TestLookCommand()
        {
            Assert.AreEqual("a sword", CommandProcessor.ProcessCommand(player, "look at sword"));
        }

        [Test()]
        public void TestTakeCommand()
        {
            Assert.AreEqual("There is no sword found in room, try specifying the container by take <item> from <container>", CommandProcessor.ProcessCommand(player, "take sword"));
        }

        [Test()]
        public void TestPutCommand()
        {
            Assert.AreEqual("You have put the sword in the room", CommandProcessor.ProcessCommand(player, "put sword in room"));
        }

        [Test()]
        public void TestInventoryCommand()
        {
            Assert.AreEqual("You are John the mighty programmer.\nYou are carrying\n\tsword (sword)", CommandProcessor.ProcessCommand(player, "inventory"));
        }
    }
}

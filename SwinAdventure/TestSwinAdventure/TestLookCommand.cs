using NUnit.Framework;
using SwinAdventure;

namespace TestSwinAdventure
{
    [TestFixture()]
    public class TestLookCommand
    {
        private Player player;
        private string playerName = "John", playerDesc = "A player";
        private Item gem;
        private string gemName = "gem", gemDesc = "A gem";
        private Bag bag;
        private string bagName = "bag", bagDesc = "A bag";
        private LookCommand command;

        [SetUp()]
        public void SetUp()
        {
            //creates a new player, gem, bag, and lookCommand object
            player = new Player(playerName, playerDesc);
            gem = new Item(new string[] {"gem", "ruby"}, gemName, gemDesc);
            bag = new Bag(new string[] {"bag", "backpack"}, bagName, bagDesc);
            bag.Inventory.Put(gem);
            player.Inventory.Put(bag);
            command = new LookCommand();
        }

        [Test]
        public void TestLookAtMe()
        {
            //returns players full description when looking at inventory
            Assert.AreEqual($"You are {playerDesc}.\nYou are carrying\n\t{bagName} (bag)", command.Execute(player, new string[] { "look", "at", "inventory" }));
        }

        [Test]
        public void TestLookAtGem()
        {
            //returns the gem description when looking at a gem in the player's inventory
            player.Inventory.Put(gem);
            Assert.AreEqual(gemDesc, command.Execute(player, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void TestLookAtUnk()
        {
            //returns "I can't find the gem" when the player does not have a gem in their inventory
            Assert.AreEqual("I can't find the gem", command.Execute(player, new string[] { "look", "at", "gem" }));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            //returns the gem description when looking at a gem in the player's inventory
            player.Inventory.Put(gem);
            Assert.AreEqual(gemDesc, command.Execute(player, new string[] { "look", "at", "gem", "in", "inventory" }));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            //returns the gem description when looking at a gem in the bag
            Assert.AreEqual(gemDesc, command.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            //returns "I can't find the bag" when the player does not have a bag in their inventory
            //create a player with no bag in inventory
            Player player2 = new Player("Mary", "Another player");
            Assert.AreEqual("I can't find the bag", command.Execute(player2, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            //returns "I can't find the gem" when the player does not have a gem in the bag
            //remove gem from bag
            (player.Inventory.Fetch("bag") as Bag)?.Inventory.Take("gem");
            Assert.AreEqual("I can't find the gem", command.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }));
        }
    }
}

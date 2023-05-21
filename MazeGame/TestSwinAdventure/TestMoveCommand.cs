using NUnit.Framework;
using SwinAdventure;
using System.Collections.Generic;

namespace TestSwinAdventure
{
    [TestFixture()]
    public class TestMoveCommand
    {
        private Player player;
        private Path gardenExit;
        private Path hallwayExit;
        private Location hallway;
        private Location garden;
        private Location closet;

        [SetUp()]
        public void Setup()
        {
            closet = new Location(new string[] { "closet" }, "closet", "a dark closet", null);
            gardenExit = new Path(new string[] { "north", "n" }, "exit", "You go through the door and climb upwards", closet);
            garden = new Location(new string[] { "garden" }, "garden", "a beautiful garden", new List<Path>() { gardenExit });
            hallwayExit = new Path(new string[] { "south", "s" }, "exit", "You walk through the door slowly", garden);
            hallway = new Location(new string[] { "hallway" }, "hallway", "a long dark hallway", new List<Path>() { hallwayExit });
            player = new Player("John", "John the mighty programmer");
            player.CurrentLocation = hallway;
        }

        [Test]
        public void TestLeaveCommand()
        {
            MoveCommand command = new MoveCommand();
            string actual = command.Execute(player, new string[] { "leave", "south" });
            string expected = "";
            expected += "You head south\n";
            expected += "You walk through the door slowly\n";
            expected += "You have arrived in a garden";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestInvalidLeave()
        {
            MoveCommand command = new MoveCommand();
            string expected = "There are no paths in that direction";
            string actual = command.Execute(player, new string[] { "leave", "north" });
            Assert.AreEqual(expected, actual);
        }
    }
}

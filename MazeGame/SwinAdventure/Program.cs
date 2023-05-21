using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    class Program
    {
        static string playerName, playerDescription;
        static Location hallway, closet, garden;
        static Path hallwayExit, closetExit;
        static Item shovel, sword, ruby, gem, pc;
        static Bag bag;
        static Player player;

        static void Main(string[] args)
        {
            InitializeGame();
            while (true)
            {
                Console.Write("Command -> ");
                string command = Console.ReadLine();
                Console.WriteLine("\n" + CommandProcessor.ProcessCommand(player, command));
            }
        }

        static void InitializeGame()
        {
            //prompt player for name and description
            Console.Write("Enter Your Name: ");
            playerName = Console.ReadLine();
            Console.Write("Enter Player Description: ");
            playerDescription = Console.ReadLine();
            //Initialize items
            shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a big and rusty shovel");
            sword = new Item(new string[] { "sword", "blade" }, "a sword", "A short sword cast from bronze");
            ruby = new Item(new string[] { "ruby", "gem" }, "a ruby", "A bright red gem");
            gem = new Item(new string[] { "gem", "ruby" }, "a gem", "A small gem");
            pc = new Item(new string[] { "pc", "computer" }, "a pc", "A small computer");
            bag = new Bag(new string[] { "bag", "sack" }, "a bag", "A brown leather bag");
            //Initialize locations and paths
            garden = new Location(new string[] { "garden" }, "Garden", "There are many small shrubs and flowers growing from well tended garden beds", new List<Path>());
            closetExit = new Path(new string[] { "north", "n" }, "exits", "You travel through a small door, and then crawl a few meters before arriving from the north", garden);
            closet = new Location(new string[] { "closet" }, "Closet", "A small dark closet, with an odd smell", new List<Path> { closetExit });
            hallwayExit = new Path(new string[] { "south", "s" }, "exits", "You go through a door", closet);
            hallway = new Location(new string[] { "hallway" }, "Hallway", "This is a long well lit hallway", new List<Path> { hallwayExit });
            //Initialize player
            player = new Player(playerName, playerDescription);
            player.CurrentLocation = hallway;
            //put items in various locations
            garden.Inventory.Put(ruby);
            closet.Inventory.Put(gem);
            closet.Inventory.Put(pc);
            hallway.Inventory.Put(sword);
            player.Inventory.Put(bag);
            bag.Inventory.Put(shovel);
            Console.WriteLine("Welcome to SwinAdventure!");
        }
    }
}
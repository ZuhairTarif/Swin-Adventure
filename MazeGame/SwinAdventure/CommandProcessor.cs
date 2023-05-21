using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public static class CommandProcessor
    {
        private static List<Command> _commandList = new List<Command>() { new LookCommand(), new MoveCommand(), new PutCommand(), new TakeCommand(), new InventoryCommand(), new QuitCommand() };

        public static string ProcessCommand(Player p, string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return "Please enter a command";
            }
            string[] commandArray = command.Split(' ');
            foreach (Command c in _commandList)
            {
                if (c.AreYou(commandArray[0]))
                {
                    return c.Execute(p, commandArray);
                }
            }
            return "I don't understand " + command;
        }
    }
}

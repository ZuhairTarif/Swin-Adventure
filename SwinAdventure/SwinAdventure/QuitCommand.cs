using System;

namespace SwinAdventure
{
    public class QuitCommand : Command
    {
        public QuitCommand() : base(new string[] { "quit"})
        {
        }

        public override string Execute(Player p, string[] text)
        {
            Console.WriteLine("Bye! ");
            Environment.Exit(0);
            return "";
        }
    }
}
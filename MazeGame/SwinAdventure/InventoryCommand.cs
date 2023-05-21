namespace SwinAdventure
{
    public class InventoryCommand : Command
    {
        public InventoryCommand() : base(new string[] { "inventory", "inv" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            return p.FullDescription;
        }
    }
}
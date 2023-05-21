namespace SwinAdventure
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] { "put", "drop" })
        {
        }
        
        public override string Execute(Player p, string[] text)
        {
            if (!AreYou(text[0]))
            {
                return "I don't know how to " + text[0];
            }
            if (text.Length != 2 && text.Length != 4)
            {
                return "I don't know how to " + text[0] + " that";
            }
            if (text.Length == 2)
            {
                //if container is not specified, put item from inventory to room
                if (p.Inventory.HasItem(text[1]))
                {
                    p.CurrentLocation.Inventory.Put(p.Inventory.Take(text[1]));
                    return "You have put the " + text[1] + " in the " + p.CurrentLocation.Name;
                }
                else
                    return "You don't have a " + text[1];
            }
            else if (text[2] != "in")
            {
                return "Invalid " + text[0] + " command, please try " + text[0] + " <item> in <container>";
            }
            if (text.Length == 4)
            {
                //if container is specified, put item from inventory to container
                if (!p.Inventory.HasItem(text[1]))
                {
                    return "There is no " + text[1] + " in your inventory";
                }
                GameObject container = p.Locate(text[3]);
                if (container == null)
                    return "There is no " + text[3] + " to put in";
                if (container is IHaveInventory)
                {
                    if (container is Location)
                    {
                        (container as Location).Inventory.Put(p.Inventory.Take(text[1]));
                    }
                    if (container is Bag)
                    {
                        (container as Bag).Inventory.Put(p.Inventory.Take(text[1]));
                    }
                    if (container is Player)
                    {
                        (container as Player).Inventory.Put(p.Inventory.Take(text[1]));
                    }
                    return "You have put the " + text[1] + " in the " + text[3];
                }
                else
                    return "You cannot put that into " + text[3];
            }
            return "Invalid take command";
        }
    }
}

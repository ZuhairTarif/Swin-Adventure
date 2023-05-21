namespace SwinAdventure
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base(new string[] { "pickup", "take" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (!AreYou(text[0]))
            {
                return "I don't know how to " + text[0];
            }
            if(text.Length != 2 && text.Length != 4)
            {
                return "I don't know how to " + text[0] + " that";
            }
            if(text.Length == 2)
            {
                //pickup x
                //tells player to locate the item
                //check if x is item type, only item type can be picked up
                if (p.Locate(text[1]) == null)
                {
                    return text[1] + " is not here";
                }
                if (p.Locate(text[1]) is Item)
                {
                    //try to take from location
                    if (p.CurrentLocation.Inventory.HasItem(text[1]))
                    {
                        Item item = p.CurrentLocation.Inventory.Take(text[1]);
                        p.Inventory.Put(item);
                        return "You have taken the " + text[1] + " from the " + p.CurrentLocation.Name;
                    }
                    return "There is no " + text[1] + " found in " + p.CurrentLocation.Name + ", try specifying the container by " + text[0] + " <item> from <container>";
                }
                else
                {
                    return "That cannot be picked up";
                }
            }
            else if (text[2] != "from")
            {
                return "Invalid " + text[0] + " command, please try " + text[0] + " <item> from <container>";
            }
            if(text.Length == 4)
            {
                GameObject foundItem;
                //pickup x from container
                GameObject container = p.Locate(text[3]);
                if(container == null)
                    return "There is no " + text[3] + " to take from";
                //check if container is IHaveInventory (a container type)
                if (container is IHaveInventory)
                {
                    foundItem = (container as IHaveInventory).Locate(text[1]);
                    if (foundItem == null)
                        return "There is no " + text[1] + " in the " + text[3];
                    if (foundItem is Item)
                    {
                        if(container is Location)
                        {
                            foundItem = (container as Location).Inventory.Take(text[1]);
                        }
                        if(container is Bag)
                        {
                            foundItem = (container as Bag).Inventory.Take(text[1]);
                        }
                        if (container is Player)
                        {
                            foundItem = (container as Player).Inventory.Take(text[1]);
                        }
                        p.Inventory.Put(foundItem as Item);
                        return "You have taken the " + text[1] + " from the " + text[3];
                    }
                    else
                        return "That cannot be picked up";
                }
            }
            return "Invalid take command";
        }
    }
}

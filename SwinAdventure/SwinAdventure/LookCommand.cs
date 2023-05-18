namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] {"look"})
        {
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory container;
            if(!AreYou(text[0]))
            {
                return "I don't know how to " + text[0];
            }
            if(text.Length != 3 && text.Length != 5 && text.Length != 1)
            {
                return "I don't know how to look at that";
            }
            if(text[0] != "look")
            {
                return "Error in look input";
            }
            if(text.Length > 1)
            {
                if(text[1] != "at")
                    return "What do you want to look at?";
            }
            if(text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in?";
            }
            //if text only contains ["look"], look at the location
            if(text.Length == 1)
            {
                return p.CurrentLocation.FullDescription;
            }
            //if there are 3 elements, the container is the player
            else if(text.Length == 3)
            {
                //set player as the container
                container = p;
            }
            //if there are 5 elements, the containerId is the 5th element
            else
            {
                container = FetchContainer(p, text[4]);
                //if there is no container found in inventory, return error message
                if (container == null)
                    return $"I can't find the {text[4]}";
            }
            return LookAtIn(text[2], container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            //get container from player's inventory
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            //look for item in the container
            GameObject itemFound = container.Locate(thingId);
            if (itemFound != null)
                return itemFound.FullDescription;
            //return error message if item cannot be found in inventory
            return $"I can't find the {thingId}";
        }
    }
}
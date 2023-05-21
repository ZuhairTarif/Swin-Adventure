namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if(!AreYou(text[0]))
            {
                return "I don't know how to " + text[0];
            }
            if(text.Length != 2)
            {
                return "I don't know how to move in that direction";
            }
            string direction = text[1];
            //foreach path in the current location, check if the path is the one the player wants to move to
            foreach(Path path in p.CurrentLocation.Paths)
            {
                if(path.AreYou(direction))
                {
                    return path.Move(p);
                }
            }
            //if cannot find path
            return "There are no paths in that direction";
        }
    }
}
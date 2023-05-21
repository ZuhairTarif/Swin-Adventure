namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _destination;

        public Path(string[] ids, string name, string desc, Location destination) : base(ids, name, desc)
        {
            _destination = destination;
        }

        public string Move(Player p)
        {
            p.CurrentLocation = _destination;
            string output = "";
            output += "You head " + FirstId + "\n";
            output += FullDescription + "\n";
            output += "You have arrived in a " + _destination.FirstId;
            return output;
        }
    }
}

using System.Collections.Generic;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;

        private List<Path> _paths;

        public Location(string[] idents, string name, string description, List<Path> paths) : base(idents, name, description)
        {
            _inventory = new Inventory();
            _paths = paths ?? new List<Path>();
        }

        #region properties
        public Inventory Inventory
        {
            get { return _inventory; }
        }
        public override string FullDescription
        {
            get
            {
                string output = "";
                output += "You are in a " + Name + ".\n" + base.FullDescription + "\n";
                if(_paths.Count > 0)
                {
                    foreach (Path p in _paths)
                    {
                        output += "There are " + p.Name + " to the " + p.FirstId + "\n";
                    }
                }
                if (_inventory.ItemList.Length > 0)
                {
                    output += "In this room you can see:";
                    output += _inventory.ItemList;
                }
                return output;
            }
        }
        public List<Path> Paths
        {
            get { return _paths; }
        }

        #endregion

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id);
            }
        }

        public Path GetPath(string id)
        {
            foreach (Path p in _paths)
            {
                if (p.AreYou(id))
                {
                    return p;
                }
            }
            return null;
        }
    }
}

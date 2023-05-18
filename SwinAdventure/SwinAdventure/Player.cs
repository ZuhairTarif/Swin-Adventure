using System.Collections.Generic;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _currentLocation;

        public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc)
        { 
            _inventory = new Inventory();
        }

        #region property
        public override string FullDescription
        { 
            get
            {
                return $"You are {base.FullDescription}.\n" +
                    $"You are carrying" +
                    _inventory.ItemList;
            } 
        }

        public Inventory Inventory
        { get { return _inventory; } }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { _currentLocation = value; }
        }
        #endregion

        public GameObject Locate(string id)
        {
            //return the player object if the id matches with the identifier for the player object
            if(AreYou(id))
            {
                return this;
            }
            //fetch item from inventory
            Item foundItem = _inventory.Fetch(id);
            //return item in invetory if it can be found
            if(foundItem != null)
            {
                return foundItem;
            }
            else
            {
                //return null if player does not exist in a location
                if (_currentLocation == null) return null;
                //if item cannot be found in inventory(foundItem == null), find it in the current location
                return _currentLocation.Locate(id);
            }
        }
    }
}

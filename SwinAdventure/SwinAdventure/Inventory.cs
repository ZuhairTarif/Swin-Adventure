using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        { 
            _items = new List<Item>();
        }

        #region property
        public string ItemList
        { 
            get 
            {
                string result = "";
                foreach(Item item in _items)
                {
                    result += $"\n\t{item.ShortDescription}";
                }
                return result;
            } 
        }
        #endregion

        public bool HasItem(string id)
        {
            foreach(Item item in _items)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }    
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            //retrieve the first item with the id
            foreach(Item item in _items)
            {
                if (item.AreYou(id))
                { 
                    _items.Remove(item);
                    return item;
                }
            }
            //return null if no item is found with the id
            return null;
        }

        public Item Fetch(string id)
        {
            //same as Take() but it does not remove the item.
            foreach(Item item in _items)
            {
                if(item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }

    }
}

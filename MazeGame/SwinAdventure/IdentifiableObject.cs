using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            //loops through the idents array and add each of the string into _identifiers
            foreach(string identifier in idents)
            {
                _identifiers.Add(identifier.ToLower());
            }
        }

        #region properties
        public string FirstId 
        {
            get
            {
                //if there are no items in _identifiers, return an empty string
                if(_identifiers.Count == 0)
                {
                    return "";
                }
                else
                {
                    return _identifiers.First();
                }
            }
        }
        #endregion

        public bool AreYou(string id)
        {
            foreach (string identifier in _identifiers)
            {
                if (identifier == id.ToLower())
                    return true;
            }
            //if the loop is over and nothing matches, return false
            return false;
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}

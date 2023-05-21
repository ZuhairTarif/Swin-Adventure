namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _description, _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _description = desc;
            _name = name;
        }

        #region properties
        public string Name
        { get { return _name; } }

        public string ShortDescription
        { get { return $"{_name} ({FirstId})"; } }

        public virtual string FullDescription
        { get { return _description; } }
        #endregion
    }
}

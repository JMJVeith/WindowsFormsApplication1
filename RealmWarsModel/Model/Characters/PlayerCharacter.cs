namespace RealmWarsModel
{
    public class PlayerCharacter : ICharacter
    {
        public string name { get; set; }
        public Attributes attributes { get; }

        public PlayerCharacter(string name)
        {
            this.name = name;
            this.attributes = new Attributes(8, 14);
        }
    }
}
namespace Server.GameLogic
{
    public class Player
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public Deck Deck { get; set; }

        public Hand Hand { get; set; }

        public Board Field { get; set; }
    }
}

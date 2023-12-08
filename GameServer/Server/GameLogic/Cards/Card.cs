using SharedLibrary.General;

namespace Server.GameLogic.Cards
{
    public abstract class Card
    {
        public string Name { get; }

        public string Description { get; }

        public int Cost { get; }

        public Rarity Rarity { get; }
        public Unique Unique { get; }
    }
}

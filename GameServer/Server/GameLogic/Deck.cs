using Server.GameLogic.Cards;
using System;

namespace Server.GameLogic
{
    public class Deck
    {
        private List<Card> _deck;
        private Random random;

        public Deck(Card[] cards) 
        { 
            random = new ();
            _deck = new(cards);

            Shuffle();
        }

        public int Count => _deck.Count;

        public void Shuffle()
        {
            if (_deck.Count < 2) return;

            for (int i = 0; i < _deck.Count; i++)
            {
                int k = random.Next(0, _deck.Count);
                (_deck[i], _deck[k]) = (_deck[k], _deck[i]);
            }
        }

        public void AddOnTop(Card cardData)
        {
            _deck.Insert(0, cardData);
        }

        public void AddInRandom(Card cardData)
        {
            _deck.Insert(random.Next(0, _deck.Count + 1), cardData);
        }

        public Card? DrawCard()
        {
            if (_deck.Count <= 0)
                return null;

            Card cardData = _deck[0];
            
            _deck.RemoveAt(0);
            return cardData;
        }
    }
}

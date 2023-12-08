using Server.GameLogic.Cards;
using System.Collections;

namespace Server.GameLogic
{
    public class Hand
    {
        private List<Card> _hand = new(10);

        private int _maxCards = 10;

        public IEnumerator Cards => _hand.GetEnumerator();

        public int MaxCards => _maxCards;

        public int Count => _hand.Count;

        public bool IsEmpty => _hand.Count == 0;

        public bool IsFull => _hand.Count >= _maxCards;

        public bool TryAddCard(Card? card)
        {
            if (card == null) return false;

            if (_hand.Count >= _maxCards) return false;

            _hand.Add(card);

            //Отправка клиенту ответа

            return true;
        }
    }
}

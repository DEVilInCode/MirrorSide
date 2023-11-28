using Server.Game.Cards;
using System.Diagnostics;

namespace Server.Game
{
    public class GameSession
    {
        private const int MAX_MINIONS = 7;
        
        private Player Player1 { get; set; }
        private List<Card> player1Field = new(MAX_MINIONS);

        private Player Player2 { get; set; }
        private List<Card> player2Field = new(MAX_MINIONS);


        private Random random;
        bool firstPlayerTurn;

        public GameSession(Player player1, Player player2)
        {
            //Send request to start game
            Player1 = player1;
            Player2 = player2;

            random = new();
            firstPlayerTurn = random.Next(2) == 0;
        }

        public void Start()
        {
            Debug.WriteLine($"Player1 {Player1.Name} vs Player2 {Player2.Name}");
            Debug.WriteLine($"First turn is: {(firstPlayerTurn == true ? Player1.Name : Player2.Name)}");

            for (int i = 0; i < 4; i++)
            {
                Player1.Hand.TryAddCard(Player1.Deck.DrawCard()); //if false - fatigue or destroy card
                Player2.Hand.TryAddCard(Player2.Deck.DrawCard());
            }

            while (true)
            {
                //Waiting player

                //Change turn

                //Match end
                break;
            }
        }
    }
}

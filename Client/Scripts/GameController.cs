using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Min(0)]
    public int StartCards = 4;

    public Deck _playerDeck;
    private Deck _enemyDeck;

    public Hand _playerHand;
    private Hand _enemyHand;

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        _playerDeck.Shuffle();
       // _enemyDeck.Shuffle();

        for (int i = 0; i < StartCards; i++)
        {
            _playerHand.TryAddCard(_playerDeck.DrawCard());
            //_enemyHand.TryAddCard(_enemyDeck.DrawCard());
        }
    }
}

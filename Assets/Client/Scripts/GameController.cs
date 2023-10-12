using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Min(0)]
    public int StartCards = 4;

    public Player player;
    public Player enemy;

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        player.Deck.Shuffle();
        enemy.Deck.Shuffle();

        for (int i = 0; i < StartCards; i++)
        {
            player.Hand.TryAddCard(player.Deck.DrawCard());
            enemy.Hand.TryAddCard(enemy.Deck.DrawCard());
        }
    }
}

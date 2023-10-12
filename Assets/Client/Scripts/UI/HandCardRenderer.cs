using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Realization classs
public class HandCardRenderer : MonoBehaviour
{
    //public static readonly GameObject MinionCardPrefab = AssetBundle.LoadAsset(;

    private readonly List<GameObject> _cardObjects = new(10);
    
    public Hand Hand;

    public void Awake()
    {
        Hand.CardAdded += OnCardAdded;
    }

    private void OnCardAdded()
    {
        
    }

    void UpdateHand()
    {

    }
}

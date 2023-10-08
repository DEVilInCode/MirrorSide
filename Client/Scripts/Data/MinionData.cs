using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Minion")]
public class MinionData : CardData {
    [Min(0)]
    public int Health;
    [Min(0)]
    public int Damage;
}

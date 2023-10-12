using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCard : BasicCard
{
    public int Damage { get; }
    public int Health { get; }

    public MinionCard(MinionData minionData) : base(minionData)
    {
        Damage = minionData.Damage;
        Health = minionData.Health;
    }
}
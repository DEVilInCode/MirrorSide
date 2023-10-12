using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana
{
    public const int MaxSlots = 10;

    public int Spent;
    public int Permanent;
    public int Temporary;
    
    public int Unlocked
    {
        get
        {
            return Mathf.Min(Permanent + Temporary, MaxSlots);
        }
    }

    public int Available
    {
        get
        {
            return Mathf.Min(Permanent + Temporary - Spent, MaxSlots);
        }
    }
}

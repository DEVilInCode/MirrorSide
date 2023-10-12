using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombatant
{
    int Damage { get; set; }
    int RemainingAttacks { get; set; }
    int AllowedAttacks { get; set; }
}

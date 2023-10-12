using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestructable
{
   int HitPoints { get; set; }
   int MaxHitPoints { get; set; }
}

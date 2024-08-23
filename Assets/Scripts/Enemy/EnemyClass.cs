using System;
using UnityEngine;

// An enumeration to represent the different enemy types. Utilizing Flags system to enable masking for future proofing
// Skeptical on modelling Enemy Classes this way, as theoretically different class types should have different behaviours
[Flags]
public enum EnemyClass 
{
    Grunts = 1,
    Archers = 2,
    Assassins = 4
}
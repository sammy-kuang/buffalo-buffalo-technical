using System;
using UnityEngine;
using UnityEngine.Events;

// Fulfill the Process() of a ConditionalModifier if the current time in validDayCycles
public class DayCycleModifierInt : ConditionalModifier<int>
{

    public TimeCycle validDayCycles;
    public int constantChange;

    // If you want a range instead of a constant change, tick the box below
    public bool useRange;
    public int minRange; // Inclusive
    public int maxRange; // Inclusive

    public override bool Condition()
    {
        return (GameController.GetGameController().GetTimeOfDay() & validDayCycles) != 0;
    }

    public override int GetValue()
    {
        return useRange ? UnityEngine.Random.Range(minRange, maxRange+1) : constantChange;
    }
}
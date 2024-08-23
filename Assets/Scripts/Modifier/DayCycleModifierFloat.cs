using System;
using UnityEngine;
using UnityEngine.Events;

// Fulfill the Process() of a ConditionalModifier if the current time in validDayCycles
public class DayCycleModifierFloat : ConditionalModifier<float>
{

    public TimeCycle validDayCycles;
    public float constantChange;

    // If you want a range instead of a constant change, tick the box below
    public bool useRange;
    public float minRange;
    public float maxRange;

    public override bool Condition()
    {
        return (GameController.GetGameController().GetTimeOfDay() & validDayCycles) != 0;
    }

    public override float GetValue()
    {
        return useRange ? UnityEngine.Random.Range(minRange, maxRange) : constantChange;
    }
}
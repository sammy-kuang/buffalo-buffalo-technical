using System;
using UnityEngine;
using UnityEngine.Events;


// Abstract class to invoke given Unity events (through calling Process()) in the case that an abstract condition is met.
// Process() can be called to run the Unity events if Condition() is met
// This class will invoke the Unity event with one value of type T
public abstract class ConditionalModifier<T> : MonoBehaviour
{
    public ProcessTime processTime;
    public UnityEvent<T> onConditionMet;

    void Start()
    {
        if (processTime == 0) {
            Debug.LogWarning("ConditionalModifier assigned to " + gameObject.name + ", but doesn't have a process time!");
        }

        if ((processTime & ProcessTime.Start) != 0)
        {
            Process();
        }
    }

    public void Process()
    {
        if (Condition())
        {
            onConditionMet.Invoke(GetValue());
            Debug.Log("Condition met on: " + gameObject.name, gameObject);
        }
    }

    public abstract bool Condition();
    public abstract T GetValue();
}

// Represents when to call Process() on the ConditionalModifier
[Flags]
public enum ProcessTime
{
    Start = 1,
    Update = 2,
}
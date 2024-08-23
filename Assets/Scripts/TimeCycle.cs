using System;

// Not necessarily a fan of allowing the user to select multiple time of days, but it is useful to enable to flagging
// system for our conditional modifiers (ie. call an abstract event)
[Flags]
public enum TimeCycle
{
    Morning = 1,
    Afternoon = 2,
    Night = 4
}

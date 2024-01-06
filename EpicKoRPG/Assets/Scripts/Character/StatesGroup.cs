using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum StateType
{
    Life,
    Mana,
    Damage,
    Armore, 
    Speed,
    AtackRange
}


[Serializable]
public sealed class State
{
    public StateType Type;
    public AtomicVariable<float> Value;
}

public sealed class StateValuePool
{
    public AtomicVariable<float> MaxValue;
    public AtomicVariable<float> CurentValue;

    StateValuePool(State state)
    {
        MaxValue = state.Value;
        CurentValue = new();
        CurentValue.Value = MaxValue.Value;
    }
}

[Serializable]
public sealed class StatesGroup
{
    public List<State> Values;

    public AtomicVariable<float> GetValue(StateType type)
    {
        var data =  Values.Where(x => x.Type == type).FirstOrDefault();
        return data?.Value;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum AttributeTypes
{
    Strength,
    Agility,
    Intelligence,
    Luck
}

[Serializable]
public class Attribute
{
    public AttributeTypes Type;
    public AtomicVariable<int> Value;
}

[Serializable]
public class AttributeGroup
{
    public List<Attribute> Values;
    public AtomicVariable<int> GetValue(AttributeTypes type)
    {
        var data = Values.Where(x => x.Type == type).FirstOrDefault();
        return data.Value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Characters/Character", order = 0, fileName = "Character Data")]
public class CharacterData : ScriptableObject
{ 
    public AttributeGroup Attributes;

    public StatesGroup BasicStates;

}

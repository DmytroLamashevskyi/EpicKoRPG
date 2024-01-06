using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] 
    private float interactDistance;

    // Start is called before the first frame update
    public void Interact()
    {
        Debug.Log($"Interactable Object {gameObject.name} is Interacted");
    } 

    public float GetInteractDistance() => interactDistance;
}

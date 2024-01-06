using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackInput : MonoBehaviour
{
    InteractInput interactInput;

    private void Awake()
    {
        interactInput = GetComponent<InteractInput>();
    }

}

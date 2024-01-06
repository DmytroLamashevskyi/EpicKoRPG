using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractInput : MonoBehaviour
{ 
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    [HideInInspector]
    public InteractableObject interactableObject;


    // Update is called once per frame
    void Update()
    {
        CheckInteration();

        if(Input.GetMouseButtonDown(1))
        {
            interactableObject?.Interact();
        }
    }

    private void CheckInteration()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, float.MaxValue))
        {
            var interactObj = hit.transform.GetComponent<InteractableObject>();
            if(interactObj != null)
            {
                Debug.DrawLine(ray.origin, hit.point, Color.blue, 0.5f);
                interactableObject =  interactObj;
                textOnScreen.text = interactObj.name;
            }
            else
            {
                interactableObject = null;
                textOnScreen.text =  string.Empty;
            }
        }
    }
     
}

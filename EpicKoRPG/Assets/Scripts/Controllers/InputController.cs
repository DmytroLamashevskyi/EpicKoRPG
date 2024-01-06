using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Controllers
{
    public class InputController : MonoBehaviour
    {
        [SerializeField]
        private Character character;

        private InteractController interactController;
        private void Awake()
        {
            interactController = character.GetComponent<InteractController>();
        }


        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit, float.MaxValue))
                {
                    if(hit.transform.GetComponent<InteractableObject>() != null)
                    {
                        Debug.DrawLine(ray.origin, hit.point, Color.green, 0.5f); 
                        interactController.Interact(hit.transform.GetComponent<InteractableObject>());

                    }
                    if(hit.transform.GetComponent<Character>() != null)
                    {
                        Debug.DrawLine(ray.origin, hit.point, Color.red, 0.5f);
                        var oponent = hit.transform.GetComponent<Character>();
                        if(oponent.tag.Equals("enemy"))
                        {
                            character.Atack(oponent);
                        }

                    }
                    else
                    {
                        Debug.DrawLine(ray.origin, hit.point, Color.blue, 0.5f);
                        character.Move(hit.point);
                    }

                }
            }
        }
    }
}

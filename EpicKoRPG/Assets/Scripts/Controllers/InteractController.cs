using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text; 

namespace Controllers
{
    [RequireComponent(typeof(Character))]
    public class InteractController : MonoBehaviour
    {
        private Character character;

        private void Awake()
        {
            character = GetComponent<Character>();
        }


        private InteractableObject interactableObject;
        public void Interact(InteractableObject target)
        {
            var distance = Vector3.Distance(character.transform.position, target.transform.position);
            Debug.Log($"Distance To Interact Object: {distance}");
            if(distance <= target.GetInteractDistance())
            {
                target.Interact();
                character.Stop();
            }
            else
            {
                character.Move(target.transform.position);
                interactableObject = target;
            }
        }

        private void Update()
        {
            if(interactableObject != null)
            {
                var distance = Vector3.Distance(character.transform.position, interactableObject.transform.position);
                Debug.Log($"Distance To Interact Object: {distance}");
                if(distance <= interactableObject.GetInteractDistance())
                {
                    interactableObject.Interact();
                    character.Stop();
                    interactableObject = null;
                }
            }
        }

    }

}

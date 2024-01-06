using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CombatController : MonoBehaviour
    {
        private Character character;

        private void Awake()
        {
            character = GetComponent<Character>();
        }


        private Character atackObject;
        public void Atack(Character target)
        {
            var distance = Vector3.Distance(character.transform.position, target.transform.position);
            Debug.Log($"Distance To Interact Object: {distance}");
            if(distance > character.atackRange)
            {
                character.Move(target.transform.position);
                atackObject = target;
            }
            else
            {
                character.MakeDamage(atackObject);
                atackObject = null;
            }
        }

        private void Update()
        {
            if(atackObject != null)
            {
                Atack(atackObject);
            }
        }

    }
}
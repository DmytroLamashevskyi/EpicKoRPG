using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    public class AtackMechanic
    {
        //Зависимости на данные:
        private readonly AtomicEvent<Character> makeDamageEvent;
        private readonly AtomicVariable<float> Damage;

        public AtackMechanic(
            AtomicEvent<Character> makeDamageEvent,
            AtomicVariable<float> damage
        )
        {
            this.makeDamageEvent = makeDamageEvent;
            this.Damage = damage;
        }

    //Аналогичен MonoBehaviour.OnEnable
    public void OnEnable()
        {
            this.makeDamageEvent.Subscribe(this.OnMakeDamage);
        }

        //Аналогичен MonoBehaviour.OnDisable
        public void OnDisable()
        {
            this.makeDamageEvent.Unsubscribe(this.OnMakeDamage);
        }

        //Логика:
        private void OnMakeDamage(Character target)
        {
            target.TakeDamage(Damage.Value); 
        }
    }
}

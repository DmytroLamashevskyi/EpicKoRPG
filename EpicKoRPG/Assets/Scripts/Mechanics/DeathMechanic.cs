using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechanics
{
    public class DeathMechanic 
    {
        //Зависимости на данные:
        private readonly AtomicEvent<bool> OnDeathEvent;
        private readonly AtomicVariable<bool> isDead;

        public DeathMechanic(
            AtomicEvent<bool> OnDeathEvent,
            AtomicVariable<bool> isDead
        )
        {
            this.OnDeathEvent = OnDeathEvent;
            this.isDead = isDead;
        }

        //Аналогичен MonoBehaviour.OnEnable
        public void OnEnable()
        {
            this.OnDeathEvent.Subscribe(this.OnDeath);
        }

        //Аналогичен MonoBehaviour.OnDisable
        public void OnDisable()
        {
            this.OnDeathEvent.Unsubscribe(this.OnDeath);
        }

        //Логика:
        private void OnDeath(bool isDead=true)
        {
            this.isDead.Value = isDead;
        }
    }

}
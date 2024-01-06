
namespace Mechanics
{
    public sealed class TakeDamageMechanic
    {
        //Зависимости на данные:
        private readonly AtomicEvent<float> takeDamageEvent;
        private readonly AtomicVariable<float> hitPoints;

        public TakeDamageMechanic(
            AtomicEvent<float> takeDamageEvent,
            AtomicVariable<float> hitPoints
        )
        {
            this.takeDamageEvent = takeDamageEvent;
            this.hitPoints = hitPoints;
        }

        //Аналогичен MonoBehaviour.OnEnable
        public void OnEnable()
        {
            this.takeDamageEvent.Subscribe(this.OnTakeDamage);
        }

        //Аналогичен MonoBehaviour.OnDisable
        public void OnDisable()
        {
            this.takeDamageEvent.Unsubscribe(this.OnTakeDamage);
        }

        //Логика:
        private void OnTakeDamage(float damage)
        {
            this.hitPoints.Value -= damage;
        }
    }
}
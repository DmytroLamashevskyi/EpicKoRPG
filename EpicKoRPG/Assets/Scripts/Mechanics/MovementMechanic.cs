using UnityEngine;
using UnityEngine.AI;

namespace Mechanics
{
    public sealed class MovementMechanic
    {  
        private readonly NavMeshAgent agent;

        public MovementMechanic(
            AtomicVariable<float> moveSpeed, 
            NavMeshAgent agent
        )
        {  
            this.agent = agent;
            this.agent.speed = moveSpeed.Value;
        }

        public void SetDestination(Vector3 destination)
        {
            agent.isStopped = false;
            agent.SetDestination(destination);
        }

        public void Stope()
        {
            agent.isStopped = true;
            agent.ResetPath();  
        } 


    }
}
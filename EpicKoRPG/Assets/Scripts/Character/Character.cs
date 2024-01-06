using Controllers;
using Mechanics;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] 
public sealed class Character : MonoBehaviour
{
    //Data:
    public AtomicEvent<float> takeDamageEvent;
    public AtomicEvent<Character> makeDamageEvent;

    [SerializeField] AttributeGroup Attributes;
    [SerializeField] StatesGroup States;
      

    public AtomicVariable<int> Level;  

    //Logic:
    private TakeDamageMechanic takeDamageMechanic;
    private MovementMechanic movementMechanic;  
    private AtackMechanic atackMechanic;

    private NavMeshAgent agent;
    private CharacterAnimatorController animator;
    private CombatController combatController;

    public float atackRange { get => States.GetValue(StateType.AtackRange).Value; }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<CharacterAnimatorController>();
        combatController = GetComponent<CombatController>();

        this.takeDamageMechanic = new TakeDamageMechanic( this.takeDamageEvent, this.States.GetValue(StateType.Life)); 
        this.movementMechanic = new MovementMechanic(this.States.GetValue(StateType.Speed), agent ); 
        this.atackMechanic = new AtackMechanic( this.makeDamageEvent, this.States.GetValue(StateType.Damage) ); 

    }

#region Movement Mechanics
    public void Move(Vector3 destination)
    {
        this.movementMechanic.SetDestination( destination );
    }
    public void Stop()
    {
        this.movementMechanic.Stope();
    }
    #endregion


    #region Fight Mechanics 
    public void Atack(Character target)
    {
        combatController.Atack(target);
    }
     
    public void MakeDamage(Character target)
    {
        //Calcualte Damage 
        animator.Atack();
        makeDamageEvent.Invoke(target);
    } 

    public void TakeDamage(float damage)
    {
        //Calcualte Taken Damage  
        takeDamageEvent.Invoke( damage );
    }
#endregion

    private void OnEnable()
    {
        this.takeDamageMechanic.OnEnable();
        this.atackMechanic.OnEnable();
    }

    private void OnDisable()
    {
        this.takeDamageMechanic.OnDisable();
        this.atackMechanic.OnDisable();
    }
}

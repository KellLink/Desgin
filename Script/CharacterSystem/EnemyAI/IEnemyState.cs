using System.Collections.Generic;
using UnityEngine;

public enum EnemyTransition
{
    NullTransition = 0,
    CanAttack,
    NoSoldierInsight
}

public enum EnemyStateId
{
    NullState = 0,
    ChaseState,
    AttackState
}

public abstract class IEnemyState
{
    protected Dictionary<EnemyTransition, EnemyStateId> _map = new Dictionary<EnemyTransition, EnemyStateId>();
    protected EnemyStateId _stateId;
    protected ICharacter _character;
    protected EnemyFSMSystem _FSM;

    public IEnemyState(EnemyFSMSystem fsm,ICharacter character)
    {
        _FSM = fsm;
        _character = character;
    }
    public EnemyStateId StateId
    {
        get { return _stateId; }
    }

    public void AddTransition(EnemyTransition transition, EnemyStateId EnemyStateId) 
    {
        if (transition==EnemyTransition.NullTransition)
        {
            Debug.Log("Null transition is valid");
            return;
        }

        if (EnemyStateId==EnemyStateId.NullState)
        {
            Debug.Log("Null state id is valid");
            return;
        }

        if (_map.ContainsKey(transition))
        {
            Debug.Log("Transition"+transition+"is contain");
        }
        
        _map.Add(transition,EnemyStateId);
    }

    public void DeleteTransition(EnemyTransition transition)
    {
        if (!_map.ContainsKey(transition))
        {
            Debug.Log("Transition"+transition+"is not contain");
            return;
        }

        _map.Remove(transition);
    }

    public EnemyStateId GetOutputState(EnemyTransition transition)
    {
        if (!_map.ContainsKey(transition))
        {
            Debug.Log("Transition"+transition+"is not contain");
            return EnemyStateId.NullState;
        }

        return _map[transition];
    }
    
    public virtual void DoBeforeEntering(){}
    public virtual void DoBeforeLeaving(){}

    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);
}
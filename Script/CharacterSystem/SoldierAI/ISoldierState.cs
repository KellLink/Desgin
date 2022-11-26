using System.Collections.Generic;
using UnityEngine;

public enum SoldierTransition
{
    NullTranstion,
    SeeEnemy,
    NoEnemyInsight,
    CanAttack
}

public enum SoldierStateId
{
    NullState,
    Idle,
    Chase,
    Attack
}

public abstract class ISoldierState
{
    protected Dictionary<SoldierTransition, SoldierStateId> _map = new Dictionary<SoldierTransition, SoldierStateId>();
    protected SoldierStateId _stateId;

    public SoldierStateId StateId
    {
        get { return _stateId; }
    }

    public void AddTransition(SoldierTransition transition, SoldierStateId soldierStateId) 
    {
        if (transition==SoldierTransition.NullTranstion)
        {
            Debug.Log("Null transition is valid");
            return;
        }

        if (soldierStateId==SoldierStateId.NullState)
        {
            Debug.Log("Null state id is valid");
            return;
        }

        if (_map.ContainsKey(transition))
        {
            Debug.Log("Transition"+transition+"is contain");
        }
        
        _map.Add(transition,soldierStateId);
    }

    public void DeleteTransition(SoldierTransition transition)
    {
        if (!_map.ContainsKey(transition))
        {
            Debug.Log("Transition"+transition+"is not contain");
            return;
        }

        _map.Remove(transition);
    }

    public SoldierStateId GetOutputState(SoldierTransition transition)
    {
        if (!_map.ContainsKey(transition))
        {
            Debug.Log("Transition"+transition+"is not contain");
            return SoldierStateId.NullState;
        }

        return _map[transition];
    }
    
    public virtual void DoBeforeEntering(){}
    public virtual void DoBeforeLeaving(){}

    public abstract void Reason();
    public abstract void Act();
}
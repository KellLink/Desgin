﻿using System.Collections.Generic;
using UnityEngine;

public enum SoldierTransition
{
    NullTranstiion,
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
    protected ICharacter _character;
    protected SoldierFSMSystem _FSM;

    public ISoldierState(SoldierFSMSystem fsm,ICharacter character)
    {
        _FSM = fsm;
        _character = character;
    }
    public SoldierStateId StateId
    {
        get { return _stateId; }
    }

    public void AddTransition(SoldierTransition transition, SoldierStateId soldierStateId) 
    {
        if (transition==SoldierTransition.NullTranstiion)
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

    public abstract void Reason(List<ICharacter> targets);
    public abstract void Act(List<ICharacter> targets);
}
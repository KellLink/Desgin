using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFSMSystem
{
    private List<ISoldierState> _states = new List<ISoldierState>();
    private ISoldierState _currentState;

    
    public ISoldierState currentState
    {
        get { return _currentState; }
    }

    public void AddState(params ISoldierState[] states)
    {
        foreach (ISoldierState state in states)
        {
            AddState(state);
        }
    }
    public void AddState(ISoldierState state)
    {
        if (state==null)
        {
            Debug.Log("state is not invalid");
            return;
        }

        if (_states.Count==0)
        {
            _states.Add(state);
            _currentState = state;
            return;     
        }
        
        foreach (ISoldierState stat in _states)
        {
            if (stat==state)
            {
                Debug.Log("state is contain");
                return;
            }
        }
        
        _states.Add(state);
    }

    public void DeleteState(SoldierStateId stateId)
    {
        if (stateId==SoldierStateId.NullState)  
        {
            Debug.Log("statId is NullState");
            return;
        }

        foreach (ISoldierState state in _states)
        {
            if (state.StateId==stateId)
            {
                _states.Remove(state);
                return;
            }
        }
        
        Debug.Log("stateId"+stateId+"is not contain");
    }

    public void PerFormTransition(SoldierTransition transition)
    {
        if (transition==SoldierTransition.NullTranstion)
        {
            Debug.Log("transition is NullTransition");
            return;
        }

        SoldierStateId nextStateId = _currentState.GetOutputState(transition);

        if (nextStateId==SoldierStateId.NullState)
        {
            Debug.Log("Transition"+transition+"is not valid state");
            return;
        }
        
        foreach (ISoldierState state in _states)
        {
            if (state.StateId==nextStateId)
            {
                _currentState.DoBeforeLeaving();
                _currentState = state;
                _currentState.DoBeforeEntering();
                return;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSMSystem 
{
    private List<IEnemyState> _states = new List<IEnemyState>();
    private IEnemyState _currentState;

    
    public IEnemyState currentState
    {
        get { return _currentState; }
    }

    public void AddState(params IEnemyState[] states)
    {
        foreach (IEnemyState state in states)
        {
            AddState(state);
        }
    }
    public void AddState(IEnemyState state)
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
            _currentState.DoBeforeEntering();
            return;     
        }
        
        foreach (IEnemyState stat in _states)
        {
            if (stat==state)
            {
                Debug.Log("state is contain");
                return;
            }
        }
        
        _states.Add(state);
    }

    public void DeleteState(EnemyStateId stateId)
    {
        if (stateId==EnemyStateId.NullState)  
        {
            Debug.Log("statId is NullState");
            return;
        }

        foreach (IEnemyState state in _states)
        {
            if (state.StateId==stateId)
            {
                _states.Remove(state);
                return;
            }
        }
        
        Debug.Log("stateId"+stateId+"is not contain");
    }

    public void PerFormTransition(EnemyTransition transition)
    {
        if (transition==EnemyTransition.NullTransition)
        {
            Debug.Log("transition is NullTransition");
            return;
        }

        EnemyStateId nextStateId = _currentState.GetOutputState(transition);

        if (nextStateId==EnemyStateId.NullState)
        {
            Debug.Log("Transition"+transition+"is not valid state");
            return;
        }
        
        foreach (IEnemyState state in _states)
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

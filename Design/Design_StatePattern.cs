using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Design_StatePattern : MonoBehaviour
{
    private void Start()
    {
        Context context = new Context();
        context.State = new StateA(context);
        context.Handle();
        context.Handle();
        context.Handle();
        context.Handle();
    }
}

class Context
{
    private IState state;

    public void Handle()
    {
        state.Handle();
    }

    public IState State
    {
        get => state;
        set => state = value;
    }
}

interface IState
{
    void Handle();
}

class StateA : IState
{
     Context context;

    public void Handle()
    {
        Debug.Log("StateA");
        context.State = new StateB(context);
    }

    public StateA(Context context)
    {
        this.context = context;
    }
}

class StateB : IState
{
    Context context;

    public void Handle()
    {
        Debug.Log("StateB");
        context.State = new StateA(context);
    }

    public StateB(Context context)
    {
        this.context = context;
    }
}
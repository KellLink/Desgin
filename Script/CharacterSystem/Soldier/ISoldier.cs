using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISoldier : ICharacter
{
    protected SoldierFSMSystem _fsmSystem;

    public ISoldier() : base()
    {
        MakeFSM();
    }

    private void MakeFSM()
    {
        _fsmSystem = new SoldierFSMSystem();

        SoldierIdleState idleState = new SoldierIdleState(_fsmSystem, this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateId.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(_fsmSystem, this);
        chaseState.AddTransition(SoldierTransition.NoEnemyInsight, SoldierStateId.Idle);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateId.Attack);

        SoldierAttackState attackState = new SoldierAttackState(_fsmSystem, this);
        attackState.AddTransition(SoldierTransition.NoEnemyInsight, SoldierStateId.Idle);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateId.Attack);

        _fsmSystem.AddState(idleState, chaseState, attackState);
    }

    public void UpdateFSM(List<ICharacter> targets)
    {
        _fsmSystem.currentState.Reason(targets);
        _fsmSystem.currentState.Act(targets);
    }

    public override void UnderAttack(int damage)
    {
        base.UnderAttack(damage);
        if (_attr.CriticaPoint < 0)
        {
            PlaySound();
            PlayEffect();
            Killed();
        }
    }

    protected abstract void PlaySound();
    protected abstract void PlayEffect();
}
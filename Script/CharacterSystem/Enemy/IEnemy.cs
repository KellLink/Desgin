using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemy : ICharacter
{
    protected EnemyFSMSystem _FSMSystem;

    public IEnemy()
    {
        MakeFSM();
    }

    public void UpdateFSM(List<ICharacter> targets)
    {
        _FSMSystem.currentState.Reason(targets);
        _FSMSystem.currentState.Act(targets);
    }

    private void MakeFSM()
    {
        _FSMSystem = new EnemyFSMSystem();

        EnemyChaseState chaseState = new EnemyChaseState(_FSMSystem, this);
        chaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateId.AttackState);

        EnemyAttackState attackState = new EnemyAttackState(_FSMSystem, this);
        attackState.AddTransition(EnemyTransition.NoSoldierInsight, EnemyStateId.ChaseState);

        _FSMSystem.AddState(chaseState, attackState);
    }

    public override void UnderAttack(int damage)
    {
        base.UnderAttack(damage);
        PlayEffect();

        if (_attr.CurrentHP < 0)
        {
            Killed();
        }
    }

    protected abstract void PlayEffect();

    
}
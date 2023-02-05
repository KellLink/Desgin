using System;
using System.Collections;
using System.Collections.Generic;
using Script.CharacterSystem.Vistor;
using UnityEngine;

public enum SoldierType
{
    Rookie,
    Sergeant,
    Captain,
    Captive
}
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
        if (_isKilled)
        {
            return;
        }
        _fsmSystem.currentState.Reason(targets);
        _fsmSystem.currentState.Act(targets);
    }

    public override void UnderAttack(int damage)
    {
        if (_isKilled)
        {
            return;
        }
        base.UnderAttack(damage);
        if (_attr.CurrentHP < 0)
        {
            PlaySound();
            PlayEffect();
            Killed();
        }
    }

    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance().NotifySubject(GameEventType.EnemyKilled);
    }

    protected abstract void PlaySound();
    protected abstract void PlayEffect();

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.visitSoldier(this);
    }
}
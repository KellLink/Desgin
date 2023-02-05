using System;
using System.Collections;
using System.Collections.Generic;
using Script.CharacterSystem.Vistor;
using UnityEngine;

public enum EnemyType
{
    Elf,
    Orge,
    Troll
}
public abstract class IEnemy : ICharacter
{
    protected EnemyFSMSystem _FSMSystem;

    public IEnemy()
    {
        MakeFSM();
    }

    public void UpdateFSM(List<ICharacter> targets)
    {
        if (_isKilled)
        {
            return;
        }
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
        if (_isKilled)
        {
            return;
        }
        base.UnderAttack(damage);
        PlayEffect();

        if (_attr.CurrentHP < 0)
        {
            Killed();
        }
    }

    public abstract void PlayEffect();

    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance().NotifySubject(GameEventType.EnemyKilled);
    }

    public override void RunVisitor(ICharacterVisitor visitor)
    {
        visitor.visitEnemy(this);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttackState : ISoldierState
{
    private float _attackCoolDownTime = 1f;
    private float _currentAttackTime = 1f;

    public override void Act(List<ICharacter> targets)
    {
        _character.PlayAnimation("Attack");
        if (targets == null || targets.Count == 0)
        {
            return;
        }

        _currentAttackTime += Time.deltaTime;

        if (_currentAttackTime>=_attackCoolDownTime)
        {
            _currentAttackTime = 0;
            _character.Attack(targets[0]);
        }
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets==null|| targets.Count==0)
        {
            _FSM.PerFormTransition(SoldierTransition.NoEnemyInsight);
            return;
        }
        
        float distance = Vector3.Distance(_character.GetPostion(), targets[0].GetPostion());

        if (distance>=_character.AttackRange)
        {
            _FSM.PerFormTransition(SoldierTransition.SeeEnemy);
        }
    }


    public SoldierAttackState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        _stateId = SoldierStateId.Attack;
    }
}
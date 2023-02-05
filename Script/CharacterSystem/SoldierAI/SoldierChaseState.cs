using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierChaseState : ISoldierState
{
    public override void Reason(List<ICharacter> targets)
    {
        _character.PlayAnimation("move");
        if (targets==null||targets.Count==0)
        {
            _FSM.PerFormTransition(SoldierTransition.NoEnemyInsight);
            return;
        }

        float distance = Vector3.Distance(_character.GetPostion(), targets[0].GetPostion());

        if (distance<=_character.AttackRange)
        {
            _FSM.PerFormTransition(SoldierTransition.CanAttack);
        }
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            _character.MoveTo(targets[0].GetPostion());
        }
    }


    public SoldierChaseState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        _stateId = SoldierStateId.Chase;
    }
}
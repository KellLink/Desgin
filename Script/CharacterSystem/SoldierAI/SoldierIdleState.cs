using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierIdleState : ISoldierState
{
    public override void Act(List<ICharacter> targets)
    {
        _character.PlayAnimation("stand");
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            _FSM.PerFormTransition(SoldierTransition.SeeEnemy);
        }
    }


    public SoldierIdleState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        _stateId = SoldierStateId.Idle;
    }
}
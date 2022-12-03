using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : IEnemyState
{
    private Vector3 _targetPosition;


    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null || targets.Count > 0)
        {
            float distance = Vector3.Distance(targets[0].GetPostion(), _character.GetPostion());
            if (distance < _character.AttackRange)
            {
                _FSM.PerFormTransition(EnemyTransition.CanAttack);
            }
        }
    }

    public override void DoBeforeEntering()
    {
        _targetPosition = GameFacade.Instance().GetEnemyTargetPosition();
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            _character.MoveTo(targets[0].GetPostion());
        }
        else
        {
            _character.MoveTo(_targetPosition);
        }
    }

    public EnemyChaseState(EnemyFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        _stateId = EnemyStateId.ChaseState;
    }
}
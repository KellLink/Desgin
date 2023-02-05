using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTroll : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffectGenic("TrollHitEffect");
    }
}

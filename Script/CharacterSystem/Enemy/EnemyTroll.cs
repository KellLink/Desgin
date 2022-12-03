using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTroll : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffectGenic("TrollHitEffect");
    }
}

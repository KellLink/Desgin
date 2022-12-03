using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrge : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffectGenic("OrgeHitEffect");
    }
}

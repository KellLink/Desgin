using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrge : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffectGenic("OgreHitEffect");
    }
}

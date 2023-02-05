using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElf : IEnemy
{
    public override void PlayEffect()
    {
        DoPlayEffectGenic("ElfHitEffect");
    }
}

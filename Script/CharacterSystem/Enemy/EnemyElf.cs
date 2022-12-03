using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElf : IEnemy
{
    protected override void PlayEffect()
    {
        DoPlayEffectGenic("ElfHitEffect");
    }
}

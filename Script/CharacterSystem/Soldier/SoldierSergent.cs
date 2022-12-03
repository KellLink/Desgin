using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSergent : ISoldier
{
    protected override void PlaySound()
    {
        DoPlaySoundGeneric("SergentDeath");
    }

    protected override void PlayEffect()
    {
        DoPlayEffectGenic("CaptainDeadEffect");
    }
}

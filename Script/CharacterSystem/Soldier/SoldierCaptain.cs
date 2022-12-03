using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCaptain : ISoldier
{
    protected override void PlaySound()
    {
        DoPlaySoundGeneric("CaptainDeath");
    }

    protected override void PlayEffect()
    {
        DoPlayEffectGenic("CaptainDeadEffect");
    }
}

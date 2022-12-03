using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierRookie : ISoldier
{
    protected override void PlaySound()
    {
        DoPlaySoundGeneric("RookieDeath");
    }

    protected override void PlayEffect()
    {
        DoPlayEffectGenic("RookieDeadEffect");
    }
}

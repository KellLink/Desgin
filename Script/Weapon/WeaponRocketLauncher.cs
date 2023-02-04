using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocketLauncher : IWeapon
{
    protected override void PlayBulletEffect(Vector3 targetPostion)
    {
        DoPlayBulletEffectGeneric(1.05f,targetPostion);
    }

    protected override void PlaySoundEffect(Vector3 targetPostion)
    {
        DoPlaySoundEffectGeneric("RocketShot",targetPostion);
    }
    
    protected override void SetEffectPlayTime()
    {
        _effectPlayTime = 0.5f;
    }

    public WeaponRocketLauncher(int attkPoint, float attkRange, GameObject gameObject) : base(attkPoint, attkRange, gameObject)
    {
    }
}

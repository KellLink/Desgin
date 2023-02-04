using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : IWeapon
{
    protected override void PlayBulletEffect(Vector3 targetPostion)
    {
        DoPlayBulletEffectGeneric(0.1f,targetPostion);
    }

    protected override void PlaySoundEffect(Vector3 targetPostion)
    {
        DoPlaySoundEffectGeneric("RifleShot",targetPostion);
    }
    
    protected override void SetEffectPlayTime()
    {
        _effectPlayTime = 0.35f;
    }

    public WeaponRifle(int attkPoint, float attkRange, GameObject gameObject) : base(attkPoint, attkRange, gameObject)
    {
    }
}

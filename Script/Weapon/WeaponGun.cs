using UnityEngine;


public class WeaponGun : IWeapon
{
    protected override void PlayBulletEffect(Vector3 targetPostion)
    {
        DoPlayBulletEffectGeneric(0.05f,targetPostion);
    }

    protected override void PlaySoundEffect(Vector3 targetPostion)
    {
        DoPlaySoundEffectGeneric("GunShot",targetPostion);
    }

    protected override void SetEffectPlayTime()
    {
        _effectPlayTime = 0.2f;
    }
}
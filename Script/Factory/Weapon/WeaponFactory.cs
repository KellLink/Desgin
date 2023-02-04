using UnityEngine;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(WeaponType type)
    {
        IWeapon weapon = null;
        GameObject weaponGameobject = null;
        switch (type)
        {
            case WeaponType.Gun:
                weaponGameobject = FactoryManager.AssetFactory.LoadWeapon("WeaponGun");
                weaponGameobject=GameObject.Instantiate(weaponGameobject);
                weapon = new WeaponGun(20, 5, weaponGameobject);
                break;
            case WeaponType.Rifle:
                weaponGameobject = FactoryManager.AssetFactory.LoadWeapon("WeaponRifle");
                weaponGameobject=GameObject.Instantiate(weaponGameobject);
                weapon = new WeaponGun(30, 8, weaponGameobject);
                break;
            case WeaponType.Rocket:
                weaponGameobject = FactoryManager.AssetFactory.LoadWeapon("WeaponRocket");
                weaponGameobject=GameObject.Instantiate(weaponGameobject);
                weapon = new WeaponGun(45, 12, weaponGameobject);
                break;
        }

        return weapon;
    }
}
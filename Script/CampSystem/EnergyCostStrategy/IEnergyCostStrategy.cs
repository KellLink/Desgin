using UnityEngine;

namespace Script.CampSystem.EnergyCostStrategy
{
    public abstract class IEnergyCostStrategy
    {
        public abstract int GetCampUpgradeEnergyCost(SoldierType soldierType, int level);
        public abstract int GetWeaponUpgradeEnergyCost(WeaponType weaponType);
        public abstract int GetSoldierTrainEnergyCost(SoldierType soldierType, int level);
    }
}
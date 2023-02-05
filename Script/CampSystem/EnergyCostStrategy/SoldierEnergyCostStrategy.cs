using System;
using UnityEngine;

namespace Script.CampSystem.EnergyCostStrategy
{
    public class SoldierEnergyCostStrategy : IEnergyCostStrategy
    {
        public override int GetCampUpgradeEnergyCost(SoldierType soldierType, int level)
        {
            int energy = 0;
            switch (soldierType)
            {
                case SoldierType.Rookie:
                    energy = 60;
                    break;
                case SoldierType.Sergeant:
                    energy = 80;
                    break;
                case SoldierType.Captain:
                    energy = -1;
                    break;
                case SoldierType.Captive:
                    return 10;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(soldierType), soldierType, null);
            }

            return energy += (level - 1) * 5;
        }

        public override int GetWeaponUpgradeEnergyCost(WeaponType weaponType)
        {
            int energy = 0;
            switch (weaponType)
            {
                case WeaponType.Gun:
                    energy = 25;
                    break;
                case WeaponType.Rifle:
                    energy = 50;
                    break;
                case WeaponType.Rocket:
                    energy = -1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, null);
            }

            return energy;
        }

        public override int GetSoldierTrainEnergyCost(SoldierType soldierType, int level)
        {
            int energy = 0;
            switch (soldierType)
            {
                case SoldierType.Rookie:
                    energy = 10;
                    break;
                case SoldierType.Sergeant:
                    energy = 20;
                    break;
                case SoldierType.Captain:
                    energy = 30;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(soldierType), soldierType, null);
            }

            return energy += (level - 1) * 5;
        }
    }
}
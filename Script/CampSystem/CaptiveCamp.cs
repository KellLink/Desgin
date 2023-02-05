using Script.CampSystem.Command;
using Script.CampSystem.EnergyCostStrategy;
using UnityEngine;

namespace Script.CampSystem
{
    public class CaptiveCamp : ICamp
    {
        private WeaponType _weaponType = WeaponType.Gun;
        private EnemyType _enemyType;

        public CaptiveCamp(GameObject gameObject, string name, string iconSpite, EnemyType enemyType,
            Vector3 rallyPosition, float trainTime) : base(gameObject, name, iconSpite, SoldierType.Captive,
            rallyPosition,
            trainTime)
        {
            _enemyType = enemyType;
            _energyCostStrategy = new SoldierEnergyCostStrategy();
            UpdateEnergyCost();
        }

        public override int Level
        {
            get { return 1; }
        }

        public override WeaponType WeaponTypeLevel
        {
            get { return _weaponType; }
        }


        public override int CampUpgradeEnergyCost
        {
            get { return -1; }
        }

        public override int WeaponUpgradeEnergyCost
        {
            get { return -1; }
        }

        public override int TrainEnergyCost
        {
            get { return _trainEnergy; }
        }

        public override void Train()
        {
            TrainCaptiveCommand command = new TrainCaptiveCommand(_enemyType, _weaponType, _rallyPosition);
            _trainCommands.Add(command);
        }

        protected override void UpdateEnergyCost()
        {
            _trainEnergy = _energyCostStrategy.GetSoldierTrainEnergyCost(SoldierType.Captive, 1);
        }

        public override void UpgradeCamp()
        {
        }

        public override void UpgradeWeapon()
        {
        }
    }
}
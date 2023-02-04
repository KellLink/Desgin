using System.Collections;
using System.Collections.Generic;
using Script.CampSystem;
using Script.CampSystem.Command;
using Script.CampSystem.EnergyCostStrategy;
using UnityEngine;

public class SoldierCamp : ICamp
{
    private const int MAX_LEVEL = 4;
    private int _level = 1;
    private WeaponType _weaponType = WeaponType.Gun;

    public SoldierCamp(GameObject gameObject, string name, string iconSpite, SoldierType soldierType,
        Vector3 rallyPosition, float trainTime, int level, WeaponType weaponType) : base(gameObject, name, iconSpite,
        soldierType, rallyPosition, trainTime)
    {
        _level = level;
        _weaponType = weaponType;
        _energyCostStrategy = new SoldierEnergyCostStrategy();
    }

    public override int Level
    {
        get { return _level; }
    }

    public override WeaponType WeaponTypeLevel
    {
        get { return _weaponType; }
    }

    public override void Train()
    {
        TrainSoldierCommand cmd = new TrainSoldierCommand(_soldierType, _weaponType, _rallyPosition, _level);
        _trainCommands.Add(cmd);
    }

    public override int CampUpgradeEnergyCost
    {
        get
        {
            if (_level + 1 > MAX_LEVEL)
            {
                return -1;
            }
            else
            {
                return _campUpgradeEnergy;
            }
        }
    }

    public override int WeaponUpgradeEnergyCost
    {
        get
        {
            if (_weaponType + 1 > WeaponType.Rocket)
            {
                return -1;
            }
            else
            {
                return _weaponUpgradeEnergy;
            }
        }
    }

    public override int TrainEnergyCost
    {
        get { return _trainEnergy; }
    }

    protected override void UpdateEnergyCost()
    {
        _campUpgradeEnergy = _energyCostStrategy.GetCampUpgradeEnergyCost(_soldierType, _level);
        _weaponUpgradeEnergy = _energyCostStrategy.GetWeaponUpgradeEnergyCost(_weaponType);
        _trainEnergy = _energyCostStrategy.GetSoldierTrainEnergyCost(_soldierType, _level);
    }

    public override void UpgradeCamp()
    {
        if (_level + 1 > MAX_LEVEL)
        {
            return;
        }

        _level++;
        UpdateEnergyCost();
    }

    public override void UpgradeWeapon()
    {
        if (_weaponType + 1 > WeaponType.Rocket)
        {
            return;
        }

        _weaponType++;
        UpdateEnergyCost();
    }
}
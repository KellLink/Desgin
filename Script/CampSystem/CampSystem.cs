using System;
using System.Collections;
using System.Collections.Generic;
using Script.Tools;
using UnityEngine;

public class CampSystem : IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> _soldierCamps = new Dictionary<SoldierType, SoldierCamp>();

    public override void Init()
    {
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);
    }

    public override void Update()
    {
        foreach (SoldierCamp camp in _soldierCamps.Values)
        {
            camp.Update();
        }
    }

    public void End()
    {
    }

    private void InitCamp(SoldierType type)
    {
        String campGameObjectName = "";
        String name = "";
        String icon = "";
        Vector3 rallyPosition = Vector3.zero;
        int level = 1;
        WeaponType weaponType = WeaponType.Gun;
        float trainTime = 0;

        switch (type)
        {
            case SoldierType.Rookie:
                campGameObjectName = "SoldierCamp_Rookie";
                name = "RookieCamp";
                icon = "RookieCamp";
                trainTime = 3f;
                break;
            case SoldierType.Sergeant:
                campGameObjectName = "SoldierCamp_Sergeant";
                name = "SergeantCamp";
                icon = "SergeantCamp";
                trainTime = 4f;
                break;
            case SoldierType.Captain:
                campGameObjectName = "SoldierCamp_Captain";
                name = "CaptainCamp";
                icon = "CaptainCamp";
                trainTime = 5f;
                break;
            default:
                Debug.LogError("cannot find soldier type");
                break;
                ;
        }

        GameObject campGameObject = GameObject.Find(campGameObjectName);
        rallyPosition = UnityToolkit.FindInChildren(campGameObject, "TrainPoint").transform.position;
        
        SoldierCamp camp
            = new SoldierCamp(campGameObject, name, icon, type, rallyPosition, trainTime, level, weaponType);
        campGameObject.AddComponent<CampOnClick>().Camp=camp;
        _soldierCamps.Add(type,camp);
    }
}
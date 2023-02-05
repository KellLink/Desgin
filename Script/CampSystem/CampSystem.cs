using System;
using System.Collections;
using System.Collections.Generic;
using Script.CampSystem;
using Script.Tools;
using UnityEngine;

public class CampSystem : IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> _soldierCamps = new Dictionary<SoldierType, SoldierCamp>();
    private Dictionary<EnemyType, CaptiveCamp> _captiveCamps = new Dictionary<EnemyType, CaptiveCamp>();

    public override void Init()
    {
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);
        //InitCamp(EnemyType.Elf);
    }

    public override void Update()
    {
        foreach (SoldierCamp camp in _soldierCamps.Values)
        {
            camp.Update();
        }

        foreach (CaptiveCamp camp in _captiveCamps.Values)
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
    private void InitCamp(EnemyType enemyType)
    {
        String campGameObjectName = "";
        String name = "";
        String icon = "";   
        Vector3 rallyPosition = Vector3.zero;
        float trainTime = 0;

        switch (enemyType)
        {
            case EnemyType.Elf:
                campGameObjectName = "CaptiveCamp";
                name = "战俘兵营";
                icon = "CaptiveCamp";
                trainTime = 3f;
                break;
            default:
                Debug.LogError("cannot find soldier type");
                break;
        }

        GameObject campGameObject = GameObject.Find(campGameObjectName);
        rallyPosition = UnityToolkit.FindInChildren(campGameObject, "TrainPoint").transform.position;
        
        CaptiveCamp camp
            = new CaptiveCamp(campGameObject,name,icon,enemyType,rallyPosition,trainTime);
        campGameObject.AddComponent<CampOnClick>().Camp=camp;
        _captiveCamps.Add(enemyType,camp);
    }
}
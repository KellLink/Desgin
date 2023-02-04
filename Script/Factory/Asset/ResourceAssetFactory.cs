using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceAssetFactory : IAssetFactory
{
    private const String SoldierPath = "Characters/Soldier/";
    private const String EnemyPath = "Characters/Enemy/";
    private const String WeaponPath = "Weapons/";
    private const String EffectPath = "Effects/";
    private const String AudioPath = "Audios/";
    private const String SpitePath = "Sprites/";

    public GameObject LoadSoldier(string name)
    {
        return InstantiateGameObject(SoldierPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return InstantiateGameObject(EnemyPath + name);
    }

    public GameObject LoadWeapon(string name)
    {
        return InstantiateGameObject(WeaponPath + name);
    }

    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(EffectPath + name);
    }

    public AudioClip LoadAudioClip(string name)
    {
        //return LoadAsset(AudioPath+name) as AudioClip;
        return Resources.Load(AudioPath+name,typeof(AudioClip)) as AudioClip;
    }

    public Sprite LoadSpite(string name)
    {
        //return LoadAsset(SpitePath+name) as Sprite;
        return Resources.Load(SpitePath+name,typeof(Sprite)) as Sprite;
    }

    private GameObject InstantiateGameObject(String path)
    {
        Object o = Resources.Load(path);
        if (o==null)
        {
            Debug.Log(path+"  is not valid");
            return null;
        }

        return o as GameObject;
    }
    
    // private Object LoadAsset(String path)
    // {
    //     Object o = Resources.Load(path);
    //
    //     if (o==null)
    //     {
    //         Debug.Log(path+"is not valid");
    //         return null;
    //     }
    //     
    //     return o;
    // }
}
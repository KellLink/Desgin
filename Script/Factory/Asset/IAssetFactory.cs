using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAssetFactory
{
    GameObject LoadSoldier(String name);
    GameObject LoadEnemy(String name);
    GameObject LoadWeapon(String name);
    GameObject LoadEffect(String name);
    AudioClip LoadAudioClip(String name);
    Sprite LoadSpite(String name);
}
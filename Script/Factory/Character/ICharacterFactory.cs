using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterFactory
{
    ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1) where T : ICharacter, new();
}
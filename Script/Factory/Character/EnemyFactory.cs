using System;
using Script.Factory.Character.Builder;
using UnityEngine;

public class EnemyFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 spawnPosition, int lv = 1)
        where T : ICharacter, new()
    {
        ICharacter character = new T();
        ICharacterBuilder builder = new EnemyBuilder(character, typeof(T), weaponType, spawnPosition, lv);
        return CharacterBuildDirector.Construct(builder);
    }
}
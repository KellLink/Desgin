using System;
using Script.CharacterSystem.BaseAttr;
using UnityEngine;

namespace Script.Factory.Character.Builder
{
    public class EnemyBuilder : ICharacterBuilder
    {
        public EnemyBuilder(ICharacter character, Type type, WeaponType weaponType, Vector3 spawnPosition, int lv) :
            base(character, type, weaponType, spawnPosition, lv)
        {
        }

        public override void AddCharacterAttr()
        {
            CharacterBaseAttr baseAttr = FactoryManager.AttrFactory.GetCharacterBaseAttr(_type);
            ICharacterAttr attr = new EnemyAttr(new SoldierAttrStrategy(), _lv, baseAttr);
            _prefabName = baseAttr.PrefabName;
            _character.Attr = attr;
        }

        public override void AddGameObject()
        {
            GameObject enemyGo = FactoryManager.AssetFactory.LoadEnemy(_prefabName);
            enemyGo=GameObject.Instantiate(enemyGo);
            enemyGo.transform.position = _spawnPosition;
            _character.CharacterGameObject = enemyGo;
        }

        public override void AddWeapon()
        {
            IWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(_weaponType);
            _character.Weapon = weapon;
        }

        public override ICharacter GetCharacter()
        {
            return _character;
        }

        public override void AddToCharacterSystem()
        {
            GameFacade.Instance().AddEnemy(_character as IEnemy);
        }
    }
}
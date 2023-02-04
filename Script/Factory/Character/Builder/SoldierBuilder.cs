using System;
using Script.CharacterSystem.BaseAttr;
using UnityEngine;

namespace Script.Factory.Character.Builder
{
    public class SoldierBuilder : ICharacterBuilder
    {
        public SoldierBuilder(ICharacter character, Type type, WeaponType weaponType, Vector3 spawnPosition, int lv) :
            base(character, type, weaponType, spawnPosition, lv)
        {
        }

        public override void AddCharacterAttr()
        {
            CharacterBaseAttr baseAttr = FactoryManager.AttrFactory.GetCharacterBaseAttr(_type);
            ICharacterAttr attr = new SoldierAttr(new SoldierAttrStrategy(), _lv, baseAttr);
            _prefabName = baseAttr.PrefabName;
            _character.Attr = attr;
        }

        public override void AddGameObject()
        {
            GameObject soldier = FactoryManager.AssetFactory.LoadSoldier(_prefabName);
            soldier=GameObject.Instantiate(soldier);
            soldier.transform.position = _spawnPosition;
            _character.CharacterGameObject = soldier;
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
            GameFacade.Instance().AddSoldier(_character as ISoldier);
        }
    }
}
using System;
using UnityEngine;

namespace Script.Factory.Character.Builder
{
    public abstract class ICharacterBuilder
    {
        protected ICharacter _character;
        protected Type _type;
        protected WeaponType _weaponType;
        protected Vector3 _spawnPosition;
        protected int _lv;
        protected String _prefabName;

        protected ICharacterBuilder(ICharacter character, Type type, WeaponType weaponType, Vector3 spawnPosition, int lv)
        {
            _character = character;
            _type = type;
            _weaponType = weaponType;
            _spawnPosition = spawnPosition;
            _lv = lv;
        }

        public abstract void AddCharacterAttr();
        public abstract void AddGameObject();
        public abstract void AddWeapon();

        public abstract ICharacter GetCharacter();

        public abstract void AddToCharacterSystem();
    }
}
using System;
using UnityEngine;

namespace Script.CharacterSystem.BaseAttr
{
    public class CharacterBaseAttr
    {
        protected String _name;
        protected float _maxHp;
        protected float _moveSpeed;
        protected String _iconSprite;
        protected String _prefabName;

        public CharacterBaseAttr(string name, float maxHp, float moveSpeed, string iconSprite, string prefabName)
        {
            _name = name;
            _maxHp = maxHp;
            _moveSpeed = moveSpeed;
            _iconSprite = iconSprite;
            _prefabName = prefabName;
        }

        public string Name => _name;

        public float MAXHp => _maxHp;

        public float MoveSpeed => _moveSpeed;

        public string IconSprite => _iconSprite;

        public string PrefabName => _prefabName;
    }
}
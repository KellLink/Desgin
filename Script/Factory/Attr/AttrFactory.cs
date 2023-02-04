using System;
using System.Collections.Generic;
using Script.CharacterSystem.BaseAttr;
using UnityEngine;

namespace Script.Factory.Attr
{
    public class AttrFactory : IAttrFactory
    {
        private Dictionary<Type, CharacterBaseAttr> _characterBaseAttrsDict;

        public AttrFactory()
        {
            InitCharacterBaseAttr();
        }

        private void InitCharacterBaseAttr()
        {
            _characterBaseAttrsDict = new Dictionary<Type, CharacterBaseAttr>();

            _characterBaseAttrsDict.Add(typeof(EnemyElf)
                , new CharacterBaseAttr("Elf", 100, 3, "ElfIcon", "Enemy1"));
            _characterBaseAttrsDict.Add(typeof(EnemyOrge)
                , new CharacterBaseAttr("Orge", 120, 4, "OrgeIcon", "Enemy2"));
            _characterBaseAttrsDict.Add(typeof(EnemyTroll)
                , new CharacterBaseAttr("Troll", 200, 1.5f, "ThrollIcon", "Enemy3"));

            _characterBaseAttrsDict.Add(typeof(SoldierRookie)
                , new CharacterBaseAttr("Rookie", 80, 3, "RookieIcon", "Soldier1"));
            _characterBaseAttrsDict.Add(typeof(SoldierSergent)
                , new CharacterBaseAttr("Sergent", 90, 3.5f, "SergentIcon", "Soldier2"));
            _characterBaseAttrsDict.Add(typeof(SoldierCaptain)
                , new CharacterBaseAttr("Captain", 100, 4, "CaptainIcon", "Soldier3"));
        }

        public override CharacterBaseAttr GetCharacterBaseAttr(Type t)
        {
            if (_characterBaseAttrsDict.ContainsKey(t))
            {
                return _characterBaseAttrsDict[t];
            }
            Debug.Log("Type is "+t+"not exist ");
            return null;
        }
    }
}
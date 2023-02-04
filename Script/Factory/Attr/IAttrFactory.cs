using System;
using Script.CharacterSystem.BaseAttr;
using UnityEngine;

namespace Script.Factory.Attr
{
    public abstract class IAttrFactory
    {
        public abstract CharacterBaseAttr GetCharacterBaseAttr(Type type);
    }
}
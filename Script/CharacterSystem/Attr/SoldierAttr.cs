using System.Collections;
using System.Collections.Generic;
using Script.CharacterSystem.BaseAttr;
using UnityEngine;

public class SoldierAttr : ICharacterAttr
{
    public SoldierAttr(IAttrStrategy attrStrategy, int level, CharacterBaseAttr baseAttr) : base(attrStrategy, level, baseAttr)
    {
    }
}

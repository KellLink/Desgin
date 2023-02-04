using System.Collections;
using System.Collections.Generic;
using Script.CharacterSystem.BaseAttr;
using UnityEngine;

public class EnemyAttr : ICharacterAttr
{
    public EnemyAttr(IAttrStrategy attrStrategy, int level, CharacterBaseAttr baseAttr) : base(attrStrategy, level, baseAttr)
    {
    
    }
}

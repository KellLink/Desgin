using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacterAttr
{
    protected String _name;
    protected int _maxHp;
    protected float _moveSpeed;
    protected int _currentHp;
    protected String _iconSpritc;

    protected int _LV;
    protected float _criticalRate;

    protected IAttrStrategy _attrStrategy;
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacterAttr
{
    protected String _name;
    protected float _maxHp;
    protected float _moveSpeed;
    protected float _currentHp;
    protected String _iconSpritc;

    protected int _LV;
    protected float _criticalRate;

    protected IAttrStrategy _attrStrategy;
    
    public int CriticaPoint
    {
        get { return _attrStrategy.GetCriticalPoints(_attrStrategy.GetExtraCriticalRate(_LV)); }
    }
    
    public float CurrentHP
    {
        get { return _currentHp; }
    }

    public ICharacterAttr(IAttrStrategy attrStrategy)
    {
        _attrStrategy = attrStrategy;
        _currentHp = _maxHp + _attrStrategy.GetExtraHp(_LV);
        _moveSpeed += _attrStrategy.GetExtraSpeed(_LV);
    }

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;
    }
}

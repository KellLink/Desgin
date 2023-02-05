using System;
using System.Collections;
using System.Collections.Generic;
using Script.CharacterSystem.BaseAttr;
using UnityEngine;

public  class ICharacterAttr
{
    protected float _currentHp;
    protected int _LV;
    protected float _criticalRate;

    protected CharacterBaseAttr _baseAttr;

    protected IAttrStrategy _attrStrategy;

    
    public int CriticaPoint
    {
        get { return _attrStrategy.GetCriticalPoints(_attrStrategy.GetExtraCriticalRate(_LV)); }
    }

    public float CurrentHP
    {
        get { return _currentHp; }
    }
    
    public IAttrStrategy AttrStrategy
    {
        get { return _attrStrategy; }
    }

    public CharacterBaseAttr BaseAttr
    {
        get => _baseAttr;
    }

    public ICharacterAttr(IAttrStrategy attrStrategy,int level,CharacterBaseAttr baseAttr)
    {
        _baseAttr = baseAttr;
        _attrStrategy = attrStrategy;
        _LV = level;
        _currentHp = _baseAttr.MAXHp + _attrStrategy.GetExtraHp(_LV);
        //baseAttr.MoveSpeed += _attrStrategy.GetExtraSpeed(_LV);
    }

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter
{
    protected ICharacterAttr _attr;
    protected GameObject _gameObject;
    protected NavMeshAgent _navMeshAgent;
    protected AudioSource _audioSource;
    protected IWeapon _weapon;
    protected Animator _animator;

    public float AttackRange
    {
        get { return _weapon.attackRange; }
    }
    public IWeapon Weapon
    {
        set { _weapon = value; }
    }

    public void Attack(ICharacter target)
    {
        _weapon.Fire(target.GetPostion());
    }

    public void PlayAnimation(String name)
    {
        _animator.Play(name);
    }
    
    public void MoveTo(Vector3 desPostion)
    {
        _navMeshAgent.SetDestination(desPostion);
    }

    public Vector3 GetPostion()
    {
        if (_gameObject!=null)
        {
            return _gameObject.transform.position;
        }
        return Vector3.zero;
    }
}
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
        _gameObject.transform.LookAt(target.GetPostion());
        _weapon.Fire(target.GetPostion());
        _animator.Play("Attack");

        target.UnderAttack(_weapon.AttackPoint + _attr.CriticaPoint);
    }

    public virtual void UnderAttack(int damage)
    {
        _attr.TakeDamage(damage);
    }

    public void PlayAnimation(String name)
    {
        _animator.Play(name);
    }

    public void MoveTo(Vector3 desPostion)
    {
        _navMeshAgent.SetDestination(desPostion);
        _animator.Play("Run");
    }

    public Vector3 GetPostion()
    {
        if (_gameObject != null)
        {
            return _gameObject.transform.position;
        }

        return Vector3.zero;
    }

    public void Update()
    {
        _weapon.Update();
    }

    public void Killed()
    {
        //TODO
    }

    protected void DoPlaySoundGeneric(String soundName)
    {
        //TODO
        AudioClip clip = null;

        _audioSource.clip = clip;
        _audioSource.Play();
    }

    protected void DoPlayEffectGenic(String effectName)
    {
        //TODO 
        GameObject effectGo;
    }
}
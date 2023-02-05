using System;
using System.Collections;
using System.Collections.Generic;
using Script.CharacterSystem.Vistor;
using Script.Tools;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter
{
    protected ICharacterAttr _attr;
    protected GameObject _gameObject;
    protected NavMeshAgent _navMeshAgent;
    protected AudioSource _audioSource;
    protected IWeapon _weapon;
    protected Animation _animator;

    protected bool _isKilled = false;
    protected bool _canBeDestory = false;
    protected float _destoryTime = 2f;

    public GameObject CharacterGameObject
    {
        set
        {
            _gameObject = value;
            _animator = _gameObject.GetComponentInChildren<Animation>();
            _navMeshAgent = _gameObject.GetComponent<NavMeshAgent>();
            _audioSource = _gameObject.GetComponent<AudioSource>();
        }
    }

    public ICharacterAttr Attr
    {
        get { return _attr;}
        set { _attr = value; }
    }
    public GameObject GameObj
    {
        get => _gameObject;
    }

    public float AttackRange
    {
        get { return _weapon.attackRange; }
    }

    public bool CanBeDestroy => _canBeDestory;
    public bool IsKilled => _isKilled;
    
    
    public IWeapon Weapon
    {
        get { return _weapon;}
        set
        {
            _weapon = value;
            _weapon.Owner = this;
            //TODO weapon attach ?weapon-point
            GameObject weaponPoint = UnityToolkit.FindInChildren(_gameObject, "weapon-point");
            UnityToolkit.AttackChildren(weaponPoint, _weapon.GameObject);
        }
    }

    public void Attack(ICharacter target)
    {
        _gameObject.transform.LookAt(target.GetPostion());
        _weapon.Fire(target.GetPostion());
        _animator.Play("attack");

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
        _animator.Play("move");
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
        if (_isKilled)
        {
            _destoryTime -= Time.deltaTime;
            if (_destoryTime <= 0)
            {
                _canBeDestory = true;
            }

            return;
        }

        _weapon.Update();
    }

    public virtual void Killed()
    {
        //TODO
        _isKilled = true;
        _navMeshAgent.isStopped = true;
    }

    public void Release()
    {
        GameObject.Destroy(_gameObject);
    }

    protected void DoPlaySoundGeneric(String soundName)
    {
        AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(soundName);

        _audioSource.clip = clip;
        _audioSource.Play();
    }

    protected void DoPlayEffectGenic(String effectName)
    {
        GameObject effectGo = FactoryManager.AssetFactory.LoadEffect(effectName);
        effectGo.transform.position = _gameObject.transform.position;

        effectGo.AddComponent<DestroyObject>();
    }

    public abstract void RunVisitor(ICharacterVisitor visitor);
}
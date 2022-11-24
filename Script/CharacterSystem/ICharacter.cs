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

    public IWeapon Weapon
    {
        set { _weapon = value; }
    }

    public void Attack(Vector3 targetPostion)
    {
        _weapon.Fire(targetPostion);
    }
}
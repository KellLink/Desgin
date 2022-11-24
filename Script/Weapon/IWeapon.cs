using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon
{
    protected int _attkPoint;
    protected float _attkRange;
    protected int _attkCriticaPoint;

    protected GameObject _gameObject;
    protected ICharacter _owner;

    protected ParticleSystem _particle;
    protected Light _light;
    protected LineRenderer _lineRenderer;
    protected AudioSource _audioSource;

    public abstract void Fire(Vector3 targetPostion);
}

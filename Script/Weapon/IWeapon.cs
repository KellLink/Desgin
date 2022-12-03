using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class IWeapon
{
    protected int _attkPoint;
    protected float _attkRange;
    // protected int _attkCriticaPoint;

    protected GameObject _gameObject;
    protected ICharacter _owner;

    protected ParticleSystem _particle;
    protected Light _light;
    protected LineRenderer _lineRenderer;
    protected AudioSource _audioSource;

    protected float _effectPlayTime = 0f;
    
    public int AttackPoint
    {
        get { return _attkPoint; }
    }

    public float attackRange
    {
        get { return _attkRange; }
    }
    public void Update()
    {
        if (_effectPlayTime>0)
        {
            _effectPlayTime -= Time.deltaTime;
            if (_effectPlayTime<0)
            {
                DisableEffects();
            }
        }
    }

    public void Fire(Vector3 targetPostion)
    {
        PlayMuzzleEffect(targetPostion);
        PlayBulletEffect(targetPostion);
        PlaySoundEffect(targetPostion);
    }

    public void PlayMuzzleEffect(Vector3 targetPostion)
    {
        _particle.Stop();
        _particle.Play();
        _light.enabled = true;
    }
    protected abstract void PlayBulletEffect(Vector3 targetPostion);
    protected abstract void PlaySoundEffect(Vector3 targetPostion);

    protected void DoPlayBulletEffectGeneric(float lineWidth, Vector3 targetPostion)
    {
        _lineRenderer.enabled = true;
        _lineRenderer.startWidth = lineWidth;
        _lineRenderer.endWidth = lineWidth;
        _lineRenderer.SetPosition(0,_gameObject.transform.position);
        _lineRenderer.SetPosition(0,targetPostion);
    }

    protected void DoPlaySoundEffectGeneric(String audioClipName,Vector3 targetPostion)
    {
        AudioClip clip = null;
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    protected abstract void SetEffectPlayTime();

    protected void DisableEffects()
    {
        _light.enabled = false;
        _lineRenderer.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : IGameSystem
{
    private const float MAX_Energy=200;
    private float _currentEnergy = MAX_Energy;
    private float _recoverSpeed = 1f;
    public override void Update()
    {
        base.Update();
        if (_currentEnergy>=MAX_Energy)
        {
            GameFacade.Instance().UpdateEnergyBar((int)_currentEnergy,(int)MAX_Energy);
            _currentEnergy = MAX_Energy;
            return;
        }
        GameFacade.Instance().UpdateEnergyBar((int)_currentEnergy,(int)MAX_Energy);
        _currentEnergy += _recoverSpeed * Time.deltaTime;
    }

    public void End()
    {
        
    }

    public bool ConsumEnergy(int energy)
    {
        if (_currentEnergy>=energy)
        {
            _currentEnergy -= energy;
            return true;
        }

        return false;
    }

    public void RecycleEnergy(int energy)
    {
        _currentEnergy += energy;
        _currentEnergy = _currentEnergy >= MAX_Energy ? MAX_Energy : _currentEnergy;
    }
}

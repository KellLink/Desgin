using System;
using System.Collections.Generic;
using Script.CampSystem.Command;
using Script.CampSystem.EnergyCostStrategy;
using UnityEngine;


    public abstract class ICamp
    {
        protected GameObject _gameObject;
        protected String _name;
        protected String _iconSpite;
        protected SoldierType _soldierType;
        protected Vector3 _rallyPosition;
        protected float _trainTime;
        protected List<ITrainCommand> _trainCommands;
        private float _trainTimerCountDown = 0;

        protected IEnergyCostStrategy _energyCostStrategy;
        protected int _campUpgradeEnergy;
        protected int _weaponUpgradeEnergy;
        protected int _trainEnergy;

        public ICamp(GameObject gameObject, string name, string iconSpite, SoldierType soldierType,
            Vector3 rallyPosition, float trainTime)
        {
            _gameObject = gameObject;
            _name = name;
            _iconSpite = iconSpite;
            _soldierType = soldierType;
            _rallyPosition = rallyPosition;
            _trainTime = trainTime;
            _trainTimerCountDown = _trainTime;
            _trainCommands = new List<ITrainCommand>();
        }

        public virtual void Update()
        {
            UpdateCommand();
        }

        private void UpdateCommand()
        {
            if (_trainCommands.Count <= 0)
            {
                return;
            }

            _trainTimerCountDown -= Time.deltaTime;
            if (_trainTimerCountDown <= 0)
            {
                _trainCommands[0].Execute();
                _trainCommands.RemoveAt(0);
                _trainTimerCountDown = _trainTime;
            }
        }

        public string Name => _name;
        public string IconSpite => _iconSpite;
        public abstract int Level { get; }
        public abstract WeaponType WeaponTypeLevel { get; }
        public abstract void Train();

        public abstract int CampUpgradeEnergyCost { get; }

        public abstract int WeaponUpgradeEnergyCost { get; }

        public abstract int TrainEnergyCost { get; }

        public void CancelTrainCommand()
        {
            //TODO
            if (_trainCommands.Count > 0)
            {
                _trainCommands.RemoveAt(_trainCommands.Count - 1);
                if (_trainTimerCountDown == 0)
                {
                    _trainTimerCountDown = _trainTime;
                }
            }
        }

        public int GetTrainCount()
        {
            return _trainCommands.Count;
        }

        public float GetTrainRemainingTime()
        {
            return _trainTimerCountDown;
        }

        protected abstract void UpdateEnergyCost();
        public abstract void UpgradeCamp();
        public abstract void UpgradeWeapon();
        
    }

using System;
using UnityEngine;

namespace Script.StageSystem
{
    public class NormalStageHandler : IStageHandler
    {
        private EnemyType _enemyType;
        private WeaponType _weaponType;
        private int _enemyCount;
        private Vector3 _spawnPosition;

        private float _spawnInterval = 1f;
        private float _spawnTime = 0;
        private int _enemySpawned = 0;
        public override void UpdateStage()
        {
            base.UpdateStage();
            if (_enemySpawned<_enemyCount)
            {
                _spawnTime += Time.deltaTime;
                if (_spawnTime>_spawnInterval)
                {
                    SpawnEnemy();
                    _spawnTime = 0;
                }
            }
        }

        public NormalStageHandler(int level, int enemyKilledForStage, global::StageSystem stageSystem, EnemyType enemyType, WeaponType weaponType, int enemyCount, Vector3 spawnPosition) : base(level, enemyKilledForStage, stageSystem)
        {
            _enemyType = enemyType;
            _weaponType = weaponType;
            _enemyCount = enemyCount;
            _spawnPosition = spawnPosition;
        }

        public void SpawnEnemy()
        {
            switch (_enemyType)
            {
                case EnemyType.Elf:
                    FactoryManager.EnemySoldier.CreateCharacter<EnemyElf>(_weaponType, _spawnPosition);
                    break;
                case EnemyType.Orge:
                    FactoryManager.EnemySoldier.CreateCharacter<EnemyOrge>(_weaponType, _spawnPosition);
                    break;
                case EnemyType.Troll:
                    FactoryManager.EnemySoldier.CreateCharacter<EnemyTroll>(_weaponType, _spawnPosition);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _enemySpawned++;
        }
    }
}
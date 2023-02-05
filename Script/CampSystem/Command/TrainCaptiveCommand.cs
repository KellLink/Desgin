using Script.CharacterSystem.Soldier;
using UnityEngine;

namespace Script.CampSystem.Command
{
    public class TrainCaptiveCommand : ITrainCommand
    {
        private EnemyType _enemyType;
        private WeaponType _weaponType;
        private Vector3 _position;
        private int _level;

        public TrainCaptiveCommand(EnemyType enemyType, WeaponType weaponType, Vector3 position, int level = 1)
        {
            _enemyType = enemyType;
            _weaponType = weaponType;
            _position = position;
            _level = level;
        }

        public override void Execute()
        {
            IEnemy enemy = null;
            switch (_enemyType)
            {
                case EnemyType.Elf:
                    enemy = FactoryManager.EnemySoldier.CreateCharacter<EnemyElf>(_weaponType, _position) as IEnemy;
                    break;
                case EnemyType.Orge:
                    enemy = FactoryManager.EnemySoldier.CreateCharacter<EnemyOrge>(_weaponType, _position) as IEnemy;
                    break;
                case EnemyType.Troll:
                    enemy = FactoryManager.EnemySoldier.CreateCharacter<EnemyTroll>(_weaponType, _position) as IEnemy;
                    break;
                default:
                    Debug.Log("Invalid enemy type"+_enemyType);
                    break;
            }
            GameFacade.Instance().RemoveEnemy(enemy);
            SoldierCaptive captive = new SoldierCaptive(enemy);
            GameFacade.Instance().AddSoldier(captive);
        }
    }
}
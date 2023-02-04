using UnityEngine;

namespace Script.CampSystem.Command
{
    public class TrainSoldierCommand : ITrainCommand
    {
        private SoldierType _soldierType;
        private WeaponType _weaponType;
        private Vector3 _position;
        private int _level;

        public TrainSoldierCommand(SoldierType soldierType, WeaponType weaponType, Vector3 position, int level)
        {
            _soldierType = soldierType;
            _weaponType = weaponType;
            _position = position;
            _level = level;
        }

        public override void Execute()
        {
            switch (_soldierType)
            {
                case SoldierType.Rookie:
                    FactoryManager.SoldierFactory.CreateCharacter<SoldierRookie>(_weaponType, _position, _level);
                    break;
                case SoldierType.Sergeant:
                    FactoryManager.SoldierFactory.CreateCharacter<SoldierSergent>(_weaponType, _position, _level);
                    break;
                case SoldierType.Captain:
                    FactoryManager.SoldierFactory.CreateCharacter<SoldierCaptain>(_weaponType, _position, _level);
                    break;
                default:
                    Debug.LogError("Invalid type of" + _soldierType + "!!!!");
                    break;
            }
        }
    }
}
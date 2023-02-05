using Script.GameEventSystem.Subject;

namespace Script.GameEventSystem.Observer.SoldierKillObserver
{
    public class SoldierKilledObserverAchievement : IGameEventObserver
    {
        private AchievementSystem _achievementSystem;

        public SoldierKilledObserverAchievement(AchievementSystem achievementSystem)
        {
            _achievementSystem = achievementSystem;
        }

        public override void SetSubject(IGameEventSubject gameEventSubject)
        {
            
        }

        public override void Update()
        {
            _achievementSystem.AddSoldierKilledCount();
        }
    }
}
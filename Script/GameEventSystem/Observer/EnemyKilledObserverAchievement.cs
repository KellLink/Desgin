using Script.GameEventSystem.Subject;

namespace Script.GameEventSystem.Observer
{
    public class EnemyKilledObserverAchievement : IGameEventObserver
    {
        private AchievementSystem _achievementSystem;

        public EnemyKilledObserverAchievement(AchievementSystem achievementSystem)
        {
            _achievementSystem = achievementSystem;
        }

        public override void SetSubject(IGameEventSubject gameEventSubject)
        {
            
        }

        public override void Update()
        {
            _achievementSystem.AddEnemyKilledCount();
        }
    }
}
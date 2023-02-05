using Script.GameEventSystem.Subject;

namespace Script.GameEventSystem.Observer.NewStageObserver
{
    public class NewStageObserverAchievement : IGameEventObserver
    {
        private AchievementSystem _achievementSystem;
        private NewStageSubject _subject;

        public NewStageObserverAchievement(AchievementSystem achievementSystem)
        {
            _achievementSystem = achievementSystem;
        }

        public override void SetSubject(IGameEventSubject gameEventSubject)
        {
            _subject = gameEventSubject as NewStageSubject;
        }

        public override void Update()
        {
            _achievementSystem.SetMaxStageLevel(_subject.StageCount);
        }
    }
}
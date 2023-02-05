
    using UnityEngine;

    public class AchievementMemento
    {
        public int EnemyKilledCount { get; set; }
        public int SoldierKilledCount { get; set; }
        public int MaxStageLevel { get; set; }

        public void SaveData()
        {
            PlayerPrefs.SetInt("EnemyKilledCount",EnemyKilledCount);
            PlayerPrefs.SetInt("SoldierKilledCount",SoldierKilledCount);
            PlayerPrefs.SetInt("MaxStageLevel",MaxStageLevel);
        }

        public void LoadData()
        {
            EnemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount");
            SoldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount");
            MaxStageLevel = PlayerPrefs.GetInt("MaxStageLevel");
        }
    }

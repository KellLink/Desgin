
    using UnityEngine;

    public class SoldierAttrStrategy : IAttrStrategy
    {
        public float GetExtraHp(int lv)
        {
            return (lv - 1) * 0.1f;
        }

        public float GetExtraSpeed(int lv)
        {
            return (lv - 1) * 10;
        }

        public float GetExtraCriticalRate(int lv)
        {
            return (lv - 1) * 0.3f;
        }

        public int GetCriticalPoints(float cirtRate)
        {
            return (int) (Random.Range(0, cirtRate) * 100);
        }
    }

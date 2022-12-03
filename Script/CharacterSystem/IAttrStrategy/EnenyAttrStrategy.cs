

    using UnityEngine;

    public class EnenyAttrStrategy : IAttrStrategy
    {
        public float GetExtraHp(int lv)
        {
            return (lv - 1) * 0.3f;
        }

        public float GetExtraSpeed(int lv)
        {
            return (lv - 1) * 8;
        }

        public float GetExtraCriticalRate(int lv)
        {
            return (lv - 1) * 0.2f;
        }

        public int GetCriticalPoints(float cirtRate)
        {
            return (int) (Random.Range(0, cirtRate) * 130);
        }
    }

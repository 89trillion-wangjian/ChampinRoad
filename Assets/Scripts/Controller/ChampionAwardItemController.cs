using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class ChampionAwardItemController : MonoBehaviour
    {
        [SerializeField] private ChampionAwardItemView view;

        public static ChampionAwardItemController Singleton;

        private int conditionValue = 0;

        public void Awake()
        {
            Singleton = this;
        }

        public void InitCondition(int value)
        {
            conditionValue = value;
            view.RenderDisplay(conditionValue);
        }

        /// <summary>
        /// 领取奖励
        /// </summary>
        public void ReceiveAward()
        {
            ChampionModel.CreateInstance().SetAwardStatus(conditionValue, 1);
            ChampionModel.CreateInstance().PresentCoin += 100;
            view.RenderDisplay(conditionValue);
        }
    }
}
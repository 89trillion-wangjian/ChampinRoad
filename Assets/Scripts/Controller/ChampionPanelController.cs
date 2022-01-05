using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class ChampionPanelController : MonoBehaviour
    {
        [SerializeField] private ChampionPanelView view;

        private ChampionModel championModel = null;

        public static ChampionPanelController Singleton = null;

        private readonly int maxScore = 6000; //最大分数

        private readonly int startScore = 4000; //可领奖励起始分数

        private readonly int skipPart = 200;

        private void Awake()
        {
            championModel = ChampionModel.CreateInstance();
            Singleton = this;
            RenderAward();
        }

        public void HideChampionPanel()
        {
            view.ClosePanel();
        }

        /// <summary>
        /// 渲染奖励
        /// </summary>
        private void RenderAward()
        {
            int value = maxScore;
            while (value > startScore)
            {
                value -= skipPart;
                if (value % 1000 == 0) //整千分不领取
                {
                    continue;
                }

                view.CreateAwardItem(value);
                championModel.SetAwardStatus(value, 0);
            }
        }
    }
}
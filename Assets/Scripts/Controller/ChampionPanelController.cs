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
        public void RenderAward()
        {
            int value = 6000;
            while (value > 4000)
            {
                value -= 200;
                if (value % 1000 == 0)
                {
                    continue;
                }

                view.CreateAwardItem(value);
                championModel.SetAwardStatus(value, 0);
            }
        }
    }
}
using System;
using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class ChampionPanelController : MonoBehaviour
    {
        [SerializeField] private ChampionPanelView view;

        [SerializeField] private ChampionPanelController championPanelController;

        private MainModel mainModel;

        public static ChampionPanelController Singleton;

        private void Awake()
        {
            mainModel = MainModel.CreateInstance();
            Singleton = championPanelController;
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
                mainModel.SetAwardStatus(value, 0);
            }
        }

        /// <summary>
        /// 展示段位信息
        /// </summary>
        public void ShowMyScore()
        {
            if (mainModel.MyScore < 4000)
            {
                view.FreshScore(mainModel.MyScore.ToString());
            }
            else
            {
                view.FreshScore(string.Concat("大段位", ((mainModel.MyScore - 4000) / 1000 + 1)
                    , "(" + mainModel.MyScore + ")"));
            }
        }

        /// <summary>
        /// 刷新金币数量
        /// </summary>
        public void FreshCoin()
        {
            view.FreshCoin(mainModel.MyCoin.ToString());
        }
    }
}
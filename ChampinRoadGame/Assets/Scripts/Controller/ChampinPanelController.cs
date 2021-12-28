using System;
using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class ChampinPanelController : MonoBehaviour
    {
        [SerializeField] private ChampinPanelView view;
        private MainModel _mainModel;

        private void Awake()
        {
            _mainModel = MainModel.CreateInstance();
        }

        /**
     * 渲染奖励
     */
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
                _mainModel.SetAwardStatus(value, 0);
            }
        }

        /**
        * 段位信息
        */
        public void OnShowMyScore()
        {
            if (_mainModel.MyScore < 4000)
            {
                view.OnFreshScore(_mainModel.MyScore.ToString());
            }
            else
            {
                view.OnFreshScore(string.Concat("大段位", ((_mainModel.MyScore - 4000) / 1000 + 1),
                    "(" + _mainModel.MyScore + ")"));
            }
        }
        
        /**
        * 刷新金币
        */
        public void OnFreshCoin()
        {
            view.OnFreshCoin(_mainModel.MyCoin.ToString());
        }
    }
}
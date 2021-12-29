using System;
using Controller;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ChampionAwardItemView : MonoBehaviour
    {
        [SerializeField] private ChampionAwardItemView championPanelView;

        [SerializeField] private GameObject canReceiveAward;

        [SerializeField] private Text condition; //领取条件

        [SerializeField] private GameObject received;

        [SerializeField] private GameObject noReceive; //不可领取

        public static ChampionAwardItemView singleton;

        private int conditinValue = 0;

        public void Awake()
        {
            singleton = championPanelView;
        }

        public void RenderDisplay(int value)
        {
            conditinValue = value;
            this.condition.text = value + "";
            if (value > MainModel.CreateInstance().MyScore)
            {
                this.noReceive.SetActive(true);
                this.received.SetActive(false);
                this.canReceiveAward.SetActive(false);
                return;
            }

            if (MainModel.CreateInstance().GetAwardStatus(value) == 0)
            {
                this.noReceive.SetActive(false);
                this.received.SetActive(false);
                this.canReceiveAward.SetActive(true);
                return;
            }

            this.noReceive.SetActive(false);
            this.received.SetActive(true);
            this.canReceiveAward.SetActive(false);
        }

        /// <summary>
        /// 领取奖励
        /// </summary>
        public void ReceiveAward()
        {
            MainModel.CreateInstance().SetAwardStatus(conditinValue, 1);
            this.RenderDisplay(conditinValue);
            MainModel.CreateInstance().MyCoin += 100;
            ChampionPanelController.Singleton.FreshCoin();
        }
    }
}
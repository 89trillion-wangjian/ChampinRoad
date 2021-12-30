using Controller;
using Model;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using EventType = Model.EventType;

namespace View
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private GameObject championPanel;

        [SerializeField] private Text showScoreTxt;

        [SerializeField] private Text showSeasonTxt;

        [SerializeField] private MainController mainCtrl;

        private MainModel mainModel;

        void Start()
        {
            mainModel = MainModel.CreateInstance();
            showScoreTxt.text = mainModel.MyScore.ToString();
            showSeasonTxt.text = string.Concat("当前赛季", mainModel.PreSeason);
        }

        public void ShowChampionPanel()
        {
            this.championPanel.SetActive(true);
        }

        public void HideChampionPanel()
        {
            this.championPanel.SetActive(false);
        }


        /// <summary>
        /// 增加分数
        /// </summary>
        public void AddScore()
        {
            var nowScore = mainCtrl.AddScore();
            this.showScoreTxt.gameObject.SetActive(true);
            showScoreTxt.text = nowScore.ToString();
        }

        /**
        * 刷新新赛季
        */
        public void FreshSeason()
        {
            this.showSeasonTxt.gameObject.SetActive(true);
            showSeasonTxt.text = string.Concat("当前赛季", mainCtrl.FreshSeason());
            showScoreTxt.text = mainModel.MyScore.ToString();
            EventCenter.PostEvent(EventType.FreshAwardStatus);
        }
    }
}
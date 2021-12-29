using Controller;
using Model;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace View
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private GameObject champion;

        [SerializeField] private Text showScoreTxt;

        [SerializeField] private Text showSeasonTxt;

        [SerializeField] private MainController mainCtrl;

        private MainModel mainModel;

        void Start()
        {
            mainModel = MainModel.CreateInstance();
        }

        public void OpenChampion()
        {
            Instantiate(this.champion, transform, false);
        }


        /// <summary>
        /// 增加分数
        /// </summary>
        public void AddScore()
        {
            var nowScore = mainCtrl.AddScore();
            this.showScoreTxt.gameObject.SetActive(true);
            showScoreTxt.text = nowScore.ToString();
            CancelInvoke(nameof(HideScoreText));
            Invoke(nameof(HideScoreText), 2);
        }

        private void HideScoreText()
        {
            this.showScoreTxt.gameObject.SetActive(false);
        }

        /**
        * 刷新新赛季
        */
        public void FreshSeason()
        {
            this.showSeasonTxt.gameObject.SetActive(true);
            showSeasonTxt.text = string.Concat("当前赛季", mainCtrl.FreshSeason());
            CancelInvoke(nameof(HideSeasonTxt));
            Invoke(nameof(HideSeasonTxt), 2);
        }

        public void HideSeasonTxt()
        {
            this.showSeasonTxt.gameObject.SetActive(false);
        }
    }
}
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ChampionView : MonoBehaviour
    {
        [SerializeField] private GameObject championPanel;

        [SerializeField] private Text showScoreTxt;

        [SerializeField] private Text showSeasonTxt;

        private ChampionModel championModel;

        void Start()
        {
            championModel = ChampionModel.CreateInstance();
            championModel.OnScoreChange += AddScore;
            championModel.OnSeasonChange += FreshSeason;
            showScoreTxt.text = championModel.PresentScore.ToString();
            showSeasonTxt.text = $"赛季{championModel.PresentSeason}";
        }

        public void ShowChampionPanel()
        {
            championPanel.SetActive(true);
        }


        /// <summary>
        /// 增加分数
        /// </summary>
        private void AddScore(int score)
        {
            this.showScoreTxt.gameObject.SetActive(true);
            showScoreTxt.text = score.ToString();
        }

        /**
        * 刷新新赛季
        */
        private void FreshSeason(int season)
        {
            showSeasonTxt.gameObject.SetActive(true);
            showSeasonTxt.text = $"赛季{season}";
        }
    }
}
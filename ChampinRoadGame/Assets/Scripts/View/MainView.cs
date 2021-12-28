using Controller;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class MainView : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private GameObject champin;
        private MainModel _mainModel;
        [SerializeField] private Text showScoreTxt;
        [SerializeField] private Text showSeasonTxt;
        [SerializeField] private MainController mainCtrl;

        void Start()
        {
            _mainModel = MainModel.CreateInstance();
        }

        public void OnOpenChampin()
        {
            Instantiate(this.champin, transform, false);
        }


        /**
     * 手动增加分数
     */
        public void OnAddScore()
        {
            int nowScore = mainCtrl.OnAddScore();
            this.showScoreTxt.gameObject.SetActive(true);
            showScoreTxt.text = nowScore.ToString();
            CancelInvoke(nameof(OnHideScoreText));
            Invoke(nameof(OnHideScoreText), 2);
        }

        private void OnHideScoreText()
        {
            this.showScoreTxt.gameObject.SetActive(false);
        }

        /**
        * 刷新新赛季
        */
        public void OnFreshSeason()
        {
            this.showSeasonTxt.gameObject.SetActive(true);
            showSeasonTxt.text = string.Concat("当前赛季", mainCtrl.OnFreshSeason());
            CancelInvoke(nameof(OnHideSeasonTxt));
            Invoke(nameof(OnHideSeasonTxt), 2);
        }

        public void OnHideSeasonTxt()
        {
            this.showSeasonTxt.gameObject.SetActive(false);
        }
    }
}
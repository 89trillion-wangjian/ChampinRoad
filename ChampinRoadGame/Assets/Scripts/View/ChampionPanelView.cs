using Controller;
using Model;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace View
{
    public class ChampionPanelView : MonoBehaviour
    {
        [SerializeField] private GameObject championAwardContent;

        [SerializeField] private GameObject championAwardItem;

        [SerializeField] private Text myScore;

        [SerializeField] private Text coinNumTxt;

        [SerializeField] private ChampionPanelController championCtrl;

        private MainModel mainModel;

        public void Start()
        {
            mainModel = MainModel.CreateInstance();
            championCtrl.RenderAward();
            championCtrl.ShowMyScore();
            championCtrl.FreshCoin();
        }

        public void CreateAwardItem(int value)
        {
            Instantiate(championAwardItem, championAwardContent.transform, false);
            ChampionAwardItemView.singleton.RenderDisplay(value);
        }

        /// <summary>
        /// 刷新分数
        /// </summary>
        /// <param name="text"></param>
        public void FreshScore(string text)
        {
            this.myScore.text = text;
        }

        /// <summary>
        /// 刷新金币数值
        /// </summary>
        /// <param name="coinNum">金币数量</param>
        public void FreshCoin(string coinNum)
        {
            this.coinNumTxt.text = coinNum;
            LayoutRebuilder.ForceRebuildLayoutImmediate(coinNumTxt.rectTransform);
        }

        public void ClosePanel()
        {
            Destroy(this.gameObject);
        }
    }
}
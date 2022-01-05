using Controller;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ChampionPanelView : MonoBehaviour
    {
        [SerializeField] private GameObject scrollContent;

        [SerializeField] private GameObject championAwardItem;

        [SerializeField] private Text myLevel;

        [SerializeField] private Text coinNumTxt;

        private ChampionModel championModel = null;

        private readonly int startScore = 4000; //大于4000可以领奖

        public void Awake()
        {
            championModel = ChampionModel.CreateInstance();
            championModel.OnScoreChange += FreshLevel;
            championModel.OnCoinChange += FreshCoin;
        }

        public void OnEnable()
        {
            FreshLevel(championModel.PresentScore);
            FreshCoin(championModel.PresentCoin);
        }

        public void CreateAwardItem(int value)
        {
            Instantiate(championAwardItem, scrollContent.transform, false);
            ChampionAwardItemController.Singleton.InitCondition(value);
        }

        /// <summary>
        /// 刷新段位信息
        /// </summary>
        /// <param name="presentScore">当前分数</param>
        private void FreshLevel(int presentScore)
        {
            if (presentScore < startScore)
            {
                myLevel.text = presentScore.ToString();
                return;
            }

            myLevel.text = $"大段位{(championModel.PresentScore - 4000) / 1000 + 1}({championModel.PresentScore})";
        }

        /// <summary>
        /// 刷新金币数值
        /// </summary>
        /// <param name="coinNum">金币数量</param>
        private void FreshCoin(int coinNum)
        {
            coinNumTxt.text = coinNum.ToString();
            LayoutRebuilder.ForceRebuildLayoutImmediate(coinNumTxt.rectTransform);
        }

        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }
    }
}
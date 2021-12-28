using Controller;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ChampinPanelView : MonoBehaviour
    {
        // Start is called before the first frame update
        public int addValue = 100;
        [SerializeField] private GameObject champinAwardContent;
        [SerializeField] private GameObject champinAwardItem;
        [SerializeField] private Text myScore;
        [SerializeField] private Text coinNumTxt;
        [SerializeField] private ChampinPanelController champinCtrl;
        private MainModel _mainModel;

        void Start()
        {
            _mainModel = MainModel.CreateInstance();
            champinCtrl.RenderAward();
            champinCtrl.OnShowMyScore();
            champinCtrl.OnFreshCoin();
        }


        public void CreateAwardItem(int value)
        {
            GameObject item = Instantiate(champinAwardItem, champinAwardContent.transform, false);
            item.GetComponent<ChampinAwardItemView>().RenderDisplay(value);
        }


        public void OnFreshScore(string text)
        {
            this.myScore.text = text;
        }

        /**
        * 刷新金币
        */
        public void OnFreshCoin(string coinNum)
        {
            this.coinNumTxt.text = coinNum;
            LayoutRebuilder.ForceRebuildLayoutImmediate(coinNumTxt.rectTransform);
        }

        public void OnClosePanel()
        {
            Destroy(this.gameObject);
        }
    }
}
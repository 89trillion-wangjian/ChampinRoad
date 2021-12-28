using Controller;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ChampinAwardItemView : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject canReceiveAward;
        public Text condition; //领取条件 
        public GameObject received;
        public GameObject noReceive; //不可领取


        private int _conditinValue;

        public void RenderDisplay(int value)
        {
            _conditinValue = value;
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

        /**
     * 领取奖励
     */
        public void OnGetAward()
        {
            MainModel.CreateInstance().SetAwardStatus(_conditinValue, 1);
            this.RenderDisplay(_conditinValue);

            MainModel.CreateInstance().MyCoin += 100;

            GameObject panel = GameObject.Find("Canvas/ChampionRoadPanel(Clone)");
            panel.GetComponent<ChampinPanelController>().OnFreshCoin();
        }
    }
}
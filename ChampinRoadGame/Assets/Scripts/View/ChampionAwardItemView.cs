using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ChampionAwardItemView : MonoBehaviour
    {
        [SerializeField] private GameObject canReceiveAward;

        [SerializeField] private Text condition; //领取条件

        [SerializeField] private GameObject received;

        [SerializeField] private GameObject noReceive; //不可领取

        private ChampionModel championModel = null;

        private int conditionValue = 0;

        public void Awake()
        {
            championModel = ChampionModel.CreateInstance();
            championModel.OnScoreChange += RefreshDisplay;
        }

        public void RenderDisplay(int value)
        {
            condition.text = $"{value}可领取";
            conditionValue = value;
            RefreshDisplay(championModel.PresentScore);
        }

        public void RefreshDisplay(int presentScore)
        {
            if (conditionValue > presentScore)
            {
                this.noReceive.SetActive(true);
                this.received.SetActive(false);
                this.canReceiveAward.SetActive(false);
                return;
            }

            if (ChampionModel.CreateInstance().GetAwardStatus(conditionValue) == 0)
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
    }
}
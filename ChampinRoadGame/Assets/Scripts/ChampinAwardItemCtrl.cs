using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChampinAwardItemCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canReceiveAward;
    public Text condition;      //领取条件 
    public GameObject received;
    public GameObject noReceive;//不可领取

    private int getCoin = 100;

    private int conditinValue;
    public void RenderDisplay(int Value)
    {
        conditinValue = Value;
        this.condition.text = Value + "";
        if (Value > DataManager.CreateInstance().MyScore)
        {
            this.noReceive.SetActive(true);
            this.received.SetActive(false);
            this.canReceiveAward.SetActive(false);
            return;
        }
        if (DataManager.CreateInstance().getAwardStatus(Value) == 0)
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
        DataManager.CreateInstance().setAwardStatus(conditinValue, 1);
        this.RenderDisplay(conditinValue);

        DataManager.CreateInstance().MyCoin += 100;

        GameObject panel = GameObject.Find("Canvas/ChampionRoadPanel(Clone)");
        panel.GetComponent<ChampinPanelCtrl>().OnFreshCoin();
    }

}

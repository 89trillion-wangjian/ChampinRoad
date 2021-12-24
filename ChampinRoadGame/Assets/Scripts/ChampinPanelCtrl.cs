using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChampinPanelCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public int addValue = 100;
    public GameObject champinAwardContent;
    public GameObject champinAwardItem;
    public Text myScore;
    
    
    private DataManager dataManager;
    void Start()
    {
        dataManager = DataManager.CreateInstance();
        RenderAward();
        OnShowMyScore();
    }
    
    /**
     * 渲染奖励
     */
    private void RenderAward()
    {
        int value = 6000;
        while (value > 4000)
        {
            value -= 200;
            if (value % 1000 == 0)
            {
                continue;
            }
            GameObject item = Instantiate(champinAwardItem);
            item.transform.SetParent(champinAwardContent.transform, false);
            item.GetComponent<ChampinAwardItemCtrl>().RenderDisplay(value);
            dataManager.setAwardStatus(value, 0);
        }
    }
    /**
     * 段位信息
     */
    private void OnShowMyScore()
    {
        if (dataManager.MyScore < 4000)
        {
            this.myScore.text = dataManager.MyScore + "";
        }
        else
        {
            Debug.Log("段位信息" + (dataManager.MyScore - 4000));
            this.myScore.text = string.Concat("大段位", ((dataManager.MyScore - 4000) / 1000 + 1), "(" + dataManager.MyScore + ")");
        }
    }
    
    public void OnClosePanel()
    {
        Destroy(this.gameObject);
    }

}

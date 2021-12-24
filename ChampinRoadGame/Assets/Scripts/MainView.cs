using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject champin;
    private DataManager dataManager;
    public Text showScoreTxt;
    public Text showSeasonTxt;
    
    void Start()
    {
        dataManager = DataManager.CreateInstance();
    }

    public void OnOpenChampin()
    {
        GameObject gameObject = Instantiate(this.champin);
        gameObject.transform.SetParent(transform, false);
    }
    
    
    /**
     * 手动增加分数
     */
    public void OnAddScore()
    {
        if (dataManager.MyScore >= 6000)
        {
            return;
        }

        dataManager.MyScore += 100;
        dataManager.MyScore = dataManager.MyScore > 6000 ? 6000 : dataManager.MyScore;
        
        this.showScoreTxt.gameObject.SetActive(true);
        showScoreTxt.text = dataManager.MyScore + "";   
        CancelInvoke("OnHideScoreText");
        Invoke("OnHideScoreText", 2);
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
        dataManager.PreSeason += 1;
        dataManager.MyScore = CalcScore(dataManager.MyScore);
        dataManager.clearAward();

        this.showSeasonTxt.gameObject.SetActive(true);
        showSeasonTxt.text = string.Concat("当前赛季", dataManager.PreSeason);
        CancelInvoke("OnHideSeasonTxt");
        Invoke("OnHideSeasonTxt", 2);
    }

    public void OnHideSeasonTxt()
    {
        this.showSeasonTxt.gameObject.SetActive(false);
    }

    /**
     * 赛季留分规则
     */
    public int CalcScore(int myScore)
    {
        return myScore <= 4000 ? 4000 : 4000 + (myScore - 4000) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject champin;
    private DataManager dataManager;
    [SerializeField]private Text showScoreTxt;
    [SerializeField] private Text showSeasonTxt;

    private int maxScore = 6000;
    private int startScore = 4000;
    private int getCoin = 100;
    void Start()
    {
        dataManager = DataManager.CreateInstance();
    }

    public void OnOpenChampin()
    {
        GameObject node = Instantiate(this.champin);
        node.transform.SetParent(transform, false);
    }
    
    
    /**
     * 手动增加分数
     */
    public void OnAddScore()
    {
        if (dataManager.MyScore >= maxScore)
        {
            return;
        }

        dataManager.MyScore += getCoin;
        dataManager.MyScore = dataManager.MyScore > maxScore ? maxScore : dataManager.MyScore;
        
        this.showScoreTxt.gameObject.SetActive(true);
        showScoreTxt.text = dataManager.MyScore + "";   
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
        dataManager.PreSeason += 1;
        dataManager.MyScore = CalcScore(dataManager.MyScore);
        dataManager.ClearAward();

        this.showSeasonTxt.gameObject.SetActive(true);
        showSeasonTxt.text = string.Concat("当前赛季", dataManager.PreSeason);
        CancelInvoke(nameof(OnHideSeasonTxt));
        Invoke(nameof(OnHideSeasonTxt), 2);
    }

    public void OnHideSeasonTxt()
    {
        this.showSeasonTxt.gameObject.SetActive(false);
    }

    /**
     * 赛季留分规则
     */
    private int CalcScore(int myScore)
    {
        return myScore <= startScore ? startScore : startScore + (myScore - startScore) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

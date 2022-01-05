using System;
using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class ChampionController : MonoBehaviour
    {
        [SerializeField] private ChampionView view;

        private ChampionModel championModel = null;

        private readonly int maxScore = 6000; //最大分数

        private readonly int onceAddScore = 100; //单次加分

        private readonly int startScore = 4000; //可领奖励起始分数

        private void Awake()
        {
            championModel = ChampionModel.CreateInstance();
        }

        public void ShowChampionPanel()
        {
            view.ShowChampionPanel();
        }

        /// <summary>
        /// 加分
        /// </summary>
        /// <returns></returns>
        public void AddScore()
        {
            if (championModel.PresentScore >= maxScore)
            {
                return;
            }

            championModel.PresentScore += onceAddScore;
            championModel.PresentScore = Math.Min(championModel.PresentScore, maxScore);
        }

        /// <summary>
        /// 新赛季
        /// </summary>
        /// <returns></returns>
        public void FreshSeason()
        {
            championModel.PresentSeason += 1;
            championModel.ClearAward();
            championModel.PresentScore = CalcScore(championModel.PresentScore);
        }

        /// <summary>
        /// 计算新赛季分数
        /// </summary>
        /// <param name="myScore">当前分数</param>
        /// <returns></returns>
        private int CalcScore(int myScore)
        {
            return myScore <= startScore ? myScore : startScore + (myScore - startScore) / 2;
        }
    }
}
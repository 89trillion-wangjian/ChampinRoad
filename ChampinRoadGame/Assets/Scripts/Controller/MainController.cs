using Model;
using UnityEngine;
using Utils;
using View;
using EventType = Model.EventType;

namespace Controller
{
    public class MainController : MonoBehaviour
    {

        [SerializeField] private MainView mainView;
        
        private MainModel mainModel;
        
        private readonly int maxScore = 6000; //最大分数

        private readonly int getCoin = 100;   //单次加分

        private readonly int startScore = 4000;//可领奖励起始分数

        private void Awake()
        {
            mainModel = MainModel.CreateInstance();
        }

        /// <summary>
        /// 加分
        /// </summary>
        /// <returns></returns>
        public int AddScore()
        {
            if (mainModel.MyScore >= maxScore)
            {
                return mainModel.MyScore;
            }

            mainModel.MyScore += getCoin;
            mainModel.MyScore = mainModel.MyScore > maxScore ? maxScore : mainModel.MyScore;
            //刷新段位
            EventCenter.PostEvent(EventType.FreshLevel);   
            //刷新奖品状态
            EventCenter.PostEvent(EventType.FreshAwardStatus);
            return mainModel.MyScore;
        }

        /// <summary>
        /// 新赛季
        /// </summary>
        /// <returns></returns>
        public int FreshSeason()
        {
            mainModel.PreSeason += 1;
            mainModel.MyScore = CalcScore(mainModel.MyScore);
            mainModel.ClearAward();
            //刷新段位
            EventCenter.PostEvent(EventType.FreshLevel);
            return mainModel.PreSeason;
        }

        /// <summary>
        /// 计算新赛季分数
        /// </summary>
        /// <param name="myScore">当前分数</param>
        /// <returns></returns>
        private int CalcScore(int myScore)
        {
            return myScore <= startScore ? startScore : startScore + (myScore - startScore) / 2;
        }
    }
}
using Model;
using UnityEngine;

namespace Controller
{
    public class MainController : MonoBehaviour
    {
        private MainModel mainModel;

        private readonly int maxScore = 6000;

        private readonly int getCoin = 100;

        private readonly int startScore = 4000;

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
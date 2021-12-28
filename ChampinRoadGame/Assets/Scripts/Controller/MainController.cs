using System;
using Model;
using UnityEngine;

namespace Controller
{
    public class MainController : MonoBehaviour
    {
        private MainModel _mainModel;
        private readonly int maxScore = 6000;
        private readonly int getCoin = 100;
        private readonly int startScore = 4000;

        private void Awake()
        {
            _mainModel = MainModel.CreateInstance();
        }

        public int OnAddScore()
        {
            if (_mainModel.MyScore >= maxScore)
            {
                return _mainModel.MyScore;
            }

            _mainModel.MyScore += getCoin;
            _mainModel.MyScore = _mainModel.MyScore > maxScore ? maxScore : _mainModel.MyScore;
            return _mainModel.MyScore;
        }

        public int OnFreshSeason()
        {
            _mainModel.PreSeason += 1;
            _mainModel.MyScore = CalcScore(_mainModel.MyScore);
            _mainModel.ClearAward();
            return _mainModel.PreSeason;
        }

        /**
     * 赛季留分规则
     */
        private int CalcScore(int myScore)
        {
            return myScore <= startScore ? startScore : startScore + (myScore - startScore) / 2;
        }
    }
}
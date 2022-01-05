using System.Collections.Generic;

namespace Model
{
    public class ChampionModel
    {
        public delegate void OnValueChange(int val);

        private int presentScore = 0;

        private int presentSeason = 0;

        private int presentCoin = 0;

        public OnValueChange OnScoreChange = null;

        public OnValueChange OnSeasonChange = null;

        public OnValueChange OnCoinChange = null;

        private static ChampionModel singleton = null;

        private readonly Dictionary<int, int> awardDic = new Dictionary<int, int>();


        public static ChampionModel CreateInstance()
        {
            return singleton ?? (singleton = new ChampionModel());
        }

        public int PresentScore
        {
            get
            {
                return presentScore;
            }
            set
            {
                presentScore = value;
                OnScoreChange?.Invoke(presentScore);
            }
        }

        public int PresentSeason
        {
            get
            {
                return presentSeason;
            }
            set
            {
                presentSeason = value;
                OnSeasonChange?.Invoke(presentSeason);
            }
        }

        public int PresentCoin
        {
            get
            {
                return presentCoin;
            }
            set
            {
                presentCoin = value;
                OnCoinChange?.Invoke(presentCoin);
            }
        }


        public int GetAwardStatus(int key)
        {
            this.awardDic.TryGetValue(key, out var status);
            return status;
        }

        public void SetAwardStatus(int key, int value)
        {
            this.awardDic[key] = value;
        }

        public void ClearAward()
        {
            this.awardDic.Clear();
        }
    }
}
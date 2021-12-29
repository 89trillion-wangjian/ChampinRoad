using System.Collections.Generic;

namespace Model
{
    public class MainModel
    {
        public int MyScore { set; get; } = 4500;
        
        public int PreSeason { set; get; } = 1;

        public int MyCoin { set; get; } = 0;
        
        private static MainModel _singleton = null;
        
        private readonly Dictionary<int, int> _awardDic = new Dictionary<int, int>();
        private MainModel()
        {
        }

        public static MainModel CreateInstance()
        {
            if (_singleton == null)
            {
                _singleton = new MainModel();
            }

            return _singleton;
        }

        public int GetAwardStatus(int key)
        {
            this._awardDic.TryGetValue(key, out var status);
            return status;
        }

        public void SetAwardStatus(int key, int value)
        {
            this._awardDic[key] = value;
        }

        public void ClearAward()
        {
            this._awardDic.Clear();
        }
    }
}
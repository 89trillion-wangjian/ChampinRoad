using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    
    private DataManager() { }
    private static DataManager _Singleton = null;
    
    private Dictionary<int, int> awardDic = new Dictionary<int, int>();
    public static DataManager CreateInstance()
    {
        if (_Singleton == null)
        {
            _Singleton = new DataManager();
        }
        return _Singleton;
    }


    public int MyScore { set; get; } = 4500;
    public int PreSeason { set; get; } = 1;

    public int getAwardStatus( int key)
    {
        int status = 0;
        this.awardDic.TryGetValue(key, out status);
        return status;
    }

    public void setAwardStatus(int key, int value)
    {
        this.awardDic[key] = value;
    }

    public void clearAward()
    {
        this.awardDic.Clear();
    }
}

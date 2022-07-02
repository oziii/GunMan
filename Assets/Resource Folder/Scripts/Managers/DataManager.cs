using System;
using System.Collections;
using System.Collections.Generic;
using OziLib;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private DataSO _dataSo;
    private int _currentCoinCollect;
    public static DataManager instance;
    
    #region UNITY_METHODS

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        EventManager.StartListening(EventTags.LEVEL_START, LevelStart);
        EventManager.StartListening(EventTags.LEVEL_END, LevelEnd);
        EventManager.StartListening(EventTags.COIN_COLLECT, CoinCollectData);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventTags.LEVEL_START, LevelStart);
        EventManager.StopListening(EventTags.LEVEL_END, LevelEnd);
        EventManager.StopListening(EventTags.COIN_COLLECT, CoinCollectData);
    }



    private void Start()
    {
        DataControlInit();
    }

    #endregion

    #region METHODS

    private void DataControlInit()
    {
        if (!PlayerPrefs.HasKey(EventTags.LEVEL_COUNTER))
        {
            PlayerPrefs.SetInt(EventTags.LEVEL_COUNTER, _dataSo.Level);
            PlayerPrefs.SetInt(EventTags.COIN_COUNTER, _dataSo.Coin);
            PlayerPrefs.Save();
        }
    }

    public int GetIntData(string dataName)
    {
        var data = PlayerPrefs.GetInt(dataName);
        return data;
    }

    public void SetIntData(string dataName, int data)
    {
        PlayerPrefs.SetInt(dataName, data);
        PlayerPrefs.Save();
    }

    public int GetCurrentCoin()
    {
        return _currentCoinCollect;
    }
    
    #endregion

    #region ACTION

    private void LevelEnd(object arg0)
    {
        PlayerPrefs.Save();
    }               
        
    private void LevelStart(object arg0)
    {
        _currentCoinCollect = 0;
    }
    private void CoinCollectData(object arg0)
    {
        _currentCoinCollect++;
    }

    #endregion
}
        
using System;
using System.Collections;
using System.Collections.Generic;
using OziLib;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelSO[] _levelArr;
    [SerializeField] private UIManager _uiManager;
    private Level _currentLevel;
    #region UNITY_METHODS

    private void OnEnable()
    {
        EventManager.StartListening(EventTags.LEVEL_START, LevelStart);
        EventManager.StartListening(EventTags.LEVEL_END, LevelEnd);
        EventManager.StartListening(EventTags.NEXT_LEVEL, onNextLevel);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventTags.LEVEL_START, LevelStart);
        EventManager.StopListening(EventTags.LEVEL_END, LevelEnd);
        EventManager.StopListening(EventTags.NEXT_LEVEL, onNextLevel);
    }

    private void Start()
    {
        //LevelCreater();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EventManager.TriggerEvent(EventTags.THREE_AMMO, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EventManager.TriggerEvent(EventTags.TWO_AMMO, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EventManager.TriggerEvent(EventTags.AMMO_SPEED_BOOST, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EventManager.TriggerEvent(EventTags.FIRE_RATE_BOOST, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            EventManager.TriggerEvent(EventTags.CHARACTER_SPEED_BOOST, true);
        }
        
    }

    #endregion

    #region METHODS

    private void LevelCreater()
    {
        var levelCount = DataManager.instance.GetIntData(EventTags.LEVEL_COUNTER);
        var level = _levelArr[levelCount % _levelArr.Length].LevelPrefab;
        _currentLevel = Instantiate(level);
        _uiManager.init();
    }

    #endregion
    
    #region ACTION

    private void LevelEnd(object arg0)
    {
        var levelCount = DataManager.instance.GetIntData(EventTags.LEVEL_COUNTER);
        levelCount++;
        DataManager.instance.SetIntData(EventTags.LEVEL_COUNTER, levelCount);
        
    }

    private void LevelStart(object arg0)
    {
        
    }
    
    private void onNextLevel(object arg0)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #endregion
}

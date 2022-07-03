using System;
using System.Collections;
using System.Collections.Generic;
using OziLib;
using UnityEngine;
using UnityEngine.UI;

public class StaticUIElements : UIBase
{
    [SerializeField] private Text _coinText;
    [SerializeField] private Text _levelText;
    [SerializeField] private ButtonSO _buttonSo;
    private int _buttonCount;
    private bool _isThreeAmmo;
    private bool _isTwoAmmo;
    private bool _isFireRateBoost;
    private bool _isAmmoSpeedBoost;
    private bool _isCharacterSpeedBoost;
    
    #region UNITY_METHODS

    private void OnEnable()
    {
        EventManager.StartListening(EventTags.COIN_COLLECT, onCoinCollect);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventTags.COIN_COLLECT, onCoinCollect);
    }



    #endregion

    #region OVERRIDE

    public override void ShowUI()
    {
        base.ShowUI();
        //TextSet();
    }

    #endregion

    #region METHODS

    private void TextSet()
    {
        var coinData = DataManager.instance.GetIntData(EventTags.COIN_COUNTER);
        var levelData = DataManager.instance.GetIntData(EventTags.LEVEL_COUNTER);
        _coinText.text = coinData.ToString();
        _levelText.text = "LEVEL " + levelData;
    }

    private bool GetButtonCountControl(bool buttonState)
    {
        if (buttonState)
        {
            if (_buttonSo.MAXSpecialPower > _buttonCount)
            {
                _buttonCount++;
                return true;
            }
            else
            {
                return false;
            }
                
        }
        else
        {
            _buttonCount--;
            return true;
        }
    }
    
    #endregion

    #region BUTTON_METHODS

    public void OnClickExitButton()
    {
        EventManager.TriggerEvent(EventTags.LEVEL_END, this);
    }
    
    public void OnClickThreeAmmo()
    {
        if(!GetButtonCountControl(!_isThreeAmmo)) return;
        _isThreeAmmo = !_isThreeAmmo;
        EventManager.TriggerEvent(EventTags.THREE_AMMO, _isThreeAmmo);
    }

    public void OnClickTwoAmmo()
    {
        if(!GetButtonCountControl(!_isTwoAmmo)) return;
        _isTwoAmmo = !_isTwoAmmo;
        EventManager.TriggerEvent(EventTags.TWO_AMMO, _isTwoAmmo);
    }

    public void OnClickFireRateBoost()
    {
        if(!GetButtonCountControl(!_isFireRateBoost)) return;
        _isFireRateBoost = !_isFireRateBoost;
        EventManager.TriggerEvent(EventTags.FIRE_RATE_BOOST, _isFireRateBoost);
    }

    public void OnClickAmmoSpeedBoost()
    {
        if(!GetButtonCountControl(!_isAmmoSpeedBoost)) return;
        _isAmmoSpeedBoost = !_isAmmoSpeedBoost;
        EventManager.TriggerEvent(EventTags.FIRE_RATE_BOOST, _isAmmoSpeedBoost);
    }

    public void OnClickCharacterSpeedBoost()
    {
        if(!GetButtonCountControl(!_isCharacterSpeedBoost)) return;
        _isCharacterSpeedBoost = !_isCharacterSpeedBoost;
        EventManager.TriggerEvent(EventTags.CHARACTER_SPEED_BOOST, _isCharacterSpeedBoost);
    }
    

    #endregion
    
    #region ACTIONS

    private void onCoinCollect(object arg0)
    {
        var data = DataManager.instance.GetIntData(EventTags.COIN_COUNTER);
        data++;
        _coinText.text = data.ToString();
        DataManager.instance.SetIntData(EventTags.COIN_COUNTER, data);
    }

    #endregion
}

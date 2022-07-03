using System;
using System.Collections;
using System.Collections.Generic;
using OziLib;
using UnityEngine;
using UnityEngine.UI;

public class StaticUIElements : UIBase
{
    [SerializeField] private ButtonSO _buttonSo;
    [Header("Button Fields")]
    [SerializeField] private Image _threeAmmoImage;
    [SerializeField] private Image _twoAmmoImage;
    [SerializeField] private Image _fireRateBoostImage;
    [SerializeField] private Image _ammoSpeedBoostImage;
    [SerializeField] private Image _characterSpeedBoostImage;
    
    private int _buttonCount;
    private bool _isThreeAmmo;
    private bool _isTwoAmmo;
    private bool _isFireRateBoost;
    private bool _isAmmoSpeedBoost;
    private bool _isCharacterSpeedBoost;
    
    #region UNITY_METHODS

    private void Start()
    {
        ButtonColorChanged(_threeAmmoImage, false);
        ButtonColorChanged(_twoAmmoImage, false);
        ButtonColorChanged(_ammoSpeedBoostImage, false);
        ButtonColorChanged(_characterSpeedBoostImage, false);
        ButtonColorChanged(_fireRateBoostImage, false);
    }

    #endregion

    #region OVERRIDE
    

    #endregion

    #region METHODS

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

    private void ButtonColorChanged(Image buttonImage, bool isButtonState)
    {
        buttonImage.color = isButtonState ? _buttonSo.ButtonSelectedColor : _buttonSo.ButtonUnselectedColor;
    }
    #endregion

    #region BUTTON_METHODS

    public void OnClickExitButton()
    {
        EventManager.TriggerEvent(EventTags.NEXT_LEVEL, this);
    }
    
    public void OnClickThreeAmmo()
    {
        if(!GetButtonCountControl(!_isThreeAmmo)) return;
        _isThreeAmmo = !_isThreeAmmo;
        EventManager.TriggerEvent(EventTags.THREE_AMMO, _isThreeAmmo);
        ButtonColorChanged(_threeAmmoImage, _isThreeAmmo);
    }

    public void OnClickTwoAmmo()
    {
        if(!GetButtonCountControl(!_isTwoAmmo)) return;
        _isTwoAmmo = !_isTwoAmmo;
        EventManager.TriggerEvent(EventTags.TWO_AMMO, _isTwoAmmo);
        ButtonColorChanged(_twoAmmoImage, _isTwoAmmo);
    }

    public void OnClickFireRateBoost()
    {
        if(!GetButtonCountControl(!_isFireRateBoost)) return;
        _isFireRateBoost = !_isFireRateBoost;
        EventManager.TriggerEvent(EventTags.FIRE_RATE_BOOST, _isFireRateBoost);
        ButtonColorChanged(_fireRateBoostImage, _isFireRateBoost);
    }

    public void OnClickAmmoSpeedBoost()
    {
        if(!GetButtonCountControl(!_isAmmoSpeedBoost)) return;
        _isAmmoSpeedBoost = !_isAmmoSpeedBoost;
        EventManager.TriggerEvent(EventTags.AMMO_SPEED_BOOST, _isAmmoSpeedBoost);
        ButtonColorChanged(_ammoSpeedBoostImage, _isAmmoSpeedBoost);
    }

    public void OnClickCharacterSpeedBoost()
    {
        if(!GetButtonCountControl(!_isCharacterSpeedBoost)) return;
        _isCharacterSpeedBoost = !_isCharacterSpeedBoost;
        EventManager.TriggerEvent(EventTags.CHARACTER_SPEED_BOOST, _isCharacterSpeedBoost);
        ButtonColorChanged(_characterSpeedBoostImage, _isCharacterSpeedBoost);
    }
    

    #endregion
    
    #region ACTIONS

    #endregion
}

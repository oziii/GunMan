using System;
using System.Collections;
using System.Collections.Generic;
using OziLib;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Ammo _ammo;
    [SerializeField] private WeaponSO _weaponSo;
    private float _fireRate;
    private float _lastFire;

    private bool _isThreeAmmo;
    private bool _isTwoAmmo;
    private bool _isFireRateBoost;
    private bool _isAmmoSpeedBoost;
    
    #region UNITY_METHODS

    private void OnEnable()
    {
        EventManager.StartListening(EventTags.THREE_AMMO, onThreeAmmo);
        EventManager.StartListening(EventTags.TWO_AMMO, onTwoAmmo);
        EventManager.StartListening(EventTags.FIRE_RATE_BOOST, onFireRateBoost);
        EventManager.StartListening(EventTags.AMMO_SPEED_BOOST, onAmmoSpeedBoost);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventTags.THREE_AMMO, onThreeAmmo);
        EventManager.StopListening(EventTags.TWO_AMMO, onTwoAmmo);
        EventManager.StopListening(EventTags.FIRE_RATE_BOOST, onFireRateBoost);
        EventManager.StopListening(EventTags.AMMO_SPEED_BOOST, onAmmoSpeedBoost);  
    }

    #endregion
    
    #region METHODS

    public void Fire()
    {
        _fireRate = _isFireRateBoost ? _weaponSo.FireRateBoost : _weaponSo.FireRate;
        if (Time.time > _fireRate + _lastFire)
        {
            AmmoCreate();
            _lastFire = Time.time;

            if (_isTwoAmmo)
            {
                Invoke(nameof(AmmoCreate), .1f);
            }
        }
    }

    private void AmmoCreate()
    {
        var ammo = Instantiate(_ammo, _spawnPoint.position, Quaternion.LookRotation(_spawnPoint.forward));
        if(_isAmmoSpeedBoost)
            ammo.ShootDir(_spawnPoint.forward, 1.5f);
        else
            ammo.ShootDir(_spawnPoint.forward);
    }

    #endregion

    #region ACTIONS

    private void onFireRateBoost(object arg0)
    {
        if (arg0 is bool isState)
            _isFireRateBoost = isState;
    }

    private void onAmmoSpeedBoost(object arg0)
    {
        if (arg0 is bool isState)
            _isAmmoSpeedBoost = isState;
    }

    private void onTwoAmmo(object arg0)
    {
        if(arg0 is bool isState)
            _isTwoAmmo = isState;
    }

    private void onThreeAmmo(object arg0)
    {
        if(arg0 is bool isState)
            _isThreeAmmo = isState;
    }

    #endregion




    
    
}

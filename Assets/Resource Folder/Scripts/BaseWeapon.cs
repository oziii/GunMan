using System;
using System.Collections;
using System.Collections.Generic;
using OziLib;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _spawnPointLeft;
    [SerializeField] private Transform _spawnPointRight;
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
            AmmoCreate(_spawnPoint);
            _lastFire = Time.time;
            if (_isTwoAmmo)
            {
                StartCoroutine(AmmoCreateDelay(_spawnPoint, _weaponSo.TwoAmmoDelayTime));
            }

            if (!_isThreeAmmo) return;
            AmmoCreate(_spawnPointRight);
            AmmoCreate(_spawnPointLeft);
            
            if (!_isTwoAmmo) return;
            StartCoroutine(AmmoCreateDelay(_spawnPointLeft, _weaponSo.TwoAmmoDelayTime));
            StartCoroutine(AmmoCreateDelay(_spawnPointRight, _weaponSo.TwoAmmoDelayTime));
        }
    }

    private void AmmoCreate(Transform spawnPoint)
    {
        var ammo = Instantiate(_ammo, spawnPoint.position, Quaternion.LookRotation(spawnPoint.forward));
        // var ammoPooledObject = ObjectPooler.SharedInstance.GetPooledObject(EventTags.AMMO_TAG);
        // ammoPooledObject.transform.position = spawnPoint.position;
        // ammoPooledObject.transform.rotation = Quaternion.LookRotation(spawnPoint.forward);
        // var ammo = ammoPooledObject.GetComponent<Ammo>();
        if(_isAmmoSpeedBoost)
            ammo.ShootDir(spawnPoint.forward, _weaponSo.AmmoSpeedBoost);
        else
            ammo.ShootDir(spawnPoint.forward);
    }

    private IEnumerator AmmoCreateDelay(Transform spawnPoint,float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        AmmoCreate(spawnPoint);
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

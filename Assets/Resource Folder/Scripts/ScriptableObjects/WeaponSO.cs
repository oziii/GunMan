using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "SO/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _fireRateBoost;
    [SerializeField] private float _ammoSpeedBoost;
    [SerializeField] private float _twoAmmoDelayTime;
    public float FireRate => _fireRate;

    public float FireRateBoost => _fireRateBoost;

    public float AmmoSpeedBoost => _ammoSpeedBoost;

    public float TwoAmmoDelayTime => _twoAmmoDelayTime;
}

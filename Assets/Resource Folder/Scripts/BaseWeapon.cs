using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Ammo _ammo;

    public void Fire()
    {
        var ammo = Instantiate(_ammo, _spawnPoint.position, Quaternion.LookRotation(_spawnPoint.forward));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoSO _ammoSo;
    private Vector3 _shootDir;
    private Rigidbody _rb;
    private bool _isShoot;

    public void ShootDir(Vector3 shootDir, float shootPower = 1)
    {
        _shootDir = shootDir;
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = false;
        _rb.velocity = Vector3.zero;
        gameObject.SetActive(true);
        var tempPower = _ammoSo.FirePower * shootPower;
        _rb.AddForce(shootDir * Time.fixedDeltaTime * tempPower);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        _rb.isKinematic = true;
        _rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
    }
}

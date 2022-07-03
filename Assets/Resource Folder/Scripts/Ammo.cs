using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoSO _ammoSo;
    [SerializeField] private TrailRenderer _trailRenderer;
    private Rigidbody _rb;
    private bool _isShoot;

    public void ShootDir(Vector3 shootDir, float shootPower)
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = false;
        _rb.velocity = Vector3.zero;
        gameObject.SetActive(true);
        var tempPower = _ammoSo.FirePower * shootPower;
        _trailRenderer.enabled = true;
        _rb.AddForce(shootDir * Time.fixedDeltaTime * tempPower);
        
    }

    private void OnBecameInvisible()
    {
        Invoke(nameof(OnCloseObject), 15f);
        _trailRenderer.enabled = false;
    }

    private void OnCloseObject()
    {
        gameObject.SetActive(false);
        _rb.isKinematic = true;
        _rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
    }
}

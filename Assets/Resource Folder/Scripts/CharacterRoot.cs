using System;
using System.Collections;
using System.Collections.Generic;
using OziLib;
using UnityEngine;

public class CharacterRoot : MonoBehaviour, ITouchPanel
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterSO _characterSO;
    [SerializeField] private TouchPanelController _touchPanelController;
    [SerializeField] private BaseWeapon _baseWeapon;
    private Vector3 _initPos;
    private Vector3 _targetPos;
    private float _refVel;
    private bool _isLevelStart;
    private bool _isRun;
    
    #region UNITY_METHODS

    private void OnEnable()
    {
        EventManager.StartListening(EventTags.LEVEL_START, onLevelStart);
        EventManager.StartListening(EventTags.LEVEL_END, onLevelEnd);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventTags.LEVEL_START, onLevelStart);
        EventManager.StopListening(EventTags.LEVEL_END, onLevelEnd);
    }

    private void Start()
    {
        _touchPanelController ??= FindObjectOfType<TouchPanelController>();
        _touchPanelController.InitPanel(this);
        _initPos = transform.position;
    }

    private void Update()
    {
        if(!_isRun) return;
        // Vertical Movement
        var position = transform.position;
        position += Vector3.forward * _characterSO.VerticalSpeed * Time.deltaTime;

        // Horizontal Movement
        position.x = Mathf.SmoothDamp(transform.position.x, _targetPos.x, ref _refVel, 0.07f);
        transform.position = position;
        
        WeaponFireController();
    }

    #endregion

    #region METHODS

    private void WeaponFireController()
    {
        
        _baseWeapon.Fire();
    }
    
    #endregion

    #region INTERFACES

    public void OnPointDownAction(Vector2 delta)
    {
        _targetPos = transform.position;
        _isRun = true;
    }
    
    public void OnPointUpAction(Vector2 delta)
    {
        _isRun = false;
    }

    public void OnDragAction(Vector2 delta)
    {
        _targetPos.x += delta.x * _characterSO.HorizontalSensitivity;
        _targetPos.x = Mathf.Clamp(_targetPos.x, _initPos.x - _characterSO.PlayerHorizontalClamp, _initPos.x + _characterSO.PlayerHorizontalClamp);
    }

    #endregion


    #region ACTIONS

    
    private void onLevelEnd(object arg0)
    {
        _isLevelStart = false;
    }

    private void onLevelStart(object arg0)
    {
        _isLevelStart = true;
    }

    #endregion
} 

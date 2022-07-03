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

    private int _isRunHash;
    private int _isIdleHash;
    private const string DANCE_NAME = "Chicken Dance";
    
    private float _multiplySpeed = 1f;
    
    #region UNITY_METHODS

    private void OnEnable()
    {
        EventManager.StartListening(EventTags.LEVEL_START, onLevelStart);
        EventManager.StartListening(EventTags.LEVEL_END, onLevelEnd);
        EventManager.StartListening(EventTags.CHARACTER_SPEED_BOOST, onSpeedBoost);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventTags.LEVEL_START, onLevelStart);
        EventManager.StopListening(EventTags.LEVEL_END, onLevelEnd);
        EventManager.StopListening(EventTags.CHARACTER_SPEED_BOOST, onSpeedBoost);
    }

    private void Start()
    {
        _touchPanelController ??= FindObjectOfType<TouchPanelController>();
        _touchPanelController.InitPanel(this);
        _initPos = transform.position;
        _isIdleHash = Animator.StringToHash("isIdle");
        _isRunHash = Animator.StringToHash("isRun");
    }

    private void Update()
    {
        if (!_isLevelStart) return;
        if(!_isRun) return;
        // Vertical Movement
        var position = transform.position;
        position += Vector3.forward * _characterSO.VerticalSpeed * _multiplySpeed * Time.deltaTime;

        // Horizontal Movement
        position.x = Mathf.SmoothDamp(transform.position.x, _targetPos.x, ref _refVel, 0.07f);
        transform.position = position;
        
        _baseWeapon.Fire();
    }

    #endregion

    #region METHODS

    
    #endregion

    #region INTERFACES

    public void OnPointDownAction(Vector2 delta)
    {
        _targetPos = transform.position;
        _isRun = true;
        _animator.SetBool(_isRunHash, true);
        _animator.SetBool(_isIdleHash, false);
    }
    
    public void OnPointUpAction(Vector2 delta)
    {
        _isRun = false;
        _animator.SetBool(_isRunHash, false);
        _animator.SetBool(_isIdleHash, true);
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
        _animator.CrossFadeInFixedTime(DANCE_NAME, .2f);
    }

    private void onLevelStart(object arg0)
    {
        _isLevelStart = true;
    }
    
    private void onSpeedBoost(object arg0)
    {
        if (arg0 is not bool isState) return;
        _multiplySpeed = isState ? _characterSO.VerticalSpeedBoost : 1f;
    }
    
    #endregion
} 

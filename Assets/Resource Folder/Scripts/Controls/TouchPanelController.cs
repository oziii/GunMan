using System;
using System.Collections;
using System.Collections.Generic;
using OziLib;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ITouchPanel
{
    void OnPointDownAction(Vector2 delta);
    void OnPointUpAction(Vector2 delta);
    void OnDragAction(Vector2 delta);
}

public class TouchPanelController : MonoBehaviour, IPointerDownHandler,IPointerUpHandler ,IDragHandler
{
    [NonSerialized] private ITouchPanel _delegate;
    
    private Vector2 _deltaDrag;
    private bool _isFirstTouchScreen;
    private void LateUpdate()
    {
        _deltaDrag = Vector2.zero;
    }

    public void InitPanel(ITouchPanel panel)
    {
        _delegate = panel;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _delegate?.OnPointDownAction(eventData.delta);
        if (_isFirstTouchScreen) return;
        _isFirstTouchScreen = true;
        EventManager.TriggerEvent(EventTags.LEVEL_START, this);
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        _delegate?.OnPointUpAction(eventData.delta);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _deltaDrag = new Vector2(eventData.delta.x / Screen.width, eventData.delta.y / Screen.height);
        
        _delegate?.OnDragAction(_deltaDrag);
    }
}

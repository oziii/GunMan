using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    public virtual void ShowUI()
    {
        gameObject.SetActive(true);
    }

    public virtual void ShowUI<T>(T data)
    {
        gameObject.SetActive(true);
    }

    public virtual void UpdateUI()
    {
        
    }

    public virtual void UpdateUI<T>(T data)
    {
        
    }
    
    public virtual void CloseUI()
    {
        gameObject.SetActive(false);
    }

}

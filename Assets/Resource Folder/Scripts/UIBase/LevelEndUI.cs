using System.Collections;
using System.Collections.Generic;
using OziLib;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndUI : UIBase
{
    #region BUTTON_METHODS

    public void OnClickRestartButton()
    {
        EventManager.TriggerEvent(EventTags.NEXT_LEVEL, this);
    }

    #endregion
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtons : MonoBehaviour
{
    [SerializeField]
    private List<MoveButton> buttons;

    public void SetToggles(MoveButton moveButton)
    {
        if (moveButton.ToggleIsOn)
        {
            this.buttons.ForEach(t => { t.UnselecteButton(); t.ToggleIsOn = false; });
            moveButton.SelectButton();
        }
        else
        {
            moveButton.UnselecteButton();
        }
    }

    [ContextMenu("收集按钮")]
    private void CollectButtons()
    {
        this.buttons = new List<MoveButton>();
        this.buttons.AddRange(this.GetComponentsInChildren<MoveButton>());
    }
}

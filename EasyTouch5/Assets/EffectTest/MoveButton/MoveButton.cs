using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    [SerializeField]
    private Transform button;
    [SerializeField]
    private ETCTouchPad touchPad;
    [SerializeField, Range(0f, 10f)]
    private float valueThreshold = 1f;
    [SerializeField, Range(0f, 10f)]
    private float speedThreshold = 1f;
    private Tweener tweener;

    public void SelectButton()
    {
        Debug.LogFormat("<><MoveButton.SelectButton>axisValue: {0}, axisSpeedValue: {1}", this.touchPad.axisX.axisValue, this.touchPad.axisX.axisSpeedValue);
        // if (Mathf.Abs(this.touchPad.axisX.axisValue) < Mathf.Abs(this.valueThreshold) &&
        //     Mathf.Abs(this.touchPad.axisX.axisSpeedValue) < Mathf.Abs(this.speedThreshold))
        //     return;
        if (Mathf.Abs(this.touchPad.axisX.axisValue) < Mathf.Abs(this.valueThreshold))
            return;

        if (this.tweener != null)
            this.tweener.Kill();
        this.tweener = this.button.DOLocalMoveX(-20f, 0.5f);
    }

    public void UnselecteButton()
    {
        Debug.LogFormat("<><MoveButton.UnselecteButton>axisValue: {0}, axisSpeedValue: {1}", this.touchPad.axisX.axisValue, this.touchPad.axisX.axisSpeedValue);
        // if (Mathf.Abs(this.touchPad.axisX.axisValue) < Mathf.Abs(this.valueThreshold) &&
        //     Mathf.Abs(this.touchPad.axisX.axisSpeedValue) < Mathf.Abs(this.speedThreshold))
        //     return;
        if (Mathf.Abs(this.touchPad.axisX.axisValue) < Mathf.Abs(this.valueThreshold))
            return;

        if (this.tweener != null)
            this.tweener.Kill();
        this.tweener = this.button.DOLocalMoveX(0f, 0.5f);
    }
}

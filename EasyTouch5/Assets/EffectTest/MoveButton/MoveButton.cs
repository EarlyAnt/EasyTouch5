using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    [SerializeField]
    private Transform button;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private ETCTouchPad touchPad;
    [SerializeField, Range(0f, 200f)]
    private float distance = 100f;
    [SerializeField, Range(0f, 10f)]
    private float valueThreshold = 1f;
    [SerializeField, Range(0f, 10f)]
    private float speedThreshold = 1f;
    private Sequence sequence;
    private float timer;

    public void SelectButton()
    {
        Debug.LogFormat("<><MoveButton.SelectButton>axisValue: {0}, axisSpeedValue: {1}", this.touchPad.axisX.axisValue, this.touchPad.axisX.axisSpeedValue);

        if (Mathf.Abs(this.touchPad.axisX.axisValue) < Mathf.Abs(this.valueThreshold))
            return;

        DOTween.KillAll();
        this.button.DOLocalMoveX(-this.distance, 0.5f);
        DOTween.To(() => this.timer, x => this.timer = x, 1f, 0.2f).onComplete += () =>
        {
            this.icon.DOFade(1f, 0.3f);
            this.icon.transform.DOScale(Vector3.one, 0.3f);
        };
    }

    public void UnselecteButton()
    {
        Debug.LogFormat("<><MoveButton.UnselecteButton>axisValue: {0}, axisSpeedValue: {1}", this.touchPad.axisX.axisValue, this.touchPad.axisX.axisSpeedValue);

        if (Mathf.Abs(this.touchPad.axisX.axisValue) < Mathf.Abs(this.valueThreshold))
            return;

        DOTween.KillAll();
        this.icon.DOFade(0f, 0.2f);
        this.icon.transform.DOScale(Vector3.zero, 0.2f);
        this.button.DOLocalMoveX(0, 0.3f);
    }
}

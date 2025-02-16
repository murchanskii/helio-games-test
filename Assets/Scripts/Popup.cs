using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System;

public class Popup : MonoBehaviour
{
    [SerializeField]
    private RectTransform _rectTransform;

    [field: SerializeField]
    public UnityEvent aboutToShow { get; private set; }
    [field: SerializeField]
    public UnityEvent showed { get; private set; }
    [field: SerializeField]
    public UnityEvent aboutToHide { get; private set; }
    [field: SerializeField]
    public UnityEvent hid { get; private set; }

    private float _showDuration = 0.2f;
    private float _hideDuration = 0.2f;

    protected void OnEnable()
    {
        _rectTransform.localScale = Vector3.zero;
    }

    public void Show()
    {
        aboutToShow?.Invoke();
        _rectTransform.DOScale(1.0f, _showDuration).SetEase(Ease.OutBack).OnComplete(() => showed?.Invoke());
    }

    public void Hide()
    {
        aboutToHide?.Invoke();
        _rectTransform.DOScale(0.0f, _hideDuration).SetEase(Ease.InBack).OnComplete(() => hid?.Invoke());
    }
}

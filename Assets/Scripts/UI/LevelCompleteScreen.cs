using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class LevelCompleteScreen : MonoBehaviour
{
    [SerializeField] private LevelCompleteText _levelCompleteText;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _delayBeforeClosing;
    [SerializeField] private float _showingDuration;

    public UnityAction Closed;

    public void Show()
    {
        _canvasGroup.DOFade(1, _showingDuration);
        _levelCompleteText.PlayAnimation();
        StartCoroutine(Close());
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(_delayBeforeClosing);
        Closed?.Invoke();
    }
}
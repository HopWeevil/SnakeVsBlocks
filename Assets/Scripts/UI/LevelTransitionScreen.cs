using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelTransitionScreen : MonoBehaviour
{
    [SerializeField] private Image _transitionScreen;
    [SerializeField] private float _showingDuration;

    public event UnityAction LevelTransitionComplete;

    public void StartTransition()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_transitionScreen.DOFade(1f, _showingDuration));
        sequence.OnComplete(LevelTransitionComplete.Invoke);
        sequence.SetLink(gameObject);
        sequence.Play();
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelMarker : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _scaleAmount;
    [SerializeField] private float _animationDuration;

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = _image.rectTransform.localScale;
    }

    public void SetLevelNumber(int levelNumber)
    {
        _text.text = levelNumber.ToString();
    }

    public void PlayAnimation(Color color)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_image.rectTransform.DOScale(originalScale * _scaleAmount, _animationDuration));
        sequence.Append(_image.rectTransform.DOScale(originalScale, _animationDuration));
        sequence.Play();
        _image.DOColor(color, _animationDuration);
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Block))]
public class BlockView : MonoBehaviour
{
    [SerializeField] private TMP_Text _fillAmount;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Ease _ease;
    [SerializeField] private float _scaleModifier;
    [SerializeField] private float _scaleDuration;
    [SerializeField] private float _gradientStartValue;

    private Block _block;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _startScale;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _block = GetComponent<Block>();
        Initialize();
    }

    private void OnEnable()
    {
        _block.FillingUpdated += OnFillingUpdated;
    }

    private void OnDisable()
    {
        _block.FillingUpdated -= OnFillingUpdated;
    }

    private void Initialize()
    {
        _startScale = transform.localScale;
        _fillAmount.text = _block.LeftToFill.ToString();
        SetGradientColor(_block.LeftToFill);
    }

    private void OnFillingUpdated(int leftToFill)
    {
        _fillAmount.text = leftToFill.ToString();
        SetGradientColor(leftToFill);
        PlayScaleEffect();
    }

    private void SetGradientColor(int filling)
    {
        float valueColor = (_gradientStartValue / _block.MaxDestroyPrice) * filling;
        _spriteRenderer.color = _gradient.Evaluate(valueColor);
    }

    private void PlayScaleEffect()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.SetEase(_ease);
        sequence.Append(transform.DOScale(_startScale * _scaleModifier, _scaleDuration));
        sequence.Append(transform.DOScale(_startScale, _scaleDuration));
        sequence.SetLink(gameObject);
        sequence.Play();
    }
}
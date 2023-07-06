using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LevelCompleteText : MonoBehaviour
{
    [SerializeField] private float _scaleModifier;
    [SerializeField] private float _duration;
    [SerializeField] private Ease _ease;

    private TMP_Text _text;
    private Vector3 _startScale;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _startScale = _text.rectTransform.localScale;
    }

    public void PlayAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.SetEase(_ease);
        sequence.Append(transform.DOScale(_startScale * _scaleModifier, _duration));
        sequence.Append(transform.DOScale(_startScale, _duration));
        sequence.Play();
    }
}
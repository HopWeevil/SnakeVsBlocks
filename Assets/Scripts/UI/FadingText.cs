using UnityEngine;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class FadingText : MonoBehaviour
{
    [SerializeField] private Ease _ease;
    [SerializeField] private float _duration;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void StartFading()
    {
        Sequence sequence =  DOTween.Sequence();
        sequence.SetEase(_ease);
        sequence.Append(_text.DOFade(0, _duration));
        sequence.Append(_text.DOFade(1, _duration));
        sequence.SetLoops(-1);
        sequence.SetLink(gameObject);
        sequence.Play();
    }
}
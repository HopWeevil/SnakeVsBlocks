using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;

public class StartGameScreen : MonoBehaviour
{
    [SerializeField] private FadingText _startGameText;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _showingDuration;

    public UnityAction StartButtonClick;

    private void OnEnable()
    {
        _startGameButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnDisable()
    {
        _startGameButton.onClick.AddListener(OnStartButtonClicked);
    }

    public void Hide()
    {
        _canvasGroup.DOKill();
        _canvasGroup.alpha = 0;
        _startGameButton.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void Show()
    {
        _canvasGroup.DOFade(1, _showingDuration);
        _startGameText.StartFading();
        _canvasGroup.blocksRaycasts = true;

    }

    private void OnStartButtonClicked()
    {
        StartButtonClick?.Invoke();
    }
}
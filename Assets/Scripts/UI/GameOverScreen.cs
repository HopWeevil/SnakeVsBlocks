using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private FadingText _restartGameText;
    [SerializeField] private float _showingDuration;

    public UnityAction RestartButtonClick;

    private void OnEnable()
    {
        _restartGameButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void OnDisable()
    {
        _restartGameButton.onClick.AddListener(OnRestartButtonClicked);
    }

    public void Show()
    {
        _restartGameText.StartFading();
        _canvasGroup.DOFade(1, _showingDuration).SetLink(gameObject);
        _restartGameButton.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    private void OnRestartButtonClicked()
    {
        RestartButtonClick?.Invoke();
    }
}
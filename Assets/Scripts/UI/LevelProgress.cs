using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private LevelMarker _currentLevelMarker;
    [SerializeField] private LevelMarker _nextLevelMarker;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Image _progressBar;
    [SerializeField] private Transform _snakeHead;
    [SerializeField] private Transform _finishLine;

    [SerializeField] private float _showingDuration;

    public void SetLevelNumbers(int currentLevel)
    {
        _currentLevelMarker.SetLevelNumber(currentLevel);
        _nextLevelMarker.SetLevelNumber(currentLevel + 1);
    }

    public void Show()
    {
        _canvasGroup.DOFade(1, _showingDuration);
    }
 
    private void Update()
    {
        UpdateProgressBar();
    }

    public void UpdateProgressBar()
    {       
        float progress = _snakeHead.position.y / _finishLine.transform.position.y;
        _progressBar.fillAmount = progress;
    }

    public void PlayMarkerAnimation()
    {
        _nextLevelMarker.PlayAnimation(_progressBar.color);
    }
}
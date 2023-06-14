using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    [SerializeField] private int _targetFps;

    private void Awake()
    {
        Application.targetFrameRate = _targetFps;
    }
}

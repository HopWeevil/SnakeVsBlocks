using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    [SerializeField] private float _originalScreenWidth;
    [SerializeField] private float _originalScreenHeight;

    private float _desiredWidth;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _desiredWidth = _camera.orthographicSize * (_originalScreenWidth / _originalScreenHeight);
        _camera.orthographicSize = _desiredWidth / _camera.aspect;
    }
}

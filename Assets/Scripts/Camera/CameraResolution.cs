using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    [SerializeField] private float originalScreenWidth;
    [SerializeField] private float originalScreenHeight;

    private float _desiredWidth;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _desiredWidth = _camera.orthographicSize * (originalScreenWidth / originalScreenHeight);
        _camera.orthographicSize = _desiredWidth / _camera.aspect;
    }
}

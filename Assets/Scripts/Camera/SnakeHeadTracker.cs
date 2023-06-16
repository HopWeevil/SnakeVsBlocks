using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadTracker : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private float _speed;

    private float _offsetY;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _offsetY = _camera.orthographicSize * _camera.aspect;
    }

    private void Update()
    { 
        _camera.transform.position = Vector3.Lerp(transform.position, GetTargetPosition(), _speed * Time.deltaTime);
    }

    private Vector3 GetTargetPosition()
    {
        return new Vector3(transform.position.x, _snakeHead.transform.position.y +  _offsetY, transform.position.z);
    }
}

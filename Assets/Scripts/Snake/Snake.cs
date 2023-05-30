using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(SnakeInput))]
[RequireComponent (typeof(TailGenerator))]
public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _head;
    [SerializeField] private float _speed;
    [SerializeField] private float _tailSpringiness;

    private List<Segment> _tail;
    private SnakeInput _input;
    private TailGenerator _tailGenerator;

    private void Awake()
    {
        _input = GetComponent<SnakeInput>();
        _tailGenerator = GetComponent<TailGenerator>();
        _tail = _tailGenerator.Generate();
    }

    private void FixedUpdate()
    {
        Move(_head.transform.position + _head.transform.up * _speed * Time.fixedDeltaTime);

        _head.transform.up = _input.GetDirectionToClick(_head.transform.position);
    }

    private void Move(Vector3 nextPosition)
    {
        Vector3 previousPosition = _head.transform.position;

        foreach (var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector2.Lerp(segment.transform.position, previousPosition, _tailSpringiness * Time.fixedDeltaTime);
            previousPosition = tempPosition;
        }

        _head.Move(nextPosition);
    }

}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SnakeInput))]
public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _head;
    [SerializeField] private SnakeTail _snakeTail;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] [Min(1)] private int _startTailSize;

    private SnakeInput _input;

    public event UnityAction<int> SizeUpdated;

    private void Start()
    {
        _input = GetComponent<SnakeInput>();
        _snakeTail.AddSegments(_startTailSize);
        SizeUpdated?.Invoke(_snakeTail.Size);
    }

    private void OnEnable()
    {
        _head.BlockCollided += OnBlockCollided;
        _head.BonusCollected += OnBonusCollected;
    }

    private void OnDisable()
    {
        _head.BlockCollided -= OnBlockCollided;
        _head.BonusCollected -= OnBonusCollected;
    }

    private void Update()
    {
        _snakeTail.FollowHead(_head);
    }

    private void FixedUpdate()
    {
        _head.Move(_input.GetHorizontalDirection(), _horizontalSpeed, _forwardSpeed);
    }

    private void OnBlockCollided()
    {
        _snakeTail.DeleteSegment();
        SizeUpdated?.Invoke(_snakeTail.Size);
    }

    private void OnBonusCollected(int bonusSize)
    {
        _snakeTail.AddSegments(bonusSize);
        SizeUpdated?.Invoke(_snakeTail.Size);
    }
}

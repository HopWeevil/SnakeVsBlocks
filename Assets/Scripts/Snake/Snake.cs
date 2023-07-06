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
    [SerializeField] [Min(1)] private int _defaultTailSize;

    private SnakeInput _input;

    public int DefaultTailSize => _defaultTailSize;
    public int CurrentSize => _snakeTail.Size;

    public event UnityAction<int> SizeUpdated;
    public event UnityAction Died;

    private void Start()
    {
        _input = GetComponent<SnakeInput>();
    }

    public void Initializate(int snakeSize)
    {
        _snakeTail.AddSegments(snakeSize);
        SizeUpdated?.Invoke(snakeSize);
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

        if (_snakeTail.Size == 0)
        {
            Die();
        }
    }

    private void OnBonusCollected(int bonusSize)
    {
        _snakeTail.AddSegments(bonusSize);
        SizeUpdated?.Invoke(_snakeTail.Size);
    }

    private void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}

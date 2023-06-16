using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [SerializeField] private Segment _segmentTemplate;
    [SerializeField] private float _distanceBetweenSegments;

    private List<Segment> _tail = new List<Segment>();

    public int Size => _tail.Count;

    public void FollowHead(SnakeHead head)
    {
        Vector3 previousPosition = head.transform.position;

        for (int i = 0; i < _tail.Count; i++)
        {
            Vector3 direction = _tail[i].transform.position - previousPosition;

            if (direction.magnitude > _distanceBetweenSegments)
            {
                _tail[i].transform.position = previousPosition + direction.normalized * _distanceBetweenSegments;

            }
            previousPosition = _tail[i].transform.position;
        }
    }

    public void AddSegments(int segmentAmount)
    {
        for (int i = 0; i < segmentAmount; i++)
        {
            Segment segment = Instantiate(_segmentTemplate, GetSegmentSpawnPoint(), Quaternion.identity, transform);
            _tail.Add(segment);
        }
    }

    private Vector2 GetSegmentSpawnPoint()
    {
        if (Size > 0)
        {
            return _tail[Size - 1].transform.position;
        }
        return transform.position;
    }

    public void DeleteSegment()
    {
        Segment segment = _tail[_tail.Count - 1];
        _tail.Remove(segment);
        Destroy(segment.gameObject);
    }
}

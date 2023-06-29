using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeHead : MonoBehaviour
{
    [SerializeField] private float collisionDelay;

    private Rigidbody2D _rigidbody2D;
    private bool canCollide = true;

    public event UnityAction BlockCollided;
    public event UnityAction<int> BonusCollected;
    public event UnityAction FinishReached;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalDirection, float sidewaysSpeed, float speed)
    {
        _rigidbody2D.velocity = new Vector2(horizontalDirection * sidewaysSpeed, speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canCollide)
        {
            if (collision.gameObject.TryGetComponent(out Block block))
            {
                BlockCollided?.Invoke();
                block.Fill();
                StartCoroutine(SetCollisionDelay());
               
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bonus bonus))
        {
            BonusCollected?.Invoke(bonus.Collect());
        }
        if (collision.gameObject.TryGetComponent(out FinishLine finishLine))
        {
            FinishReached?.Invoke();
            finishLine.PlayFinishEffect();
        }
    }

    private IEnumerator SetCollisionDelay()
    {
        canCollide = false;
        yield return new WaitForSeconds(collisionDelay);
        canCollide = true;
    }
}

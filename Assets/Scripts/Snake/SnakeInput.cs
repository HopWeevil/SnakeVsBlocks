using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    public float GetHorizontalDirection()
    {
        float horizontalDirection = 0f;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float deltaPositionX = touch.deltaPosition.x;
                horizontalDirection = Mathf.Clamp(deltaPositionX, -1f, 1f);           
            }
        }
        return horizontalDirection;
    }
}

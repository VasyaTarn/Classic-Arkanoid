using UnityEngine;

public class PlatformModel
{
    public float Direction { get; set; }
    public float Speed { get; set; } = 5f;

    public Vector2 StartPosition { get; set; }

    private float _minX = -2f;
    private float _maxX = 2f;

    public float PositionX { get; set; }

    public void Initialize(Collider2D platformCollider)
    {
        float halfPlatformWidth = GetPaddleWidth(platformCollider) / 2f;

        float camHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;

        _minX = -camHalfWidth + halfPlatformWidth;
        _maxX = camHalfWidth - halfPlatformWidth;

        StartPosition = new Vector2(0f, platformCollider.transform.position.y);
        PositionX = StartPosition.x;
    }

    public void Move(float deltaTime)
    {
        float movement = Direction * Speed * deltaTime;
        PositionX = Mathf.Clamp(PositionX + movement, _minX, _maxX);
    }

    public static float GetPaddleWidth(Collider2D collider)
    {
        if (collider is BoxCollider2D box)
        {
            return box.size.x * collider.transform.lossyScale.x;
        }

        return 1f;
    }
}

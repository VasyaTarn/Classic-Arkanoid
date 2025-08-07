using UnityEngine;

public class BallModel
{
    public float Speed { get; set; } = 5f;
    public Vector2 StartPosition { get; set; }

    public Vector2 GetLaunchDirection()
    {
        return new Vector2(Random.Range(-1f, 1f), 1f).normalized;
    }
}

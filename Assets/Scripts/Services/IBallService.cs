using UnityEngine;

public interface IBallService
{
    public void Init(BallView view);

    public void Launch();

    public void OnCollision(Collision2D collision);

    public void EnforceBallSpeed();

    public void ResetPosition();
}

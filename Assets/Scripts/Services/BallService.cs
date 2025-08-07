using UnityEngine;

public class BallService : IBallService
{
    public BallView View { get; private set; }

    [Inject] public BallModel Model { get; private set; }
    [Inject] public DestroyBrickSignal DestroyBrickSignal { get; private set; }
    [Inject] public BallOutOfBoundsSignal BallOutOfBoundsSignal { get; private set; }

    public void Init(BallView view)
    {
        View = view;

        Model.StartPosition = View.gameObject.transform.position;
    }

    public void Launch()
    {
        var dir = Model.GetLaunchDirection();
        View.SetVelocity(dir * Model.Speed);
    }

    public void OnCollision(Collision2D collision)
    {
        string tag = collision.collider.tag.ToLower();

        if (tag == "brick")
        {
            DestroyBrickSignal.Dispatch(collision.gameObject);
        }

        if(tag == "outerzone")
        {
            BallOutOfBoundsSignal.Dispatch();
        }

        View.Force2D();
    }

    public void EnforceBallSpeed()
    {
        Vector2 vel = View.Velocity;

        if (vel.sqrMagnitude > 0.01f)
        {
            View.SetVelocity(vel.normalized * Model.Speed);
        }
    }

    public void ResetPosition()
    {
        View.gameObject.transform.position = Model.StartPosition;
    }
}

using System;
using strange.extensions.mediation.impl;
using UnityEngine;

public class BallView : View
{
    private Rigidbody2D _rb;

    public float Speed => _rb.linearVelocity.magnitude;
    public Vector2 Velocity => _rb.linearVelocity;

    public event Action<Collision2D> OnBallCollision;

    protected override void Awake()
    {
        base.Awake();

        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnBallCollision?.Invoke(collision);
    }

    public void SetVelocity(Vector2 velocity)
    {
        _rb.linearVelocity = velocity;
    }

    public void Force2D()
    {
        var pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        var vel = _rb.linearVelocity;
        _rb.linearVelocity = new Vector2(vel.x, vel.y);
    }
}

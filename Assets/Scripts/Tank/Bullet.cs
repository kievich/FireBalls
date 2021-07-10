using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private bool _canMove;
    private Vector3 _direction;
    private float _speed;

    public void StartMoving(Vector3 direction, float speed)
    {
        _direction = direction;
        _speed = speed;
        _canMove = true;
    }

    private void Update()
    {
        if (_canMove)
            transform.Translate(_direction * _speed);
    }
}

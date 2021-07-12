using System;
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
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        if (_canMove)
            transform.Translate(_direction.normalized * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Obstacle>(out Obstacle obstacle))
        {
            _canMove = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddExplosionForce(500f, transform.position + new Vector3(0, -0.5f, 1), 10f);
            Destroy(gameObject, 2f);
        }

        if (other.TryGetComponent<Block>(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }
    }

}

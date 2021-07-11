using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event Action BulletHit;

    [SerializeField] private ParticleSystemRenderer _blockEffect;
    private Tower _tower;
    private Color _color;

    private void Start()
    {
        _tower = FindObjectOfType<Tower>();
    }

    public void SetMaterial(Material material)
    {
        GetComponent<MeshRenderer>().material = material;
        _color = material.color;
    }


    public void Break()
    {
        Debug.Log(_blockEffect.transform);
        ParticleSystemRenderer blockEffect = Instantiate(_blockEffect, transform.position, GetBlockEffectRotation(), _tower.transform);
        blockEffect.material.color = _color;
        BulletHit?.Invoke();
        Destroy(gameObject);
    }


    private Quaternion GetBlockEffectRotation()
    {
        return Quaternion.Euler(_blockEffect.transform.rotation.eulerAngles.x,
            _tower.transform.rotation.eulerAngles.y,
            _blockEffect.transform.rotation.eulerAngles.z);
    }
}

using UnityEngine;
using DG.Tweening;

public class TankShoot : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _BulletSpeed;
    [SerializeField] private float _recoilDistance;

    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private Transform _muzzleRoot;


    private float timeFromLastShoot;

    private void Start()
    {
        timeFromLastShoot = _delay;
    }

    private void Update()
    {
        timeFromLastShoot += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (timeFromLastShoot >= _delay)
            {
                Shoot();
                timeFromLastShoot = 0;
            }

        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bulletTemplate, _spawnpoint.position, Quaternion.identity);
        bullet.StartMoving(_spawnpoint.position - _muzzleRoot.position, _BulletSpeed);
        transform.DOMoveZ(transform.position.z - _recoilDistance, _delay / 2).SetLoops(2, LoopType.Yoyo);

    }



}

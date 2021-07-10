using UnityEngine;

public class TankShoot : MonoBehaviour
{
    [SerializeField] float _delay;

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
        bullet.StartMoving(_spawnpoint.position - _muzzleRoot.position, 1f);
    }
}

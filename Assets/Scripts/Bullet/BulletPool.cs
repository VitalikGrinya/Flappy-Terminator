using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletZone;

    private Queue<Bullet> _pool;

    private void Awake()
    {
        _pool = new Queue<Bullet>();
    }

    public Bullet GetBullet()
    {
        if(_pool.Count == 0)
        {
            var bullet = Instantiate(_bulletPrefab);
            bullet.transform.parent = _bulletZone;

            return bullet;
        }

        return _pool.Dequeue();
    }

    public void PutBullet(Bullet bullet)
    {
        _pool.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyPool : MonoBehaviour
{
    [SerializeField] private BulletEnemy _bulletPrefab;
    [SerializeField] private Transform _bulletZone;

    private Queue<BulletEnemy> _pool;

    private void Awake()
    {
        _pool = new Queue<BulletEnemy>();
    }

    public BulletEnemy GetBullet()
    {
        if (_pool.Count == 0)
        {
            var bullet = Instantiate(_bulletPrefab);
            bullet.transform.parent = _bulletZone;

            return bullet;
        }

        return _pool.Dequeue();
    }

    public void PutBullet(BulletEnemy bullet)
    {
        _pool.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}

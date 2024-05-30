using System.Collections;
using UnityEngine;

public class BulletEnemyGenerator : MonoBehaviour
{
    [SerializeField] private BulletEnemyPool _bulletPool;

    private int _waitTime = 1;
    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void Spawn()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, 0);

        var bullet = _bulletPool.GetBullet();

        bullet.gameObject.SetActive(true);
        bullet.transform.position = spawnPoint;
    }

    private IEnumerator Shoot()
    {
        var shootingTime = new WaitForSeconds(_waitTime);

        while (true)
        {
            Spawn();
            yield return shootingTime;
        }
    }
}

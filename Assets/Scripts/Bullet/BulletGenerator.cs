using System.Collections;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, 0);

        var bullet = _bulletPool.GetBullet();

        bullet.gameObject.SetActive(true);
        bullet.transform.position = spawnPoint;
    }
}

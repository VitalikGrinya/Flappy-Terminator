using UnityEngine;

public class BulletRemover : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Bullet bullet))
            _bulletPool.PutBullet(bullet);
    }
}

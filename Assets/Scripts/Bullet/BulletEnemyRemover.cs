using UnityEngine;

public class BulletEnemyRemover : MonoBehaviour
{
    [SerializeField] private BulletEnemyPool _pool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out BulletEnemy bullet))
            _pool.PutBullet(bullet);
    }
}

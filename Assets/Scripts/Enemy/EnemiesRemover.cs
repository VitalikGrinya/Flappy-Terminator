using UnityEngine;

public class EnemiesRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out ScoreZone score))
        {
            _pool.PutObject(score);
        }
    }
}
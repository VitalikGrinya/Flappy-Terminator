using System;
using UnityEngine;

public class BulletKiller : MonoBehaviour
{
    private ObjectPool _pool;
    private ScoreZone score;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
            _pool.PutObject(score);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent(out Enemy enemy))
            enemy.gameObject.SetActive(true);
    }
}

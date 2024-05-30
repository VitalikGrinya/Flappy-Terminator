using System.Collections;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool _pool;

    private BulletKiller _bulletKiller;
    private Enemy enemy;


    private void Start()
    {
        StartCoroutine(GenerateZone());
    }

    private IEnumerator GenerateZone()
    {
        var wait = new WaitForSeconds(_delay);

        while(enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, 0);

        var score = _pool.GetObject();

        score.gameObject.SetActive(true);
        score.transform.position = spawnPoint;
    }
}

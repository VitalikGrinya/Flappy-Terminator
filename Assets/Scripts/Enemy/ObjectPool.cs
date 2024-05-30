using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private ScoreZone _prefab;
    [SerializeField] private Transform _zone;

    private Queue<ScoreZone> _pool;

    public IEnumerable<ScoreZone> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<ScoreZone>();
    }

    public ScoreZone GetObject()
    {
        if(_pool.Count == 0)
        {
            var score = Instantiate(_prefab);
            score.transform.parent = _zone;

            return score;
        }

        return _pool.Dequeue();
    }

    public void PutObject(ScoreZone score)
    {
        _pool.Enqueue(score);
        score.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}

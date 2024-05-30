using System;
using UnityEngine;

[RequireComponent(typeof(PlaneMover))]
[RequireComponent(typeof(PlaneCollisionHandler))]
[RequireComponent(typeof(ScoreCounter))]
public class Plane : MonoBehaviour
{
    private PlaneMover _mover;
    private PlaneCollisionHandler _handler;
    private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<PlaneMover>();
        _handler = GetComponent<PlaneCollisionHandler>();
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Ground)
            GameOver?.Invoke();

        if (interactable is Enemy)
            GameOver?.Invoke();

        if(interactable is BulletEnemy)
            GameOver?.Invoke();

        else if (interactable is ScoreZone)
            _scoreCounter.Add();
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
    }
}

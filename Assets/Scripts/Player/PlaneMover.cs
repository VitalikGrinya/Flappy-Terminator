using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlaneMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigitbody2D;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void Start()
    {
        _startPosition = transform.position;
        _rigitbody2D = GetComponent<Rigidbody2D>();

        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigitbody2D.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigitbody2D.velocity = Vector2.zero;
    }
}

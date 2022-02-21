using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    private float _speed = 1;
    private Transform _tr;

    private void Start()
    {
        _tr = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        RandomSpeed();
    }

    private void FixedUpdate()
    {
        Move(_speed);
    }

    public void RandomSpeed()
    {
        _speed =  Random.Range(_minSpeed, _maxSpeed);
    }

    private void Move(float speed)
    {
        _tr.Translate(Vector2.down * speed * Time.fixedDeltaTime);
    }
}

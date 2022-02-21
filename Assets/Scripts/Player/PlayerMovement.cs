using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed = 10;
    [SerializeField] private float _activationDistance = 0.5f;

    private Transform _tr;

    private Vector2 _minScreenPos;
    private Vector2 _maxScreenPos;

    private float _platformWidth;

    void Start()
    {
        _tr = GetComponent<Transform>();

        _minScreenPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        _maxScreenPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        _platformWidth = _tr.GetComponent<BoxCollider2D>().size.x;
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Move();
        }
    }

    private void LateUpdate()
    {
        Vector3 pos = _tr.position;

        if (_tr.position.x > _maxScreenPos.x - _platformWidth/2)
        {
            pos.x = _maxScreenPos.x - _platformWidth / 2;
        }
        else if (_tr.position.x < _minScreenPos.x + _platformWidth / 2)
        {
            pos.x = _minScreenPos.x + _platformWidth / 2;
        }
        _tr.position = pos;
    }

    private void Move()
    {
        Vector2 delta = Input.GetTouch(0).deltaPosition.normalized;

        if (delta.x > _activationDistance)
        {
            _tr.Translate(Vector3.right * delta.x * _horizontalSpeed * Time.fixedDeltaTime);
        }
        else if (delta.x < -_activationDistance)
        {
            _tr.Translate(Vector3.right * delta.x * _horizontalSpeed * Time.fixedDeltaTime);
        }
    }
}

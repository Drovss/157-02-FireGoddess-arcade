using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _maxDistanceFire;

    private Transform _tr;

    private bool _isFire = false;

    private void Start()
    {
        _tr = GetComponent<Transform>();
    }

    private void Update()
    {
        if (_isFire)
        {
            RaycastHit2D hit = Physics2D.Raycast(_tr.position, _tr.up, _maxDistanceFire, _layerMask);

            if (hit.collider != null)
            {
                hit.transform.gameObject.GetComponent<Enemy>().ReturnElement();
            }
        }       
    }

    public void ShootFire()
    {
        _isFire = true;
        _animator.SetBool("IsFire", _isFire);
    }

    public void StopFire()
    {
        _isFire = false;
        _animator.SetBool("IsFire", false);
    }
}

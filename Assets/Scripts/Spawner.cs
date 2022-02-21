using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [Space]
    [SerializeField] private int _poolCount;
    [Space]
    [SerializeField] private Transform _camera;
    [SerializeField] private Vector2 _minSpawnPos;
    [SerializeField] private Vector2 _maxSpawnPos;
    [SerializeField] private int _maxActiveGO;

    [SerializeField] private float _spawnTime;

    private Queue<GameObject> _currentGO = new Queue<GameObject>();

    private void OnEnable()
    {
        Enemy.ReturnElementAction += ReturnGO;
    }

    private void OnDisable()
    {
        Enemy.ReturnElementAction -= ReturnGO;
    }

    private void Start()
    {
        _currentGO.Clear();

        for (int i = 0; i < _poolCount; i++)
        {
            CreateNewGO();
        }
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        if (_spawnTime == 0)
        {
            _spawnTime = 1;
        }

        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);
            Active();
        }
    }      
    
    private void CreateNewGO()
    {
        var GO = Instantiate(_prefab);
        GO.SetActive(false);
        _currentGO.Enqueue(GO);
    }

    public void Active()
    {
        if (_currentGO.Count > 0)
        {
            ActiveGO();
        }
        else
        {
            _poolCount++;
            CreateNewGO();
            ActiveGO();
        }
    }

    private void ActiveGO()
    {
        var GO = _currentGO.Dequeue();
        GO.transform.position = new Vector2( Random.Range(_minSpawnPos.x, _maxSpawnPos.x),
            _camera.position.y + Random.Range(_minSpawnPos.y, _maxSpawnPos.y));
        GO.SetActive(true);
    }

    private void ReturnGO(GameObject GO)
    {
        GO.SetActive(false);
        _currentGO.Enqueue(GO);
    }
}

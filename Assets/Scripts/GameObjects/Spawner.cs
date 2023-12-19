using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private List<GameObject> _objectsPrebabs = new();
    [SerializeField] private List<Transform> _spawnPoints = new();
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_objectsPrebabs);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject result))
            {
                _elapsedTime = 0;
                int index = Random.Range(0, _spawnPoints.Count);
                SetEnemy(result, _spawnPoints[index].position);
            }
        }
    }

    private void SetEnemy(GameObject item, Vector3 spawnPoint)
    {
        item.SetActive(true);
        item.transform.position = spawnPoint;
    }
}
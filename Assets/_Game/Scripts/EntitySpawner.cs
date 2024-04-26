using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [Header("Prefab Settings")]
    
    [SerializeField] GameObject _prefabToSpawn;

    [Tooltip("Does the Object Spawn Multiple Times?")]
    [SerializeField] bool _spawnObjectOnce = false;

    
    [Tooltip("The amount of time in seconds set at one constant that the prefab will spawn in")]
    [SerializeField] int _spawnRate = 0;

    [Tooltip("Is spawn rate random from a range?")]
    [SerializeField] bool _spawnRateIsRandom = false;

    [Tooltip("Lower Constant of the Range")]
    [SerializeField] int _lowerBoundsOfRange = 2;

    [Tooltip("Higher Constant of the Range")]
    [SerializeField] int _higherBoundsOfRange = 10;

    int _spawnRateRandom = 0;

    
    [Header("Transforms Array Settings")]

    [Tooltip("Current selected Tranform that Prefab will spawn at")]
    [SerializeField] int _element = 0;
    
    [Tooltip("Does the prefab spawn at a random point?")]
    [SerializeField] bool _isSpawnRandom = false;

    [SerializeField] Transform[] _transformsArray;

    
    private bool _hasPrefabSpawnedOnce = false;
    private bool _hasTimerBegun = false;

    private void Update()
    {
        if(_spawnObjectOnce == true)
        {
            SpawnPrefabOnce();
        }
        if(_spawnObjectOnce == false)
        {
            if(_hasTimerBegun == false)
            {
                _hasTimerBegun = true;
                _spawnRateRandom = Random.Range(_lowerBoundsOfRange, _higherBoundsOfRange);
                SpawnPrefabMult();
            }
        }
    }

    public void SpawnPrefabOnce()
    {
        if (_hasPrefabSpawnedOnce == false){
           if (_isSpawnRandom == false)
           {
               Instantiate(_prefabToSpawn, _transformsArray[_element]);
               _hasPrefabSpawnedOnce = true;
               Debug.Log("Prefab Spawned");
           }
           else if (_isSpawnRandom == true)
           {
               int _randElement = Random.Range(0, _transformsArray.Length);
               Instantiate(_prefabToSpawn, _transformsArray[_randElement]);
               _hasPrefabSpawnedOnce = true;
               Debug.Log("Prefab Spawned");
            }
        }
    }

    public void SpawnPrefabMult()
    {
        if(_spawnRateIsRandom == true)
        {
            StartCoroutine(SpawnerTimer(_spawnRateRandom));
        }
        if(_spawnRateIsRandom == false)
        {
            StartCoroutine(SpawnerTimer(_spawnRate));
        }
    }

    public IEnumerator SpawnerTimer(int _timer)
    {
        int _timerCurrTime = _timer;
        while(_timerCurrTime > 0)
        {
            Debug.Log("Timer:" + _timerCurrTime);
            yield return new WaitForSeconds(1);
            _timerCurrTime--;

            if(_timerCurrTime == 0)
            {
                if (_isSpawnRandom == false)
                {
                    Instantiate(_prefabToSpawn, _transformsArray[_element]);
                    _hasTimerBegun = false;
                    Debug.Log("Prefab Spawned");
                }
                else if (_isSpawnRandom == true)
                {
                    int _randElement = Random.Range(0, _transformsArray.Length);
                    Instantiate(_prefabToSpawn, _transformsArray[_randElement]);
                    _hasTimerBegun = false;
                    Debug.Log("Prefab Spawned");
                }
            }
        }
    }
}

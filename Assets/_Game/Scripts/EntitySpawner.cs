using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [Header("Prefab Array Settings")]
    [SerializeField] GameObject[] _prefabArray;

    [Header("Transforms Array Settings")]
    [SerializeField] Transform[] _transformsArray;
    [SerializeField] int _index = 0;

    private void Update()
    {
        foreach(GameObject prefab in _prefabArray)
        {
            Instantiate(prefab, _transformsArray[_index]);
        }
    }
}

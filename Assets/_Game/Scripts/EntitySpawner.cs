using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [Header("Prefab Settings")]
    [SerializeField] GameObject _prefabToSpawn;

    [Header("Transforms Array Settings")]
    [SerializeField] Transform[] _transformsArray;
    [Tooltip("Current selected Tranform that Prefab will spawn at")]
    [SerializeField][Range(0,100)] int _element = 0;


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnSpeed = 1f;

    GameObject[] enemyPool;

    void Awake()
    {
        populatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void populatePool()
    {
        enemyPool = new GameObject[poolSize];

        for(int i = 0; i < enemyPool.Length; i++)
        {
            enemyPool[i] = Instantiate(enemyPrefab, transform);
            enemyPool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < enemyPool.Length; i++)
        {
            if(enemyPool[i].activeInHierarchy == false)
            {
                enemyPool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}

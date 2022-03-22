using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCooldownRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(0, 0, 6), enemyPrefab.transform.rotation);
        StartCoroutine(SpawnCooldownRoutine());
    }
}

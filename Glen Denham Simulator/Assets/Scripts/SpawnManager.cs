using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float[] spawnRange = new float[] { 20, 0, 50 };
    private float startDelay = 2;
    private float spawnInterval = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange[0], spawnRange[0]), spawnRange[1], spawnRange[2]);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        GameObject chosenAnimal = animalPrefabs[animalIndex];
        Instantiate(chosenAnimal, spawnPos, chosenAnimal.transform.rotation);
    }
}

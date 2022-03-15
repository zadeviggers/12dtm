using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int animalIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animalIndex += 1;
        if (animalIndex > animalPrefabs.Length -1)
        {
            animalIndex = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GameObject chosenAnimal = animalPrefabs[animalIndex];
            Instantiate(chosenAnimal, gameObject.transform.position, chosenAnimal.transform.rotation);
        }
    }
}

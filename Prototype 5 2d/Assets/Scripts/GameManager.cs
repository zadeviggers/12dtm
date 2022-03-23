using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objects;
    private float spawnRate = 1f;
    private int numberToSpawn = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, objects.Count);
            int i = 0;
            while (i < numberToSpawn)
            {
                i++;
                Instantiate(objects[index]);
            }
        }
    }
}

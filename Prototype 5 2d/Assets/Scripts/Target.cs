using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 16;
    private float xRange = 4;
    private float ySpawnPos = 0;
    public List<ParticleSystem> particles;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void KillMe()
    {
        foreach (ParticleSystem particle in particles)
        {
            Instantiate(particle, transform.position, particle.transform.rotation);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        KillMe();
    }
}

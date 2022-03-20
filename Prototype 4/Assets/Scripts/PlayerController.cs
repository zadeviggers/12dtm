using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject cameraFocusPoint;
    private Rigidbody playerRB;
    private bool hasPowerup = false;
    public float speed;
    public float powerupExplosionStrength;
    public float powerupExplosionRadius;
    public float powerupExplosionUpwardsModifier;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        cameraFocusPoint = GameObject.Find("CameraFocusPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(cameraFocusPoint.transform.forward * speed * forwardInput);
    }

    // Powerups
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }

    // Enemy collisions
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log($"Powerup triggered by {collision.gameObject.name}");
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            enemyRigidBody.AddExplosionForce(powerupExplosionStrength, transform.position, powerupExplosionRadius, powerupExplosionUpwardsModifier, ForceMode.Impulse);
        }
    }
}

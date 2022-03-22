using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject cameraFocusPoint;
    private Rigidbody playerRB;
    public GameObject poweupIndicator;
    private bool hasPowerup = false;
    private bool canUsePowerup = false;
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
        poweupIndicator.transform.position = new Vector3(transform.position.x, 5, transform.position.z);
    }

    // Powerups
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            canUsePowerup = true;
            poweupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    IEnumerator PowerupCooldownRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        canUsePowerup = true;
        poweupIndicator.gameObject.SetActive(true);
    }


    // Enemy collisions
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup && canUsePowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            enemyRigidBody.AddExplosionForce(powerupExplosionStrength, transform.position, powerupExplosionRadius, powerupExplosionUpwardsModifier, ForceMode.Impulse);
            canUsePowerup = false;
            poweupIndicator.gameObject.SetActive(false);
            StartCoroutine(PowerupCooldownRoutine());
        }
    }


}

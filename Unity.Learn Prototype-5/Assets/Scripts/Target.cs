using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManagerScript;
    private float maxSpeed = 16f;
    private float minSpeed = 12f;
    private float maxTorque = 10f;
    private float xRange = 4f;
    private float ySpawnPosition = -3f;
    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(),RandomTorque() , ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
       return Vector3.up* Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPosition);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sensor")
        {
            if (!gameObject.CompareTag("Bad"))
            {
                gameManagerScript.GameOver();
            }
            Destroy(gameObject);
        }   
    }
    private void OnMouseDown()
    {
        if (gameManagerScript.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManagerScript.UpdateScore(pointValue);
        }
    }
}

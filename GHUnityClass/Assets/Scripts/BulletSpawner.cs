using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
     public GameObject prefab;
    public float firingRate;
    public float firingForce = 30.0f;

    private float currentTime = 0.0f;

    public Transform target;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = target.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir,
            rotationSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);


        currentTime += Time.deltaTime;
        if (currentTime >= firingRate)
        {
            Vector3 spawnPosition = transform.position + (transform.forward * 1.5f);
            GameObject obj = GameObject.Instantiate(prefab, transform.position, Quaternion.identity);

            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * firingForce, ForceMode.Impulse);

            currentTime = 0.0f;
        }
    }
}

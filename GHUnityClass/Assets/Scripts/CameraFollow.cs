using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float movementSpeed;
    public float rotationSpeed;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = target.position;

        newPosition = newPosition + (-target.forward * offset.z);
        newPosition.y += offset.y;

        transform.position = Vector3.MoveTowards(transform.position, newPosition,
            movementSpeed * Time.deltaTime);


        Vector3 newDirection = Vector3.RotateTowards(transform.forward, target.forward,
            rotationSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);

    }
}

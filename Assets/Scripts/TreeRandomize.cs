using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRandomize : MonoBehaviour
{
    void Start()
    {
        float randomValuePositionX = Random.Range(-0.5f, 0.5f);
        float randomValuePositionZ = Random.Range(-0.5f, 0.5f);
        float randomValueRotation = Random.Range(0.0f, 360.0f);

        Transform transform = GetComponent<Transform>();

        transform.position = new Vector3 (
            transform.position.x + randomValuePositionX,
            transform.position.y,
            transform.position.z + randomValuePositionZ);

        transform.rotation = Quaternion.Euler(0f, randomValueRotation, 0f);
    }
}

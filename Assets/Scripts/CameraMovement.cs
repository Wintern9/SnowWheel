using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 vec = transform.position;
        vec.z = player.transform.position.z;
        gameObject.transform.position = vec;
    }
}

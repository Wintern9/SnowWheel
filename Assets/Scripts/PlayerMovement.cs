using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveHorizontalSpeed = 3f;
    [SerializeField] private float moveRotationSpeed = 1f;
    [SerializeField] private GameObject PlayerModel;
    private Transform PlayerModelTransform;

    //[SerializeField] private bool ReverseCoordinate = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (PlayerModel == null)
        {
            PlayerModel = GameObject.FindGameObjectWithTag("PlayerModel").gameObject;
        }

        PlayerModelTransform = PlayerModel.GetComponent<Transform>();
    }

    void Update()
    {
        float horizontalInput = GetVectorMovement().x;

        Vector3 movement = transform.up * moveSpeed * Time.deltaTime;

        movement.z = Mathf.Lerp(0f, horizontalInput * moveHorizontalSpeed * Time.deltaTime, 1f);

        rb.MovePosition(rb.position + movement);
    }

    private void ModelRotation(float horizontalInput)
    {
        // Вычисляем конечный угол поворота
        float targetAngle = horizontalInput * 45f;

        // Интерполируем между текущим углом и целевым углом
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        PlayerModelTransform.rotation = Quaternion.Lerp(PlayerModelTransform.rotation, targetRotation, moveRotationSpeed);
    }

    private VectorMovement GetVectorMovement()
    {
        return ButtonControllerPlayer.playerVector;
    }
}

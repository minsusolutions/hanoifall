using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{

    public Rigidbody2D rb2d;

    public float maxSpeed = 10f;
    public float rotationSpeed = 1f;
    public Vector2 movementVector { get; private set; }

    public event Action<int> OnMoveTurret;
    public event Action OnFire;
    public event Action OnRocketFire;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;
        movementVector = Vector2.zero;
    }

    private void FixedUpdate()
    {

        if (movementVector.y != 0 || movementVector.x != 0)
        {
            rb2d.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;

            rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));

        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }


    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Debug.Log("Hello " + value.ReadValue<Vector2>());
        this.movementVector = value.ReadValue<Vector2>();
    }

    public void RotationButtonClicked(int value)
    {
        OnMoveTurret?.Invoke(value);
    }

    public void AButtonClicked()
    {
        OnFire?.Invoke();
    }

    public void BButtonClicked()
    {
        OnRocketFire?.Invoke();
    }
}

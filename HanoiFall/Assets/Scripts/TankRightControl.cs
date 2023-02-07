using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TankRightControl : MonoBehaviour
{
    [SerializeField]
    private TankController tankControl;

    [SerializeField]
    private Transform tankTurretParent;

    [SerializeField]
    private float rotationSpeed = 100f;

    public float rotationValue { get; private set; }

    private void Start()
    {
        rotationValue = 0;
    }

    private void OnEnable()
    {
        tankControl.OnMoveTurret += OnMoveTurret;
        tankControl.OnFire += OnFire;
        tankControl.OnRocketFire += OnRocketFire;
        Debug.Log("Enable tank right control");

    }

    private void OnDisable()
    {
        tankControl.OnMoveTurret -= OnMoveTurret;
        tankControl.OnFire -= OnFire;
        tankControl.OnRocketFire -= OnRocketFire;

        Debug.Log("Disable tank right control");

    }

    private void OnFire()
    {
        Debug.Log("OnFire");
    }

    private void OnRocketFire()
    {
        Debug.Log("OnRocketFire");
    }


    private void FixedUpdate()
    {
        tankTurretParent.Rotate(0, 0, rotationValue * -rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnMoveTurret(int input)
    {
        Debug.Log("OnMoveTurret " + input.ToString());
        Debug.Log("CurrentTurretRotation " + tankTurretParent.rotation);

        this.rotationValue = input;
    }


}

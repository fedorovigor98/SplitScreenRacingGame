using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //private const string HORIZONTAL = "Horizontal";
    //private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private bool isBraking;
    private float currentBrakeForce;
    private float currentSteerAngle;

    enum Player { 
        PLAYER1 = 1, 
        PLAYER2 = 2
    }
    [SerializeField] Player currentPlayer;

    [SerializeField] private Healthbar healthbar;
    [SerializeField] private float maxhp;
    private float currenthp;

    [SerializeField] private float motorForce;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;


    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;

    private void Start()
    {
        currenthp = maxhp;    
    }

    private void FixedUpdate()
    {
        GetInput.WatchKeys(out verticalInput, out horizontalInput, out isBraking, (int) currentPlayer);
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        healthbar.UpdateHealthbar(maxhp, currenthp);
    }

/*    private void GetInput()
    {
        //horizontalInput = Input.GetAxis(HORIZONTAL);
        //verticalInput = Input.GetAxis(VERTICAL);
        if (Input.GetKey(KeyCode.UpArrow))
            verticalInput = 1;
        else if (Input.GetKey(KeyCode.DownArrow))
            verticalInput = -1;
        else
            verticalInput = 0;
        if (Input.GetKey(KeyCode.RightArrow))
            horizontalInput = 1;
        else if (Input.GetKey(KeyCode.LeftArrow))
            horizontalInput = -1;
        else
            horizontalInput = 0;
        isBraking = Input.GetKey(KeyCode.RightShift);
    }
*/

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        if (isBraking)
            currentBrakeForce = brakeForce;
        else
            currentBrakeForce = 0f;

        ApplyBraking();
    }

    private void ApplyBraking()
    {
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        frontRightWheelCollider.brakeTorque = currentBrakeForce;
        backLeftWheelCollider.brakeTorque = currentBrakeForce;
        backRightWheelCollider.brakeTorque = currentBrakeForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider WheelCollider, Transform WheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        WheelCollider.GetWorldPose(out pos, out rot);
        WheelTransform.rotation = rot;
        WheelTransform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        currenthp -= 5;
    }
}

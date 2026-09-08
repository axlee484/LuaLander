using System;
using Unity.VisualScripting;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour, IMovement
{
    [SerializeField] float maxForce = 100f;
    [SerializeField] float maxRotation = 100f;
    private FuelManager fuelManager;
    private float currentForce;
    private float currentRotation;

    public bool IsControlEnabled {get; set;} = true;
    bool isRotationApplied = false;
    public bool IsRotationApplied => isRotationApplied;
    private bool isForceApplied = false;
    public bool IsForceApplied => isForceApplied;
    private Vector2 forceDirection = Vector2.zero;
    private Vector2 rotationDirection = Vector2.zero;  
    private Rigidbody2D body;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        fuelManager = GetComponent<FuelManager>();
        currentForce = maxForce;
        currentRotation = maxRotation;
    }





    public void SlowDown(float intensity)
    {
        var forceDeduction = maxForce*intensity;
        var rotationDeduction = maxRotation*intensity;

        currentForce -= forceDeduction;
        currentRotation -= rotationDeduction;
        if(currentForce < 0) currentForce = 0;
        if(currentRotation < 0) currentRotation = 0;
    }

    public void Boost(float intensity)
    {
        var forceAddition = maxForce*intensity;
        var rotationAddition = maxRotation*intensity;

        currentForce += forceAddition;
        currentRotation += rotationAddition;
        if(currentForce > maxForce) currentForce = maxForce;
        if(currentRotation > maxRotation) currentRotation = maxRotation;
    }

    public void Move(Vector2 direction)
    {
        isForceApplied = true;
        forceDirection = direction;
    }

    public void Rotate(Vector2 direction)
    {
        isRotationApplied = true;
        rotationDirection = direction;
    }

    private void Move()
    {
        if(!IsControlEnabled) return;
        
        if(fuelManager.FuelRemaning <= 0) return;
        if(isForceApplied)
        {
            body.AddForce(currentForce * Time.fixedDeltaTime * forceDirection);
            fuelManager.DepleteFuel(fuelManager.FuelPerSecond*Time.fixedDeltaTime);
            isForceApplied = false;
        }
        if(isRotationApplied)
        {
            body.AddTorque(-rotationDirection.x * currentRotation * Time.fixedDeltaTime);
            fuelManager.DepleteFuel(fuelManager.FuelPerSecondOnRotate*Time.fixedDeltaTime);
            isRotationApplied = false;
        }
    }


    void FixedUpdate()
    {
        Move();
    }
}

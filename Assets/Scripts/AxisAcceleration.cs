using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisAcceleration : MonoBehaviour
{
    public string AxisName = "Vertical";
    public Vector3 Direction = Vector3.forward;
    public Transform RelativeTo;
    public float Acceleration = 1;
    public float SecondsToStop = 1;
    public float MaxSpeed = 20;
    public Rigidbody rb;

    private float deceleration = 0;
    private float speed = 0;
    
    void FixedUpdate()
    {
        float axis = Input.GetAxis(AxisName);

        Vector3 vectorDirection = RelativeTo.TransformDirection(Direction);
        Vector3 vectorAcceleration = getAccelerationVector(axis, vectorDirection);
        Vector3 resultingAcceleration = vectorAcceleration * axisDirection(axis);
        Vector3 resultingVelocity = rb.velocity + resultingAcceleration;
        Vector3 clampedVelocity = Vector3.ClampMagnitude(resultingVelocity, MaxSpeed);
        rb.velocity = clampedVelocity;
        
    }

    private Vector3 getAccelerationVector(float inputValue, Vector3 inputDirection)
    {
        if (Mathf.Abs(inputValue) > 0)
        {
            deceleration = 0;
            speed += Acceleration * Time.deltaTime;
        }
        else if (deceleration == 0)
        {
            deceleration = speed * (1 / SecondsToStop);
        }
        if (deceleration > 0)
        {
            speed -= deceleration * Time.deltaTime;
        }

        speed = Mathf.Clamp(speed, 0, MaxSpeed);

        return removeY(inputDirection) * speed;
    }

    private float axisDirection(float axis)
    {
        if (axis > 0)
        {
            return 1;
        } else
        {
            return -1;
        }
    }

    private Vector3 removeY(Vector3 vector)
    {
        return new Vector3(vector.x, 0, vector.z);
    }

}

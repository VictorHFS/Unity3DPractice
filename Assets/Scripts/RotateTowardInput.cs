using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardInput : MonoBehaviour
{
    public float Velocity = 1;
    public Transform RelativeTo;
    private Rigidbody rb;
    private Vector3 direcao = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        handleClick("Left", -RelativeTo.right);
        handleClick("Right", RelativeTo.right);
        handleClick("Up", RelativeTo.forward);
        handleClick("Down", -RelativeTo.forward);

        if (direcao != Vector3.zero && transform.forward != direcao)
        {
            Quaternion rotation = Quaternion.LookRotation(direcao);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Velocity * Time.deltaTime);
        }

        direcao = Vector3.zero;
    }

    void handleClick(string buttonName, Vector3 relativeDirection)
    {
        if (Input.GetButton(buttonName))
        {
            direcao += relativeDirection;
        }
    }

    private Vector3 removeY(Vector3 vector)
    {
        return new Vector3(vector.x, 0, vector.z);
    }
}

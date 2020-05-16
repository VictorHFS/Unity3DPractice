using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantRotateTowardInput : MonoBehaviour
{
    public Transform RelativeTo;
    private Rigidbody rb;
    private Vector3 direcao = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        handleClick("Attack", RelativeTo.forward);

        Debug.DrawLine(this.transform.position, this.transform.position + (direcao * 5), Color.red);

        if (direcao != Vector3.zero && transform.forward != direcao)
        {
            this.transform.rotation = Quaternion.LookRotation(direcao);
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

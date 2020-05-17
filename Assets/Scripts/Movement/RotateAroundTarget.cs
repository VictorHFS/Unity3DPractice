using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RotateAroundTarget : NetworkBehaviour
{
    public float Speed;
    public Transform Player;
    public Transform Target;
    private float horizontal, vertical;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        horizontal += Input.GetAxis("Mouse X") * Speed;
        vertical -= Input.GetAxis("Mouse Y") * Speed;
        vertical = Mathf.Clamp(vertical, -35, 60);

        Target.rotation = Quaternion.Euler(vertical, horizontal, 0);
        Player.rotation = Quaternion.Euler(0, horizontal, 0);

        //transform.LookAt(Target);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPosition : MonoBehaviour
{
    public Transform RelativeTo;
    public Vector3 Offset = Vector3.up;
    void LateUpdate()
    {
        this.transform.position = RelativeTo.position + Offset;
    }
}

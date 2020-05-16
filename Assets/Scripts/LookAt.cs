using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        this.transform.LookAt(Target);
        
    }
}

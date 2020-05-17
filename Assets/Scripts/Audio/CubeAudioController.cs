using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAudioController : MonoBehaviour
{
    public AudioSource ImpactAudios;
    private void OnCollisionEnter(Collision collision)
    {
        ImpactAudios.Play();
    }
}

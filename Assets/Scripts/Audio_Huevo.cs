using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Huevo : MonoBehaviour
{


    public AudioClip Huevo;

    private AudioSource source;

    void Awake()
    {

        source = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(Huevo, 1f);
    }
}
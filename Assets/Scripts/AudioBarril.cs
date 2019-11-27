using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioBarril : MonoBehaviour
{

    public AudioClip Barril;

    private AudioSource source;

    void Awake()
    {

        source = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(Barril, 1f);
    }

}
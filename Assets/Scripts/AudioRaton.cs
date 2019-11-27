using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRaton : MonoBehaviour
{

    public AudioClip raton;

    private AudioSource source;

    void Awake(){

        source = GetComponent<AudioSource>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(raton, 1f);
    }

}
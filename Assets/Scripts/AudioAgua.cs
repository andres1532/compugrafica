using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioAgua : MonoBehaviour {

    public AudioMixerSnapshot SoundIn;
    public AudioMixerSnapshot SoundOut;
    public float bpm = 128;


    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    // Use this for initialization
    void Start () {

        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 32;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SonidoAgua"))
        {
            SoundIn.TransitionTo(m_TransitionIn);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SonidoAgua"))
        {
            SoundOut.TransitionTo(m_TransitionOut);
        }


    }

}

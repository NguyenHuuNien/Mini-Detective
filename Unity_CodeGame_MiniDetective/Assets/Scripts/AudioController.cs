using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Audio_MissAttack()
    {
        _audioSource.clip = _audioClips[0];
        _audioSource.Play();
    }
    public void Audio_Attack1()
    {
        _audioSource.clip = _audioClips[1];
        _audioSource.Play();
    }
    public void Audio_Attack2()
    {
        _audioSource.clip = _audioClips[2];
        _audioSource.Play();
    }
}

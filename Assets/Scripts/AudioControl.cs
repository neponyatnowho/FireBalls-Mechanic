using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] AudioClip _tankHit;
    [SerializeField] AudioClip _pipeHit;   
    [SerializeField] AudioClip _obstacleHit;  
    [SerializeField] private Tank _tank;
    [SerializeField] private Tower _tower;
        
    private AudioSource _audioSorce;

    private void OnEnable()
    {
        _audioSorce = GetComponent<AudioSource>();
        _tank.TankShooted += PlayTankHitSong;
        _tower.PipDestroyed += PlayPipeHitSong;
    }

    private void OnDisable()
    {
        _tank.TankShooted -= PlayTankHitSong;

    }

    private void PlayTankHitSong()
    {
        _audioSorce.clip = _tankHit;
        _audioSorce.Play();
    }

    private void PlayPipeHitSong()
    {
        _audioSorce.clip = _pipeHit;
        _audioSorce.Play();
    }

    private void PlayObstacleHitSong()
    {
        _audioSorce.clip = _obstacleHit;
        _audioSorce.Play();
    }
}

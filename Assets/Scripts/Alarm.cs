using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Door _door;
    [Range(0.0f, 1.0f)] [SerializeField] private float _maxSoundVolume;

    private float _volumeStep = 0.2f;
    private float _zeroSoundVolume = 0.0f;
    private Coroutine _doAlarmJob;

    private void OnEnable()
    {
        _door.Opened += Launch;
    }

    private void OnDisable()
    {
        _door.Opened -= Launch;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public void Launch(bool up)
    {
        StopJob();
        float targetVolume = up ? _maxSoundVolume : _zeroSoundVolume;
        _doAlarmJob = StartCoroutine(DoAlarm(targetVolume));
    }

    private IEnumerator DoAlarm(float targetVolume)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_audioSource.volume != targetVolume)
        {
            var resultVolume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeStep);
            _audioSource.volume = resultVolume;

            yield return waitForOneSeconds;
        }
    }

    private void StopJob()
    {
        if (_doAlarmJob != null)
        {
            StopCoroutine(_doAlarmJob);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [Range(0.0f, 1.0f)] [SerializeField] private float _maxSoundVolume;

    private float _volumeStep = 0.2f;
    private float _zeroSoundVolume = 0.0f;
    private Coroutine _doAlarmJob;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public void Launch(bool isThiefInside)
    {
        if (isThiefInside)
        {
            StopJob();
            _doAlarmJob = StartCoroutine(DoAlarm(_maxSoundVolume));
        }
        else
        {
            StopJob();
            _doAlarmJob = StartCoroutine(DoAlarm(_zeroSoundVolume));
        }
    }

    private IEnumerator DoAlarm(float targetVolume)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        float resultVolume;

        while (_audioSource.volume != targetVolume)
        {
            resultVolume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeStep);
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
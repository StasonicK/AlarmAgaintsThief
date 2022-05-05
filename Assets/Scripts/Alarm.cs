using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [Range(0.0f, 1.0f)] [SerializeField] private float _maxSoundVolume;

    private float _volumeStep = 0.2f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public void LaunchAlarm(bool up)
    {
        StartCoroutine(DoAlarm(up));
    }

    private IEnumerator DoAlarm(bool up)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        if (up)
        {
            while (_audioSource.volume < _maxSoundVolume)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxSoundVolume, _volumeStep);
                yield return waitForOneSeconds;
            }
        }
        else
        {
            while (_audioSource.volume > 0.0f)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0f, _volumeStep);
                yield return waitForOneSeconds;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private int maxSoundVolume;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public void SoundUp()
    {
        StartCoroutine(SoundUpAlarm());
    }

    private IEnumerator SoundUpAlarm()
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        for (int i = 0; i <= maxSoundVolume; i++)
        {
            _audioSource.volume = i * 0.2f;
            yield return waitForOneSeconds;
        }
    }

    public void SoundDown()
    {
        StartCoroutine(SoundDownAlarm());
    }

    private IEnumerator SoundDownAlarm()
    {
        var waitForOneSeconds = new WaitForSeconds(2f);

        for (int i = maxSoundVolume; i >= 0; i--)
        {
            _audioSource.volume = i * 0.2f;
            yield return waitForOneSeconds;
        }
    }
}
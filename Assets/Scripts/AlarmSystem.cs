using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _step;

    private AudioSource _audioSource;

    private int _minVolume = 0;
    private float _currentVolume = 0;
    private bool _isWork;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MovementPlayer>(out MovementPlayer player))
        {
            _isWork = true;
            _currentVolume = _minVolume;

            _audioSource.Play();

            StartCoroutine(ChangeVolume());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MovementPlayer>(out MovementPlayer player))
        {
            _isWork = false;
        }
    }

    private IEnumerator ChangeVolume()
    {
        while (_isWork)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _maxVolume, _step * Time.deltaTime);
            _audioSource.volume = _currentVolume;

            yield return null;
        }

        while (_isWork == false)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _minVolume, _step * Time.deltaTime);
            _audioSource.volume = _currentVolume;

            yield return null;
        }
    }
}

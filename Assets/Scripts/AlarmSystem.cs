using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _step;

    private int _minVolume = 0;
    private float _currentVolume = 0;
    private bool _isWork;

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

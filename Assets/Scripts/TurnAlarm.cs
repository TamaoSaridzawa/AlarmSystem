using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _step;

    private float _minVolume = 0;
    private float _currentVolume = 0;

    private bool _isWork;

    private void Update()
    {
        if (_isWork)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _maxVolume, _step * Time.deltaTime);
            _audioSource.volume = _currentVolume;
        }
        else if (_isWork == false && _currentVolume > _minVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, _maxVolume, _step * -Time.deltaTime);
            _audioSource.volume = _currentVolume;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MovementPlayer>(out MovementPlayer player))
        {
            _isWork = true;
            _currentVolume = _minVolume;

            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MovementPlayer>(out MovementPlayer player))
        {
            _isWork = false;
        }
    }
}

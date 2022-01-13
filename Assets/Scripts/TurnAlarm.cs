using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _startVolume;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _step;
    private float _curretnVolume;

    private bool _isWork;

    private void Update()
    {
        if (_isWork)
        {
            _curretnVolume += Time.deltaTime;
            float normalozing = _curretnVolume / _maxVolume;
            _audioSource.volume = Mathf.MoveTowards(_startVolume, _maxVolume, normalozing);
        }
        else if (_isWork == false && _curretnVolume > _startVolume)
        {
            _curretnVolume -= Time.deltaTime;
            float normalozing = _curretnVolume / _maxVolume;
            _audioSource.volume = Mathf.MoveTowards(_curretnVolume, _startVolume, normalozing);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MovementPlayer>(out MovementPlayer player))
        {
            Debug.Log("Сработал триггер");

            _isWork = true;
            _curretnVolume = _startVolume;

            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MovementPlayer>(out MovementPlayer player))
        {
            _isWork = false;

            Debug.Log("Сработал триггер выхода");
        }
    }
}

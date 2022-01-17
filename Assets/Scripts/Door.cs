using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string IsOpen = "IsOpen";

    private bool _isOpened;

    public bool IsOpened => _isOpened;

    public void Open()
    {
        _animator.SetBool(IsOpen, _isOpened);

        _isOpened = true;
    }

    public void Close()
    {
        _animator.SetBool(IsOpen, _isOpened);

        _isOpened = false;
    }
}

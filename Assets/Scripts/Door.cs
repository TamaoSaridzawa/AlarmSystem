using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private const string IsOpen = "IsOpen";

    [SerializeField] private Animator _animator;

    private bool _isOpened;

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

    public bool IsClosed()
    {
        return _isOpened;
    }
}

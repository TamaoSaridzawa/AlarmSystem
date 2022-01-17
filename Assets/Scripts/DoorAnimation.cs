using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private Camera _playerCamera;

    private RaycastHit _hit;
    private Ray _ray;

    private void Update()
    {
        _ray = _playerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.transform.GetComponent<Door>())
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (_door.IsOpened)
                    {
                        _door.Close();
                    }
                    else
                    {
                        _door.Open();
                    }
                }
            }
        }
    }
}

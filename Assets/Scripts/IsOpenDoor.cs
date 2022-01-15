using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOpenDoor : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    private RaycastHit _hit;
    private Ray _ray;

    private void Update()
    {
        //Ray ray = new Ray(transform.position, transform.forward);
        //Debug.DrawRay(transform.position, transform.forward, Color.red);

        _ray = _playerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.transform.GetComponent<Door>())
            {
                Debug.Log("Дверь найдена");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _hit.transform.GetComponent<Door>().Open();
                }
            }
        }

       
    }
}

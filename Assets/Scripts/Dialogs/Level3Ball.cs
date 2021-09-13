using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Ball : MonoBehaviour
{
    [SerializeField] private GameObject _dialogBall;

    private bool isShown = false;
    private void Update()
    {
        if (_dialogBall.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _dialogBall.gameObject.SetActive(false);
            PlayerController.CanMove = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isShown)
        {
            LoadDialog.IsDialog = true;
            PlayerController.CanMove = false;
            _dialogBall.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isShown = true;
        }
    }
}

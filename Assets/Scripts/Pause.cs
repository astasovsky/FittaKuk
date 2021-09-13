using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    static public bool IsPause;

    public void OnClickYes()
    {
        Time.timeScale = 1;
        IsPause = false;
        SceneManager.LoadScene("Menu");
    }
    public void OnClickNo()
    {
        IsPause = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _pauseMenu.SetActive(false);
    }

    public void DelayToMainMenu(float time)
    {
        Invoke("OnClickYes", time);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsPause == false)
        {
            if (!LoadDialog.IsDialog)
            {
                IsPause = true;
                Time.timeScale = 0;
                _pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                LoadDialog.IsDialog = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && IsPause == true)
        {
            OnClickNo();
        }
    }
}

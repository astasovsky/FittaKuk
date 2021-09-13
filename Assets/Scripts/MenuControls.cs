using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void ExitPressed()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }
    public void SceneChanger(string sceneName)
    {
        SceneTransition.SwitchToScene(sceneName);
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

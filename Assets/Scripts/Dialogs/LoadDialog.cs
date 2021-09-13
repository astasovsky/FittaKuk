using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDialog : MonoBehaviour
{
    [SerializeField] GameObject _button_Y;
    [SerializeField] GameObject _dialog_BG;

    public static bool IsDialog { get; set; }

    Animator animator;
    bool isEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = _button_Y.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter && Input.GetKeyDown(KeyCode.E) && !Pause.IsPause)
        {
            IsDialog = true;
            PlayerController.CanMove = false;
            _dialog_BG.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (_dialog_BG.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _dialog_BG.gameObject.SetActive(false);
            PlayerController.CanMove = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("appearance");
        isEnter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isEnter = false;
        animator.SetTrigger("decay");
    }
}

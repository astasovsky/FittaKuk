using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDialogController : MonoBehaviour
{
    [SerializeField] GameObject[] _images;
    [SerializeField] GameObject _nextPanel;

    int currentImage = 1;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (currentImage < _images.Length)
            {
                _images[currentImage].gameObject.SetActive(true);
                currentImage++;
            }
            else
            {
                animator.SetTrigger("decay");
                foreach (var image in _images)
                {
                    image.gameObject.SetActive(false);
                }
                _nextPanel.gameObject.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                PlayerController.CanMove = true;
            }
        }
    }
    public void OnDacayEnd()
    {
        this.gameObject.SetActive(false);
    }
}

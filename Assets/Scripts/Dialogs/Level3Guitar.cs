using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Guitar : MonoBehaviour
{
    [SerializeField] GameObject _button_Y;

    private Animator animator;
    private bool isEnter = false;

    private void Start()
    {
        animator = _button_Y.GetComponent<Animator>();
    }

    private void Update()
    {
        if (isEnter && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<AudioSource>().Play();
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

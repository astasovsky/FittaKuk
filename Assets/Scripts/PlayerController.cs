using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] private GameObject _steps;

    public static bool CanMove { get; set; } = false;

    protected Rigidbody2D rb;
    protected bool isFacingRight = true;
    protected Animator anim;

    private AudioSource[] _stepsAudio;
    System.Random rand = new System.Random();

    public void OnMakingStep()
    {
        _stepsAudio[rand.Next(_stepsAudio.Length)].Play();
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        _stepsAudio = _steps.GetComponentsInChildren<AudioSource>();

        CanMove = false;
    }
    private void FixedUpdate()
    {
        float move;
        if (CanMove)
        {
            move = Input.GetAxis("Horizontal");
        }
        else
        {
            move = 0;
        }
        rb.velocity = new Vector2(move * _speed, rb.velocity.y);

        if (move != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (move > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (move < 0 && isFacingRight)
            Flip();
    }
    protected void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }
}

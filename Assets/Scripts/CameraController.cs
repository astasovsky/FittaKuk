using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float dumping = 1.5f;
    [SerializeField] float offset_x = 2f;
    [SerializeField] bool isLeft;
    [SerializeField] GameObject Player_m;
    [SerializeField] GameObject Player_w;

    private Transform player;
    private int lastX;

    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;

    public void SetGenderMale()
    {
        player = Player_m.transform;
    }
    public void SetGenderFemale()
    {
        player = Player_w.transform;
    }
    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Start is called before the first frame update
    void Start()
    {
        offset_x = Mathf.Abs(offset_x);
        player = Player_m.transform;
        FindPlayer(isLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX)
            {
                isLeft = false;
            }
            else if (currentX < lastX)
            {
                isLeft = true;
            }
            lastX = Mathf.RoundToInt(player.position.x);
            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(player.position.x - offset_x, transform.position.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset_x, transform.position.y, transform.position.z);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), transform.position.y, transform.position.z);
    }

    public void FindPlayer(bool playerIsLeft)
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerIsLeft)
        {
            transform.position = new Vector3(player.position.x - offset_x, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset_x, transform.position.y, transform.position.z);
        }
    }
}

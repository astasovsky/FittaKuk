using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class PlayerController_TopDown : PlayerController
    {
        private Vector2 moveVelocity;
        private void Update()
        {
            if (CanMove)
            {
                Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                
                //отключение хотьбы вверх вних
                //if (Math.Abs(moveInput.y) > 0 && moveInput.x == 0)
                //{
                //    moveInput.y = 0;
                //}

                moveVelocity = moveInput.normalized * _speed;
                if (moveInput.x > 0 && !isFacingRight)
                    //отражаем персонажа вправо
                    Flip();
                //обратная ситуация. отражаем персонажа влево
                else if (moveInput.x < 0 && isFacingRight)
                    Flip();
            }
            else
            {
                moveVelocity = new Vector2(0, 0);
            }
            if (moveVelocity.x == 0 && moveVelocity.y == 0)
            {
                anim.SetBool("isWalking", false);
            }
            else
            {
                anim.SetBool("isWalking", true);
            }
            
        }
        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            
        }
    }
}

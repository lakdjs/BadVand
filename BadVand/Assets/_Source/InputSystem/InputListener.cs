using Player.Movement;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private Movement _movement;
        private Vector3 _direction;

        public void Constructor(Movement movement)
        {
            _movement = movement;
        }

        private void Update()
        {
            //ReadJump();
            ReadMove();
        }

        private void FixedUpdate()
        {
            
        }

        private void ReadMove()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _movement.Jump();
                if (Input.GetKey(KeyCode.A))
                {
                    float horizontal = Input.GetAxis(Horizontal);
                    Vector3 moveDir = new Vector3(horizontal,0);
                    _movement.Jump();
                    _movement.MoveLeft(moveDir);
                }
                else
                {
                    _movement.MoveRight();
                }
            }
        }

        private void ReadJump()
        {
            
        }
    }
}

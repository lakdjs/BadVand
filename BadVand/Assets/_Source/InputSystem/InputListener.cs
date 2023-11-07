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
            ReadJump();
        }

        private void FixedUpdate()
        {
            ReadMove();
        }

        private void ReadMove()
        {
            if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
            {
                float horizontal = Input.GetAxis(Horizontal);
                Vector3 moveDir = new Vector3(horizontal,0);
                _movement.Move(moveDir);
            }
        }

        private void ReadJump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _movement.Jump();
            }
        }
    }
}

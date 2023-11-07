using UnityEngine;

namespace Player.Movement
{
    public class MovementController 
    {
        private Movement _movement;
        private MovementView _movementView;

        public MovementController(Movement movement, MovementView movementView)
        {
            _movement = movement;
            _movementView = movementView;
        }
        public void Bind()
        {
            _movement.OnMoving += _movementView.UpdateMoving;
            _movement.OnJumping += _movementView.UpdateJumping;
        }

        public void Expose()
        {
            _movement.OnMoving -= _movementView.UpdateMoving;
            _movement.OnJumping -= _movementView.UpdateJumping;
        }
    }
}

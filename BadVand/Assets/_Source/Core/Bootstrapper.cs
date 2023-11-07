using InputSystem;
using Player.Movement;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private MovementView movementView;
        [SerializeField] private Rigidbody2D playerRigidbody;
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        private Movement _movement;
        private MovementController _movementController;
        
        private void Awake()
        {
            StartGame();
        }

        private void StartGame()
        {
            _movement = new Movement(speed,jumpForce, playerRigidbody);
            _movementController = new MovementController(_movement, movementView);
            _movementController.Bind();
            inputListener.Constructor(_movement);
        }
    }
}

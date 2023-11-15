using InputSystem;
using ObstacleSystem;
using Player.Data;
using Player.Movement;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private MovementView movementView;
        [SerializeField] private Rigidbody2D playerRigidbody;
        [SerializeField] private ObstacleCollisionDetector obstacleCollisionDetector;
        [SerializeField] private PlayerData playerData;
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        private Game _game;
        private Movement _movement;
        private MovementController _movementController;
        
        private void Awake()
        {
            _game = new Game();
            StartGame();
        }

        private void StartGame()
        {
            obstacleCollisionDetector.Constructor(_game, playerData);
            _movement = new Movement(speed,jumpForce, playerRigidbody);
            _movementController = new MovementController(_movement, movementView);
            _movementController.Bind();
            inputListener.Constructor(_movement);
        }
    }
}

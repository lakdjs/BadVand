using BonusSystem;
using InputSystem;
using LvlSystem;
using ObstacleSystem;
using Player.Data;
using Player.Movement;
using Player.PlayerCamera;
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
        [SerializeField] private LoseByCamera loseByCamera;
        [SerializeField] private FinishLvl finishLvl;
        private Game _game;
        private Movement _movement;
        private LoseByCamera _loseByCamera;
        private LVL _lvl;
        private void Awake()
        {
            Debug.Log(PlayerPrefs.GetInt("LVL"));
            StartGame();
        }

        private void StartGame()
        {
            _lvl = new LVL(finishLvl);
            _game = new Game(loseByCamera, obstacleCollisionDetector, _lvl);
            _game.Bind();
            obstacleCollisionDetector.Constructor(playerData);
            _lvl.Bind();
            _movement = new Movement(speed,jumpForce, playerRigidbody);
            inputListener.Constructor(_movement);
        }
    }
}

using System;
using LvlSystem;
using ObstacleSystem;
using Player.PlayerCamera;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game
    {
        private LoseByCamera _loseByCamera;
        private ObstacleCollisionDetector _obstacleCollisionDetector;
        private LVL _lvl;
        public Game(LoseByCamera loseByCamera, ObstacleCollisionDetector obstacleCollisionDetector, LVL lvl)
        {
            _loseByCamera = loseByCamera;
            _obstacleCollisionDetector = obstacleCollisionDetector;
            _lvl = lvl; 
        }

        public void Bind()
        {
            _loseByCamera.OnGameLost += Lose;
            _obstacleCollisionDetector.OnGameLost += Lose;
            _lvl.OnLvlCompleted += Win;
        }
        public void Win(bool state)
        {
            Debug.Log("you won");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Lose(bool state)
        {
            Debug.Log("you lost");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

using System;
using Core;
using Player.Data;
using UnityEngine;

namespace ObstacleSystem
{
    public class ObstacleCollisionDetector : MonoBehaviour
    {
        private Game _game;
        private PlayerData _playerData;
        public void Constructor(Game game, PlayerData playerData)
        {
            _game = game;
            _playerData = playerData;
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((_playerData.obstacleMask & (1 << other.gameObject.layer)) != 0)
            {
                _game.Lose();
            }
        }
    }
}

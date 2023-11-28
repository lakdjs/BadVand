using System;
using Core;
using Player.Data;
using UnityEngine;

namespace ObstacleSystem
{
    public class ObstacleCollisionDetector : MonoBehaviour
    {
        public event Action<bool> OnGameLost; 
        private PlayerData _playerData;
        public void Constructor( PlayerData playerData)
        {
            _playerData = playerData;
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((_playerData.obstacleMask & (1 << other.gameObject.layer)) != 0)
            {
                OnGameLost?.Invoke(true);
            }
        }
    }
}

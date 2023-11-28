using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player.PlayerCamera
{
    public class LoseByCamera : MonoBehaviour
    { 
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _camera;
        public event Action<bool> OnGameLost;  
        private bool _isNeedToCheck = true;
        private void Update()
        {
            CheckForLosing();
        }

        private void CheckForLosing()
        {
            if (_player.position.x <= _camera.position.x-18 && _isNeedToCheck)
            {
                _isNeedToCheck = false; 
                OnGameLost?.Invoke(true);
            }
        }
    }
}

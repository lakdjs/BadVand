using System;
using Player.Data;
using UnityEngine;

namespace BonusSystem
{
    public class BonusBigger : MonoBehaviour
    {
        [SerializeField] private LayerMask playerMask;
        private Rigidbody2D _playerRb;
        private Transform _playerTransform;
        private void Awake()
        {
            _playerRb = FindFirstObjectByType<PlayerData>().GetComponent<Rigidbody2D>();
            _playerTransform = FindFirstObjectByType<PlayerData>().gameObject.transform;
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if((playerMask & (1 << other.gameObject.layer)) != 0)
            {
                gameObject.SetActive(false);
                _playerRb.mass++;
                _playerTransform.localScale =
                    new Vector3(_playerTransform.localScale.x + 1, _playerTransform.localScale.x + 1);
            }
        }
    }
}

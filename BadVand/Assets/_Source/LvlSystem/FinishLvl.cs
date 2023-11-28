using System;
using Core;
using Player.Data;
using UnityEngine;

namespace LvlSystem
{
    public class FinishLvl : MonoBehaviour
    {
        public event Action<bool> OnLvlFinished;
        [SerializeField] private LayerMask playerMask;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if((playerMask & (1 << other.gameObject.layer)) != 0)
            {
                OnLvlFinished?.Invoke(true);
            }
        }
    }
}

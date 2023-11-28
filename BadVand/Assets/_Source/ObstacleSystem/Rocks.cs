using System;
using UnityEngine;

namespace ObstacleSystem
{
    public class Rocks : MonoBehaviour
    {
        [SerializeField] private LayerMask playerMask;
        [SerializeField] private Rigidbody2D[] rbs;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if((playerMask & (1 << other.gameObject.layer)) != 0)
            {
                for (int i = 0; i < rbs.Length; i++)
                {
                    rbs[i].gravityScale = 1;
                    rbs[i].mass = 2;
                }
                Destroy(gameObject);
            }
        }
    }
}

using System;
using Interfaces;
using UnityEngine;

namespace ObstacleSystem
{
    public class Saw : MonoBehaviour, IHinderable
    {
        [SerializeField] private float speed;
        private void Update()
        {
            Hinder();
        }

        public void Hinder()
        {
            Cutting();
        }

        private void Cutting()
        {
            transform.Rotate(0,0,speed * Time.deltaTime);
        }
    }
}

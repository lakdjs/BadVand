using System;
using System.Collections.Generic;
using Core;
using UnityEngine;
using Random = System.Random;

namespace ObstacleSystem
{
    public class ObstacleList : MonoBehaviour
    {
        [SerializeField] private List<GameObject> obstacles;
        private Random _random = new Random();
        private void OnEnable()
        {
            ChooseObstacle();
        }

        private void ChooseObstacle()
        {
            int rightObstacle = _random.Next(0, obstacles.Count);
            for(int i = 0; i < obstacles.Count; i++)
            {
                if (i == rightObstacle)
                {
                    obstacles[i].SetActive(true);
                }
                else
                {
                    obstacles[i].SetActive(false);
                }
            }
        }
    }
}

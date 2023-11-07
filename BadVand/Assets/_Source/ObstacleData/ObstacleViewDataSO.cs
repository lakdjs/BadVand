using System.Collections.Generic;
using UnityEngine;

namespace ObstacleData
{
    public class ObstacleViewDataSO : ScriptableObject
    {
        [CreateAssetMenu(menuName = "SO/New Obstacle View Data", fileName = "NewObstacleViewData")]
        public class ResourceViewDataSO : ScriptableObject
        {
            [field: SerializeField] public List<ObstacleViewData> ObstacleViewDatas { get; private set; }
        }
    }
}

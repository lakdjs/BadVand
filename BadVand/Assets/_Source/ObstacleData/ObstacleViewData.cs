using System;
using UnityEngine;

namespace ObstacleData
{
    [Serializable]
    public class ObstacleViewData 
    {
        [field: SerializeField] public ObstacleTypes ObstacleType {get; private set;}
        [field: SerializeField] public Sprite ObstacleIcon {get; private set;}
    }
}

using UnityEngine;

namespace Player.Data
{
    public class PlayerData : MonoBehaviour
    {
        [field: SerializeField] public LayerMask obstacleMask { get; set; }
    }
}

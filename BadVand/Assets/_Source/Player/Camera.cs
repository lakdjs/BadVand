using UnityEngine;

namespace Player
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private Transform player;

        void Update()
        {
            transform.position = new Vector3(player.position.x, player.position.y, -8.236691f);
        }
    }
}

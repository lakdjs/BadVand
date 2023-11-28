using UnityEngine;

namespace Player
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float speed;

        void Update()
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}

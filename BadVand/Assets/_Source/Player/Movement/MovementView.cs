using UnityEngine;

namespace Player.Movement
{
    public class MovementView : MonoBehaviour
    {
        public void UpdateMoving(Vector3 vector3)
        {
            Debug.Log("Moving");
        }

        public void UpdateJumping(float jumpForce)
        {
            Debug.Log("Jumping");
        }
    }
}

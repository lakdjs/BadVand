using System;
using UnityEngine;

namespace Player.Movement
{
    public class Movement 
    {
        public event Action<Vector3> OnMoving; 
        public event Action<float> OnJumping; 
        
        private float _speed;
        private float _jumpForce;
        private Rigidbody2D _rigidbody;
        
        public Movement(float speed, float jumpForce, Rigidbody2D rigidbody)
        {
            _speed = speed;
            _jumpForce = jumpForce;
            _rigidbody = rigidbody;
        }

        public void Move(Vector3 input)
        {
            _rigidbody.AddForce(input * _speed,ForceMode2D.Force);
            OnMoving?.Invoke(input);
        }

        public void Jump()
        {
            _rigidbody.transform.rotation = Quaternion.Euler(0,0,0);
            _rigidbody.AddForce(_rigidbody.transform.up * _jumpForce,ForceMode2D.Impulse);
            OnJumping?.Invoke(_jumpForce);
        }
    }
}

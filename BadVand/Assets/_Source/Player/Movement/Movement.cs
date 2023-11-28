using System;
using UnityEngine;

namespace Player.Movement
{
    public class Movement 
    {
        
        private float _speed;
        private float _jumpForce;
        private Rigidbody2D _rigidbody;
        
        public Movement(float speed, float jumpForce, Rigidbody2D rigidbody)
        {
            _speed = speed;
            _jumpForce = jumpForce;
            _rigidbody = rigidbody;
        }

        public void MoveLeft(Vector3 input)
        {
            _rigidbody.AddForce(input * _speed,ForceMode2D.Force);
        }

        public void MoveRight()
        {
            _rigidbody.AddForce(Vector2.right * _speed,ForceMode2D.Force);
        }

        public void Jump()
        {
            Vector3 newRotation = new Vector3(0, 0, 0);
            _rigidbody.freezeRotation = true;
            _rigidbody.transform.eulerAngles = newRotation;
            _rigidbody.freezeRotation = false;
            _rigidbody.AddForce(_rigidbody.transform.up * _jumpForce,ForceMode2D.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Joystick _joystick;
    private Vector2 _moveInput;
    [SerializeField] private Animator _animator;
    void Update()
    {
        _moveInput = _joystick.Value;

        //if (_moveInput == Vector2.zero)
        //{
        //    _animator.SetBool("Run", false);
        //}
        //else
        //{
        //    _animator.SetBool("Run", true);
        //}

        _animator.SetBool("Run", _joystick.IsPressed);
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_moveInput.x, 0f, _moveInput.y) * _speed;

        if (_rigidbody.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);
        }
    }
}

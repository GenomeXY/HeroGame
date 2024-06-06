using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _playerTransform;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _rotationLerpRate = 3f;

    private float _attackTimer;
    [SerializeField] private float _attackPeriod;
    [SerializeField] private float _dps;

    private PlayerHealth _playerHealth;

    public void Init(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    private void Update()
    {
        if (_playerHealth)
        {
            _attackTimer += Time.deltaTime;
            if (_attackTimer > _attackPeriod)
            {
                _playerHealth.TakeDamage(_dps * _attackPeriod);
                _attackTimer = 0;
            }
        }
    }

    void FixedUpdate()
    {
        if (_playerTransform)
        {
            Vector3 toPlayer = _playerTransform.position - transform.position;

            Quaternion toPlayerRotation = Quaternion.LookRotation(toPlayer, Vector3.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, toPlayerRotation, Time.deltaTime * _rotationLerpRate);

            _rigidbody.velocity = transform.forward * _speed;

            // отзеркаливание позиции (перемещение) врагов, оказавшихся на определенном расстоении от игрока

            if (toPlayer.magnitude > 12f) // если расстояние до игрока больше, то меняем позицию врага, прибавляем 1.9 расстояния до игрока
            {
                transform.position += toPlayer * 1.9f;
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerHealth>() is PlayerHealth playerHealth)
        {
            _playerHealth = playerHealth;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            _playerHealth = null;
        }
    }
}

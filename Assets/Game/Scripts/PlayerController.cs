using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _moveSpeed;
    [Header("References")]
    [SerializeField] private SSO_PlayerInputs _playerInputs;
    [SerializeField] private Rigidbody _rb;

    private void FixedUpdate()
    {
        Vector2 movementDirection = _playerInputs.movement;
        _rb.velocity = new Vector3(movementDirection.x, 0, movementDirection.y) * _moveSpeed;

        Debug.Log(_rb.velocity);
    }
}
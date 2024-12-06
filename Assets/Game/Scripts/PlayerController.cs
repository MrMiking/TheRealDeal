using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _moveSpeed;
    [Header("References")]
    [SerializeField] private PlayerInputs _playerInputs;
    [SerializeField] private Rigidbody _rb;
    [Header("Wrapper")]
    [SerializeField] private RSE_WinEvent RSE_WinEvent;
    [SerializeField] private RSE_DeathEvent RSE_DeathEvent;

    private Vector3 playerSpawnPosition;

    public void RespawnPlayer() => transform.position = playerSpawnPosition;

    private void OnEnable()
    {
        RSE_WinEvent.winEvent += RespawnPlayer;
        RSE_DeathEvent.deathEvent += RespawnPlayer;
    }

    private void OnDisable()
    {
        RSE_WinEvent.winEvent -= RespawnPlayer;
        RSE_DeathEvent.deathEvent -= RespawnPlayer;
    }

    private void Awake()
    {
        playerSpawnPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 movementDirection = _playerInputs.movement.normalized;
        _rb.velocity = new Vector3(movementDirection.x, 0, movementDirection.y) * _moveSpeed;
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private SSO_PlayerInputs _playerInputs;

    private void Awake()
    {
        _inputSystem.BindToInputAction("Horizontal", (x) => { _playerInputs.movement.x = x; });
        _inputSystem.BindToInputAction("Vertical", (y) => { _playerInputs.movement.y = y; });
    }
}
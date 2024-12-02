using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [Header("Settings")]
    public Vector2 movement;
    [Header("References")]
    [SerializeField] private InputSystem _inputSystem;

    private void Awake()
    {
        _inputSystem.BindToInputAction("Horizontal", (x) => { movement.x = x; });
        _inputSystem.BindToInputAction("Vertical", (y) => { movement.y = y; });
    }
}
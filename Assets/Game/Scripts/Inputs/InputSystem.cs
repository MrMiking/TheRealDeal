using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class InputSystem : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputAsset;

    private void Awake()
    {
        inputAsset.Enable();
    }

    public void BindToInputAction(string actionName, Action<float> actionValue)
    {
        var actionFound = null as InputAction;

        foreach (var map in inputAsset.actionMaps)
        {
            foreach (var action in map.actions)
            {
                if (action.name == actionName) actionFound = action;
            }
        }

        if (actionFound != null)
        {
            actionFound.started += (x) => { actionValue.Invoke(x.ReadValue<float>()); };
            actionFound.performed += (x) => { actionValue.Invoke(x.ReadValue<float>()); };
            actionFound.canceled += (x) => { actionValue.Invoke(x.ReadValue<float>()); };
        }
        else
        {
            Debug.LogWarning($"Missing input action : {actionName}");
        }

    }
}
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_WinEvent", menuName = "RSE/RSE_WinEvent")]
public class RSE_WinEvent : BT.ScriptablesObject.RuntimeScriptableEvent
{
    public Action winEvent;
}
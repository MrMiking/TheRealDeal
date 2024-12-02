using BT.ScriptablesObject;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_DeathEvent", menuName = "RSE/RSE_DeathEvent")]
public class RSE_DeathEvent : BT.ScriptablesObject.RuntimeScriptableEvent
{
    public Action deathEvent;
}
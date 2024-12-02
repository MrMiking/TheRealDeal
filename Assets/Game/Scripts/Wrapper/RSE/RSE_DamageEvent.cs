using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RSE_DamageEvent", menuName = "RSE/RSE_DamageEvent")]
public class RSE_DamageEvent : BT.ScriptablesObject.RuntimeScriptableEvent
{
    public Action<int> damageEvent;
}
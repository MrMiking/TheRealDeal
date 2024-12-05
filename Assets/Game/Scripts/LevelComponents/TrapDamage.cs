using UnityEngine;
public class TrapDamage : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int damageInflicted;

    [Header("References")]
    [SerializeField] private RSE_DamageEvent RSE_DamageEvent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Take damage");
            RSE_DamageEvent.damageEvent?.Invoke(damageInflicted);
        }
    }
}
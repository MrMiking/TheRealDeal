using UnityEngine;
public class WinTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RSE_WinEvent RSE_WinEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RSE_WinEvent.winEvent?.Invoke();
        }
    }
}
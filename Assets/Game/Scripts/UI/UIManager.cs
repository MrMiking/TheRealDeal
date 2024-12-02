using TMPro;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RSE_WinEvent RSE_WinEvent;
    [SerializeField] private RSE_DeathEvent RSE_DeathEvent;
    [SerializeField] private RSE_DamageEvent RSE_DamageEvent;

    public int health;

    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject deathScreen;

    private void OnEnable()
    {
        RSE_WinEvent.winEvent += ShowWinScreen;
        RSE_DamageEvent.damageEvent += UISubstractDamage;
        RSE_DeathEvent.deathEvent += ShowDeathScreen;
    }

    private void OnDisable()
    {
        RSE_WinEvent.winEvent -= ShowWinScreen;
        RSE_DamageEvent.damageEvent -= UISubstractDamage;
        RSE_DeathEvent.deathEvent -= ShowDeathScreen;
    }

    private void ShowWinScreen()
    {
        winScreen.SetActive(true);
        RSE_DamageEvent.damageEvent -= UISubstractDamage;
        RSE_DeathEvent.deathEvent -= ShowDeathScreen;
    }

    private void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
        RSE_WinEvent.winEvent -= ShowWinScreen;
        RSE_DamageEvent.damageEvent -= UISubstractDamage;
    }

    private void UISubstractDamage(int damage)
    {
        health -= damage;
    }

    private void Update()
    {
        healthText.text = health.ToString();
    }
}
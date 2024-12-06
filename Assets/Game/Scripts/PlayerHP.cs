using UnityEngine;
public class PlayerHP : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int playerHP;

    [Header("References")]
    [SerializeField] private UIManager uIManager;
    [Space(10)]
    [SerializeField] private RSO_PlayerHP RSO_PlayerHP;
    [Space(10)]
    [SerializeField] private RSE_DeathEvent RSE_DeathEvent;
    [SerializeField] private RSE_WinEvent RSE_WinEvent;
    [SerializeField] private RSE_DamageEvent RSE_DamageEvent;

    private void SetBaseHP() => RSO_PlayerHP.Value = playerHP;

    private void Awake()
    {
        SetBaseHP();
    }

    private void OnEnable()
    {
        RSE_DamageEvent.damageEvent += InflictDamage;
        RSO_PlayerHP.OnChanged += OnHPChange;

        RSE_DeathEvent.deathEvent += SetBaseHP;
        RSE_WinEvent.winEvent += SetBaseHP;
    }

    private void OnDisable()
    {
        RSE_DamageEvent.damageEvent -= InflictDamage;
        RSO_PlayerHP.OnChanged -= OnHPChange;

        RSE_DeathEvent.deathEvent -= SetBaseHP;
        RSE_WinEvent.winEvent -= SetBaseHP;
    }

    private void InflictDamage(int damage)
    {
        RSO_PlayerHP.Value -= damage;
    }

    private void OnHPChange()
    {
        uIManager.UpdateUI();
        if (RSO_PlayerHP.Value <= 0) RSE_DeathEvent.deathEvent?.Invoke();
    }
}
using TMPro;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    [Header("Wrapper")]
    [SerializeField] private RSO_PlayerHP RSO_PlayerHP;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthText.text = RSO_PlayerHP.Value.ToString();
    }
}
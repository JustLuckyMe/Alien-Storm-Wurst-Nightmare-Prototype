using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Text healthText;
    public Text energyText;


    public void UpdateHealthUI(float health)
    {
        healthText.text = "Health: " + health.ToString();
    }

    public void UpdateEnergyUI(float energy)
    {
        energyText.text = "Energy: " + energy.ToString();
    }
}
using UnityEngine;
using UnityEngine.UI;

public class EnergyDashboard : MonoBehaviour
{
    [SerializeField] private EnergySystem energySystem;
    [SerializeField] private Image fillBar;

    private void Start()
    {
        energySystem.OnEnergyChanged += (fillAmount) => fillBar.fillAmount = fillAmount;
    }
}
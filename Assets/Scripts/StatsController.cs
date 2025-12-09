using TMPro;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text EnergyText;

    public static int CurrentEnergy;

    private void OnEnable() => EventManager.OnEnergyCollected += AddEnergy;

    private void OnDisable() => EventManager.OnEnergyCollected -= AddEnergy;

    void AddEnergy(int Energyamount)
    {
        CurrentEnergy += Energyamount;
        EnergyText.text = "Energy : " + CurrentEnergy.ToString();
    }
}

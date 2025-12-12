using System.Collections;
using TMPro;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text EnergyText;
    [SerializeField] TMP_Text BuffDurationText;

    [Header("Stats")]
    [SerializeField] public static float atk = 100;
    [SerializeField] float energyMultiplier = 1;

    public static float CurrentEnergy;

    private void OnEnable() => EventManager.OnEnergyCollected += AddEnergy;

    private void OnDisable() => EventManager.OnEnergyCollected -= AddEnergy;

    void AddEnergy(int Energyamount)
    {
        float energy = Energyamount;    
        CurrentEnergy += energy *energyMultiplier;
        EnergyText.text = "Energy : " + CurrentEnergy.ToString();
    }

    public void ApplyPowerup(PowerupType type, float duration)
    {
        switch (type)
        {
            case PowerupType.SpeedBoost:
                EventManager.RaiseBuffMovementSpeed(10f, 1.5f);
                StartCoroutine(RunUIBuffDuration(duration));
                break;
            case PowerupType.AtkBoost:
                StartCoroutine(AtkBoost(10f, 1.5f));
                StartCoroutine(RunUIBuffDuration(duration));
                break;
            case PowerupType.EnergyBoost:
                StartCoroutine(BoostEnergy(10f, 1.5f));
                StartCoroutine(RunUIBuffDuration(duration));
                break;
        }
    }

    IEnumerator AtkBoost(float duration, float multiplier)
    {
        float baseAtk = atk;
        float BoostedAtk = atk * multiplier;
        atk = BoostedAtk;
        yield return new WaitForSeconds(duration);
        atk = baseAtk;
    }

    IEnumerator BoostEnergy(float duration, float multiplier)
    {
        float baseMultiplier = energyMultiplier;
        float BoostedMultiplier = energyMultiplier * multiplier;
        energyMultiplier = BoostedMultiplier;
        yield return new WaitForSeconds(duration); 
        energyMultiplier = baseMultiplier;
    }

    IEnumerator RunUIBuffDuration(float duration)
    {
        BuffDurationText.text = "Buff Duration: " + duration + "s";
        float t = 0;

        int i=0;
        while(i<duration)
        {
            t += Time.deltaTime;
            if (t > 1f)
            {
                t = 0f;
                i++;
                float passedTime = i;
                BuffDurationText.text = "Buff Duration: " + (duration-passedTime) + "s";
            }
            yield return null;
        }
        BuffDurationText.text = "No Buff applied";
    }
}

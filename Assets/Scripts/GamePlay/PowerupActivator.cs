using System.Collections;
using UnityEngine;

public class PowerupActivator : MonoBehaviour
{
    public PowerupType type;
    public bool readyForBuff;
    public float cooldown=10f;
    public float spdBuffDuration;
    public float atkBuffDuration;
    public float energyBuffDuration;
    private CommandManager _cmdManager;
    private StatsController _statsController;

    private void Awake()
    {
        _cmdManager = FindFirstObjectByType<CommandManager>();
        _statsController = FindFirstObjectByType<StatsController>();
    }

    private void Start()
    {
        readyForBuff = true;
    }

    private void Update()
    {
        ListenBuffToApply();
    }

    private void ListenBuffToApply()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && readyForBuff)
        {
            type = PowerupType.SpeedBoost;

            ICommand command = new PowerupCommand(_statsController, type, spdBuffDuration);
            _cmdManager.ExecuteCommand(command);
            StartCoroutine(RunCoolDown());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && readyForBuff)
        {
            type = PowerupType.AtkBoost;

            ICommand command = new PowerupCommand(_statsController, type, atkBuffDuration);
            _cmdManager.ExecuteCommand(command);
            StartCoroutine(RunCoolDown());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && readyForBuff)
        {
            type = PowerupType.EnergyBoost;

            ICommand command = new PowerupCommand(_statsController, type, energyBuffDuration);
            _cmdManager.ExecuteCommand(command);
            StartCoroutine(RunCoolDown());
        }
    }

    IEnumerator RunCoolDown()
    {
        readyForBuff = false;
        yield return new WaitForSeconds(cooldown);
        readyForBuff = true;
    }
    
}

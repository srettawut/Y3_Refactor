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
    private Transform player;

    [Header("Buff Effects")]
    [SerializeField] GameObject spdEffect;
    [SerializeField] GameObject atkEffect;
    [SerializeField] GameObject energyEffect;

    private void Awake()
    {
        _cmdManager = FindFirstObjectByType<CommandManager>();
        _statsController = FindFirstObjectByType<StatsController>();
        
    }

    private void Start()
    {
        readyForBuff = true;
        player = FindFirstObjectByType<PlayerMovement>().transform;
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
            GameObject buff = Instantiate(spdEffect);
            buff.transform.parent = player.transform;
            buff.transform.position = new Vector3(player.position.x, player.position.y - 1f, player.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && readyForBuff)
        {
            type = PowerupType.AtkBoost;

            ICommand command = new PowerupCommand(_statsController, type, atkBuffDuration);
            _cmdManager.ExecuteCommand(command);
            StartCoroutine(RunCoolDown());
            GameObject buff = Instantiate(atkEffect);
            buff.transform.parent = player;
            buff.transform.position = new Vector3(player.position.x, player.position.y - 1f, player.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && readyForBuff)
        {
            type = PowerupType.EnergyBoost;

            ICommand command = new PowerupCommand(_statsController, type, energyBuffDuration);
            _cmdManager.ExecuteCommand(command);
            StartCoroutine(RunCoolDown());
            GameObject buff = Instantiate(energyEffect);
            buff.transform.parent = player;
            buff.transform.position = new Vector3(player.position.x, player.position.y - 1f, player.position.z);
        }
    }

    IEnumerator RunCoolDown()
    {
        readyForBuff = false;
        yield return new WaitForSeconds(cooldown);
        readyForBuff = true;
    }
    
}

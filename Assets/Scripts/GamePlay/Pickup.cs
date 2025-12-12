using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] int EnergyAmount;
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            EventManager.RaiseEnergyCollected(EnergyAmount);
            gameObject.SetActive(false);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.AI;

public class zombie : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float hp=200;
    [SerializeField] GameObject energyBall;

    NavMeshAgent agent;
    Transform player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindFirstObjectByType<PlayerMovement>().transform;
        
    }

    private void Update()
    {
        agent.SetDestination(player.position);
    }

    public void takeDamage(float amount)
    {
        hp -= amount;
        if(hp <= 0)
        {
            Die();
        }
        Debug.Log("enemy took " + amount + " dmg");
    }

    private void Die()
    {
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(transform.position.x, transform.position.y+1f, transform.position.z);
        Instantiate(energyBall, pos, Quaternion.identity);
    }
}

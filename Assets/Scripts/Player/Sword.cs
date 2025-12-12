using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private bool canhit = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(EnableHit(1f));
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            if (!canhit)
                return;
            zombie z=col.GetComponent<zombie>();
            z.takeDamage(StatsController.atk);
        }
    }

    IEnumerator EnableHit(float duration)
    {
        canhit = true;
        yield return new WaitForSeconds(duration);
        canhit = false;
    }
}

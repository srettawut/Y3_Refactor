using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;

    private bool canSlash2;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))   // คลิกซ้ายลงครั้งแรก
        {
            StartCoroutine(Slash());
        }
    }
    IEnumerator Slash()
    {
        if (!canSlash2)
        {
            animator.SetTrigger("slash1");
        }
        else if (canSlash2)
        {
            animator.SetTrigger("slash2");
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(EnableSlah2(1f));
    }

    IEnumerator EnableSlah2(float duration)
    {
        canSlash2 = true;
        yield return new WaitForSeconds(duration);
        canSlash2 = false;
    }
}

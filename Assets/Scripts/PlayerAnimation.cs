using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Animator")]
    public Animator animator;

    [Header("PlayerRef")]
    public Transform player;
    public Transform playerObj;
    public void Walk()
    {
        animator.SetBool("walking",true);
    }

    public void Idle()
    {
        animator.SetBool("walking",false);

        Vector3 resetPos = new Vector3(player.position.x, player.position.y - 1f, player.position.z);

        playerObj.position = resetPos;
    }

    public void Jump()
    {
        animator.SetTrigger("jump");
    }

    
}

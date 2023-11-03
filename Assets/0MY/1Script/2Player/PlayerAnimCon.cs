using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimCon : MonoBehaviour
{
    [SerializeField] Animator animator;


    public void SetMove(bool moveStatus)
    {
        animator.SetBool("Move", moveStatus);
    }






}

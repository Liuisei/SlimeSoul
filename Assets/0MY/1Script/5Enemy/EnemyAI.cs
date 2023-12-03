using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] EnemyTergetDistance enemyTergetDistance;
    [SerializeField] Rigidbody2D rb2;
    Transform target;
    [SerializeField] int moveSpeed = 100;
    [SerializeField] EnemyFire enemyFire;
    [SerializeField] Animator animator;
    void Start()
    {
        if (rb2 == null) Debug.LogError(rb2 + "nuLL");
    }
    void EnemyAIRepit()
    {
        // ランダムに選択
        int randomChoice = Random.Range(0, 3);

        if (randomChoice == 0)
        {
            RandomMove();
        }
        else if (randomChoice == 1)
        {
            MooveToPlayer();
        }
        else if (randomChoice == 2)
        {
            ATKanim();
        }
    }

    public void SetTarget(Transform newTarget) // enemyTergetDistance.onTargetUpdate がでターゲットが更新される時発動する　
    {
        target = newTarget;

        if (target != null)
        {
            if (!IsInvoking("EnemyAIRepit"))
            {
                InvokeRepeating("EnemyAIRepit", 1f, 2f);
            }
        }
        else
        {
            CancelInvoke("EnemyAIRepit");
        }
    }

    private void OnEnable()
    {
        enemyTergetDistance.onTargetUpdate += SetTarget;
    }
    private void OnDisable()
    {
        enemyTergetDistance.onTargetUpdate -= SetTarget;
    }

    void RandomMove()
    {
        rb2.AddForce(Random.insideUnitCircle.normalized * Random.Range(1, moveSpeed));
        Debug.Log("RandomMove");
    }

    void MooveToPlayer()
    {
        rb2.AddForce(moveSpeed * (Vector2)(target.position - transform.position).normalized);
        Debug.Log("MooveToPlayer");
    }

    void ATKanim()//アニメーションを発動して　animから　atk発動
    {
        animator.SetTrigger("ATK");
    }

    void ATK()
    {
        enemyFire.Fire();
        Debug.Log("EnemyFire");
    }

}

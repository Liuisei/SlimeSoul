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
    // Start is called before the first frame update
    void Start()
    {
        if (rb2 == null) Debug.LogError(rb2 + "nuLL");
    }
    void EnemyAIRepit()
    {
        // ƒ‰ƒ“ƒ_ƒ€‚É‘I‘ð
        int randomChoice = Random.Range(0, 2);

        if (randomChoice == 0)
        {
            RandomMove();
        }
        else
        {
            MooveToPlayer();
        }
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

    public void SetTarget(Transform newTarget)
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
}

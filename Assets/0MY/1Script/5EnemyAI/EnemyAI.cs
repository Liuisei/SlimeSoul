using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
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
        rb2.AddForce(new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)) * Random.Range(1, moveSpeed));
        Debug.Log("RandomMove");
    }
    void MooveToPlayer()
    {
        rb2.AddForce(moveSpeed * (Vector2)(target.position - transform.position).normalized);
        Debug.Log("MooveToPlayer");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHP>(out PlayerHP PHP))
        {
            if (target == null) target = collision.transform;
            InvokeRepeating("EnemyAIRepit", 1f, 2f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == target)
        {
            target = null;
            CancelInvoke("EnemyAIRepit");
        }
    }
}

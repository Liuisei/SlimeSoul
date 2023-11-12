using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerTargetEnemyDistance : MonoBehaviour
{
    Transform targetTransform;
    List<EnemyHP> enemyHPs = new List<EnemyHP>();
    [SerializeField] LookAt lookAt;

    private void Start()
    {
        if (lookAt == null) Debug.LogError(" looAt is null"); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyHP>(out EnemyHP enemyHP))
        {
            enemyHPs.Add(enemyHP);
            UpdateTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyHP>(out EnemyHP enemyHP))
        {
            enemyHPs.Remove(enemyHP);
            UpdateTarget();
        }
    }

    void UpdateTarget()
    {
        targetTransform = enemyHPs.OrderBy(enemy => Vector2.Distance(transform.position, enemy.transform.position)).FirstOrDefault()?.transform;

        if (targetTransform != null)
        {
            lookAt.SetTarget(targetTransform);
        }
        else
        {
            lookAt.SetTarget(transform);
        }
    }

    public Transform GetTarget()
    {
        return targetTransform;
    }
}

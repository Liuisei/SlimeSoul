using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class TergetDistanceFirstTransform<T> : MonoBehaviour where T : Component
{
    Transform targetTransform;
    List<T> enemyHPs = new List<T>();
    [SerializeField] LookAt lookAt;

    private void Start()
    {
        if (lookAt == null) Debug.LogError(" looAt is null"); 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<T>(out T enemyHP))
        {
            enemyHPs.Add(enemyHP);
            UpdateTarget();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<T>(out T enemyHP))
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

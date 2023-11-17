using UnityEngine;

public class EnemyLookat : LookAt
{
    [SerializeField] EnemyTergetDistance enemyTergetDistance;
    public override void OnEnableSetAction()
    {
        enemyTergetDistance.onTargetUpdate += SetTarget;
    }
    public override void OnDisableRemoveAction()
    {
        enemyTergetDistance.onTargetUpdate -= SetTarget;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookat : LookAt
{
    [SerializeField] PlayerTargetDistance PlayerTergetDistance;
    public override void OnEnableSetAction()
    {
        PlayerTergetDistance.onTargetUpdate += SetTarget;
    }
    public override void OnDisableRemoveAction()
    {
        PlayerTergetDistance.onTargetUpdate -= SetTarget;
    }
}

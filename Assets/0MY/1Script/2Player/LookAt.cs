using UnityEngine;

public  class LookAt : MonoBehaviour
{
    /// <summary>  見るターゲット　/// </summary>
    [SerializeField] Transform _tergetTransform;
    /// <summary>  見る側　/// </summary>
    [SerializeField] Transform _observer;

    [SerializeField] bool _permission = false;

    protected virtual void FixedUpdate()
    {
        if (_tergetTransform != null)
        {
            _observer.transform.up = (_tergetTransform.position - transform.position).normalized;//ターゲット　の　方向を上にする
        }
    }
    
    public void SetTarget(Transform targetTransform)//ターゲット　の　セット
    {
        _tergetTransform = targetTransform;
    }

    public void SetPremission(bool permission)//許可
    {
        _permission = permission;
    }

    public void SetObserver(Transform newObserver)//見る側
    {
        _observer = newObserver;
    }
}
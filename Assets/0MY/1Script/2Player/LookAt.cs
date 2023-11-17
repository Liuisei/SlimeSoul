using UnityEngine;

public abstract class LookAt : MonoBehaviour
{
    /// <summary>  見るターゲット　/// </summary>
    [SerializeField] Transform _tergetTransform;
    /// <summary>  見る側　/// </summary>
    [SerializeField] Transform _observer;

    [SerializeField] bool _permission = false;

    /// <summary>
    /// actionSet(); で　SetTarget(Transform targetTransform)//ターゲット　の　セット　を外部の目スクリプトのACTIONにセットして下さい
    /// </summary>
    abstract public void OnEnableSetAction();

    /// <summary>
    /// actionSet(); で　SetTarget(Transform targetTransform)//ターゲット　の　セット　を外部の目スクリプトのACTIONに`解除して下さい
    /// </summary>
    abstract public void OnDisableRemoveAction();


    protected virtual void FixedUpdate()
    {
        if (_tergetTransform != null)
        {
            _observer.transform.up = (_tergetTransform.position - transform.position).normalized;//ターゲット　の　方向を上にする
        }
    }
    protected void SetTarget(Transform targetTransform)//ターゲット　の　セット
    {
        _tergetTransform = targetTransform;
    }

    protected void SetPremission(bool permission)//許可
    {
        _permission = permission;
    }
    private void OnEnable()
    {
        OnEnableSetAction ();
    }
    private void OnDisable()
    {
        OnDisableRemoveAction();
    }


}
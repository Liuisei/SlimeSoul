using UnityEngine;

public abstract class LookAt : MonoBehaviour
{
    /// <summary>  ����^�[�Q�b�g�@/// </summary>
    [SerializeField] Transform _tergetTransform;
    /// <summary>  ���鑤�@/// </summary>
    [SerializeField] Transform _observer;

    [SerializeField] bool _permission = false;

    /// <summary>
    /// actionSet(); �Ł@SetTarget(Transform targetTransform)//�^�[�Q�b�g�@�́@�Z�b�g�@���O���̖ڃX�N���v�g��ACTION�ɃZ�b�g���ĉ�����
    /// </summary>
    abstract public void OnEnableSetAction();

    /// <summary>
    /// actionSet(); �Ł@SetTarget(Transform targetTransform)//�^�[�Q�b�g�@�́@�Z�b�g�@���O���̖ڃX�N���v�g��ACTION��`�������ĉ�����
    /// </summary>
    abstract public void OnDisableRemoveAction();


    protected virtual void FixedUpdate()
    {
        if (_tergetTransform != null)
        {
            _observer.transform.up = (_tergetTransform.position - transform.position).normalized;//�^�[�Q�b�g�@�́@��������ɂ���
        }
    }
    protected void SetTarget(Transform targetTransform)//�^�[�Q�b�g�@�́@�Z�b�g
    {
        _tergetTransform = targetTransform;
    }

    protected void SetPremission(bool permission)//����
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
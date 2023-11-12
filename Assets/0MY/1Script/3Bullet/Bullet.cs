using UnityEngine;

public  class Bullet : MonoBehaviour ,IDamage
{
    [SerializeField] int _damege = -10;

    public int GetDamage()
    {
        return _damege;
    }
    public void SetDamage(int value)
    {
        _damege = value;
    }

}

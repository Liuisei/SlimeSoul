using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected int _damege = -10;


    public void SetDamage(int value)
    {
        _damege = value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HitoperaterCollision(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitoperaterTrigger(collision);
    }

    abstract public void HitoperaterCollision(Collision2D collision);
    abstract public void HitoperaterTrigger(Collider2D collision);
}

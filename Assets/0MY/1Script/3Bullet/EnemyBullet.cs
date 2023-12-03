using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    public override void HitoperaterCollision(Collision2D collision)
    {

    }
    public override void HitoperaterTrigger(Collider2D collision)
    {
        PlayerHP target = collision.transform.GetComponent<PlayerHP>();
        if (target != null)
        {
            if (target is PlayerHP)
            {
                (target as PlayerHP).HPaddValue(_damege);
            }
        }
    }
}

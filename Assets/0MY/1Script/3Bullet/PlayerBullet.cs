using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public override void HitoperaterCollision(Collision2D collision)
    {

    }
    public override void HitoperaterTrigger(Collider2D collision)
    {
        EnemyHP target = collision.transform.GetComponent<EnemyHP>();
        if (target != null)
        {
            if (target is EnemyHP)
            {
                (target as EnemyHP).HPaddValue(_damege);
            }
        }
    }
}

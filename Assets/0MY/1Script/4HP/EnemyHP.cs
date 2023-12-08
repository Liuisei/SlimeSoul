using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyHP : HP
{
    [SerializeField] GameObject gameObjectSpawn;
    protected override void HpUnder0()
    {
        if (gameObjectSpawn != null)
        {
            GameObject NewSpawn = Instantiate(gameObjectSpawn,transform.position,Quaternion.identity);
            NewSpawn.transform.parent = null;
            Destroy(NewSpawn, 5f);
        }

        Destroy(gameObject);
    }

}

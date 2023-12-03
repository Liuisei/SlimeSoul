using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _firepoint;
    [SerializeField, Range(1, 10)] int _buletSpeed;

    public void Fire() 
    {
        GameObject newBullet = Instantiate(_bullet, _firepoint);
        newBullet.transform.parent = null;
        newBullet.GetComponent<Rigidbody2D>().velocity = newBullet.transform.up * _buletSpeed;
    }


}

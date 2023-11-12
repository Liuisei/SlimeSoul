using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    SlimeSoulInputSystem inputActionsSystem;
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _firepoint;
    [SerializeField, Range(0.1f, 10f)] int _coolTime;
    [SerializeField, Range(1, 10)] int _buletSpeed;
    [SerializeField] bool _outoFire;
    Transform targetTransform; // terget enemy
    List<EnemyHP> enemyHPs = new List<EnemyHP>(); // enemy intrigger

    bool _cooloff = true;

    private void Awake()
    {
        inputActionsSystem = new SlimeSoulInputSystem(); // Input Systemのアクションを初期化
    }
    void OnEnable()
    {
        inputActionsSystem.Enable(); // Input Systemのアクションを有効化
        inputActionsSystem.Player.Fire.started += OutoFireSet;
    }
    void OnDisable()
    {
        inputActionsSystem.Disable(); // Input Systemのアクションを無効化
        inputActionsSystem.Player.Fire.started -= OutoFireSet;
    }
    public void Fire() //クールタイム中　コルーチン　FireCoolTime　の発動禁止
    {
        if (_cooloff) StartCoroutine(FireCoolTime());
    }

    IEnumerator FireCoolTime()
    {
        _cooloff = false;
        GameObject newBullet = Instantiate(_bullet, _firepoint);
        newBullet.transform.parent = null;
        if (targetTransform != null) newBullet.transform.up = (targetTransform.position - transform.position).normalized;
        newBullet.GetComponent<Rigidbody2D>().velocity = newBullet.transform.up * _buletSpeed;
        yield return new WaitForSeconds(_coolTime);
        _cooloff = true;
        if (_outoFire) Fire();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyHP>(out EnemyHP enemyHP))
        {
            enemyHPs.Add(enemyHP);
            UpdateTarget();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyHP>(out EnemyHP enemyHP))
        {
            enemyHPs.Remove(enemyHP);
            UpdateTarget();
        }
    }
    void UpdateTarget()
    {
        targetTransform = enemyHPs.OrderBy(enemy => Vector2.Distance(transform.position, enemy.transform.position)).FirstOrDefault()?.transform;
    }
    public Transform GetTarget()
    {
        return targetTransform;
    }
    //Seter
    public void OutoFireSet(InputAction.CallbackContext ctx)
    {
        _outoFire = !_outoFire;
        if (_outoFire) Fire();
        Debug.Log(_outoFire + "_outoFire");
    }

    //Geter

}

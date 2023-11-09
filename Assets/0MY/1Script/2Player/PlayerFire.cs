using System.Collections;
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
        newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * _buletSpeed;
        yield return new WaitForSeconds(_coolTime);
        _cooloff = true;
        if (_outoFire) Fire();
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

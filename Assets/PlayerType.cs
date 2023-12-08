using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerType : MonoBehaviour
{
    [SerializeField] List<HatBullet> _Players;
    [SerializeField] SpriteRenderer _SpriteRenderer;
    [SerializeField] PlayerFire _PlayerFire;
    // Start is called before the first frame update



    public void UpdateType(int id)
    {
        var a = _Players[id];
        _SpriteRenderer.sprite = a.sprite;

        _PlayerFire.SetCoolTime(a._coolTime);
        _PlayerFire.SetBullet(a.bullet);
        _PlayerFire.SetSpeed(a._buletSpeed);


        Debug.Log(_SpriteRenderer);
    }
}


[Serializable]
class HatBullet
{
    public Sprite sprite;
    public string name;
    [Range(0.1f, 10f)] 
    public float _coolTime;
    [Range(1, 10)] 
    public int _buletSpeed;
    public GameObject bullet;

}

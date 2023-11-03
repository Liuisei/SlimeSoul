using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // 矢印キーまたはWASDキーからの入力を取得
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 移動ベクトルを計算
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // 対角線移動を防ぐために移動ベクトルを正規化
        movement.Normalize();

        // 物理エンジンを使用してプレイヤーを移動させる
        rb.velocity = movement * speed;
    }
}

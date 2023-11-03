using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    SlimeSoulInputSystem inputActions;
    Rigidbody2D rb;
    Vector2 movementInput;
    [SerializeField] private float speed = 5f;
    [SerializeField] PlayerAnimCon playerAnimCon;

    void Awake()
    {
        inputActions = new SlimeSoulInputSystem(); // Input Systemのアクションを初期化
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
    }

    void OnEnable()
    {
        inputActions.Enable(); // Input Systemのアクションを有効化

        // 移動アクションのコールバックを設定
        inputActions.Player.Move.performed += OnMovePerformed; // 移動アクションが実行されたときの処理を設定
        inputActions.Player.Move.canceled += OnMoveCanceled; // 移動アクションがキャンセルされたときの処理を設定
    }

    void OnDisable()
    {
        inputActions.Disable(); // Input Systemのアクションを無効化

        // 移動アクションのコールバックを解除
        inputActions.Player.Move.performed -= OnMovePerformed; // 移動アクションが実行されたときの処理を解除
        inputActions.Player.Move.canceled -= OnMoveCanceled; // 移動アクションがキャンセルされたときの処理を解除
    }

    void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        if (!inputActions.Player.Move.enabled) return; // 移動アクションが無効の場合、処理をスキップ

        movementInput = ctx.ReadValue<Vector2>(); // 入力ベクトルを取得

        playerAnimCon.SetMove(true);
    }

    void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        if (!inputActions.Player.Move.enabled) return; // 移動アクションが無効の場合、処理をスキップ

        movementInput = Vector2.zero; // 入力ベクトルをゼロにリセット

        playerAnimCon.SetMove(false);
    }

    // Moveアクションの有効/無効を設定するメソッド
    public void SetMoveActionDisable()
    {
        inputActions.Player.Move.Disable(); 
    }

    public void SetMoveActionEnable()
    {
        inputActions.Player.Move.Enable();
    }
    void FixedUpdate()
    {
        Vector2 movement = movementInput.normalized; // 移動ベクトルを正規化

        rb.velocity = movement * speed; // 物理エンジンを使用してプレイヤーを移動させる

        // プレイヤーの向きを変更
        if (movement != Vector2.zero)
        {
            // 移動入力に基づいて右か左を向く
            if (movement.x > 0)
            {
                // 右を向く
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (movement.x < 0)
            {
                // 左を向く
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

}
